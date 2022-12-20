namespace CreditCar.Entity.Utilities
{
    using ExcelDataReader;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;

    [ExcludeFromCodeCoverage]
    public static class Excel
    {
        public static DataTable? CsvToTable(Stream blobStream)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using var excelReader = ExcelReaderFactory.CreateCsvReader(blobStream);
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = x => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true,
                },
            };

            return excelReader.AsDataSet(conf)?.Tables[0];
        }

        //public static T ToObjects<T>(this DataRow dataRow) where T : new()
        public static List<T> ToObjects<T>(this DataTable dataTable) where T : new()
        {
            List<T> items = new();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                T item = new T();
                foreach (DataColumn column in dataRow.Table.Columns)
                {
                    PropertyInfo? property = GetProperty(typeof(T), column.ColumnName);

                    if (property != null && dataRow[column] != DBNull.Value && dataRow[column].ToString() != "NULL")
                    {
                        property.SetValue(item, ChangeType(dataRow[column], property.PropertyType), null);
                    }
                }
                items.Add(item);

            }

            return items;
        }

        private static PropertyInfo? GetProperty(Type type, string attributeName)
        {
            PropertyInfo? property = type.GetProperty(attributeName);

            if (property != null)
            {
                return property;
            }

            return type.GetProperties()
                 .Where(p => p.IsDefined(typeof(DisplayAttribute), false) && p.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Single().Name == attributeName)
                 .FirstOrDefault();
        }

        public static object? ChangeType(object value, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                return Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
            }

            return Convert.ChangeType(value, type);
        }
    }
}
