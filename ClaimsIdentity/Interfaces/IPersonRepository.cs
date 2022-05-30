using ClaimsIdentity.Models;

namespace ClaimsIdentity.Interfaces
{
    public interface IPersonRepository
    {
        void Insert(User user);
        IQueryable<User> GetPeople();
        IQueryable<User> GetTodayPeople();
    }
}
