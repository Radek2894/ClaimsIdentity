using ClaimsIdentity.Interfaces;
using ClaimsIdentity.Models;
using ClaimsIdentity.ViewModels.User;

namespace ClaimsIdentity.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _userRepo;

        public PersonService(IPersonRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void Insert(User user)
        {
            _userRepo.Insert(user);
        }

        public UserListModelView GetPeople()
        {
            var people = _userRepo.GetPeople();

            UserListModelView result = new UserListModelView();
            result.People = new List<UserModelView>();

            foreach (var user in people)
            {
                // mapowanie obiektow
                var pVM = new UserModelView()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Year = user.Year,
                    Result = user.Result,
                    CreatedTime = user.CreatedTime,
                    OwnerId = user.OwnerId,
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;

            return result;
        }

        public UserListModelView GetTodayPeople()
        {
            var people = _userRepo.GetTodayPeople();

            UserListModelView result = new UserListModelView();
            result.People = new List<UserModelView>();

            foreach (var user in people)
            {
                // mapowanie obiektow
                var pVM = new UserModelView()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Year = user.Year,
                    Result = user.Result,
                    CreatedTime = user.CreatedTime,
                    OwnerId = user.OwnerId,
                };
                result.People.Add(pVM);
            }
            result.Count = result.People.Count;

            return result;
        }
    }
}

