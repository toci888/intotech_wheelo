using Toci.Driver.Bll.Porsche.Interfaces.Services;
using Toci.Driver.Dal.Invitation;
using Toci.Driver.Dal.Invitation.Interfaces;

namespace Toci.Driver.Bll.Porsche.Services
{
    public class UserService : Dal<Users>, IUserService
    {
        public UserService(DriverEntities db) : base(db)
        {
        }

        public void RegisterUser(Users user)
        {
           // WheeloDbContext.Users.Add(user);
        }
    }
}