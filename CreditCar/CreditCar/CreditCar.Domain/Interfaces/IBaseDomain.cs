namespace CreditCar.Domain.Interfaces
{
    public interface IBaseDomain<Entity, Dto> where Entity : class
    {
        Task<Entity> GetByIdAsync(int id);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<IEnumerable<Entity>> InsertAsync(Dto dto);
        Task<bool> UpdateAsync(Dto dto);
        Task<bool> DeleteGetByIdAsync(int id);
    }
}