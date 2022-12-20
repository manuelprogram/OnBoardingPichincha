using AutoMapper;
using CreditCar.Entity.Models;
using CreditCar.Infrastructure.Services;
using CreditCar.Repository.Context;
using CreditCar.Repository.DataAccess.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CreditCar.Test
{
    public class BaseServicesTest
    {
        /// <summary>
        /// The baseDomain.
        /// </summary>
        private BaseService<Cliente, ClienteDto> baseService;

        /// <summary>
        /// The mappernMock.
        /// </summary>
        private Mock<IMapper> mappernMock;

        /// <summary>
        /// The sqlDataMock.
        /// </summary>
        private Mock<IRepository<Cliente>> sqlDataMock;

        public BaseServicesTest()
        {
            mappernMock = new Mock<IMapper>();
            sqlDataMock = new Mock<IRepository<Cliente>>();

            baseService = new(mappernMock.Object, sqlDataMock.Object);
        }

        [Fact]
        public async Task GetAllFactAsync()
        {
            sqlDataMock.Setup(x => x.GetAllAsync()).ReturnsAsync(new[] { new Cliente { IdCliente = 1 } });

            var result = await baseService.GetAllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByIdTestAsync()
        {
            sqlDataMock.Setup(x => x.GetByIdAsync(It.IsAny<object>())).ReturnsAsync(new Cliente { IdCliente = 1 });

            var result = await baseService.GetByIdAsync(1);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task InsertTestAsync()
        {
            sqlDataMock.Setup(x => x.GetByIdAsync(It.IsAny<object>())).ReturnsAsync(new Cliente { IdCliente = 1 });
            ClienteDto ownerDto = new(){ IdCliente = 1 };

            var result = await baseService.InsertAsync(ownerDto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateTestAsync()
        {
            sqlDataMock.Setup(x => x.SaveAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            ClienteDto ownerDto = new() { IdCliente = 1 };

            var result = await baseService.UpdateAsync(ownerDto);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteGetByIdTestAsync()
        {
            sqlDataMock.Setup(x => x.GetByIdAsync(It.IsAny<object>())).ReturnsAsync(new Cliente { IdCliente = 1 });
            sqlDataMock.Setup(x => x.SaveAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            ClienteDto ownerDto = new() { IdCliente = 1 };


            var result = await baseService.DeleteGetByIdAsync(1);

            Assert.True(result);
        }
    }
}
