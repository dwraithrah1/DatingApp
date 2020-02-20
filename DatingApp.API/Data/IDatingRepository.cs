using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
         //take a type of T, where it takes the entity, and T is restricted to being a class
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         //Task class lets you create tasks that run asynchronously.  It's an object
         //that represents some work that needs to be done.  Can tell you if work
         //is completed and if it needs a result, returns the result. 
         Task<bool> SaveAll();
         //Ienumerable is an interface that returns an enumerator that iterates through a collection
         //i.e: looping through generic and non generic lists. It is read only. 
         Task<User> GetUser(int id);
         Task<IEnumerable<User>> GetUsers();
    }
}