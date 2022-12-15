using CreditCar.Entity.Models;

namespace CreditCar.Domain.Interfaces
{
    public interface IPost    
    {
       Task<IEnumerable<Post>> GetPosts();
        
    }
}