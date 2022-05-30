using ClaimsIdentity.Models;
using ClaimsIdentity.ViewModels.User;

namespace ClaimsIdentity.Interfaces
{
    public interface IPersonService
    {
        void Insert(User user);
        UserListModelView GetPeople();
        UserListModelView GetTodayPeople();
    }
}
