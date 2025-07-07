using inventure.Models.Payloads;
using inventure.Models.Response;
using inventure.Repositories;

namespace inventure.Services.impl
{
    public class UserManagementService:IUserManagementService
    {
        private readonly IUserManagementRepository _usermanagementrepository;

        public UserManagementService (IUserManagementRepository userManagementRepository)
        {
            _usermanagementrepository = userManagementRepository;
        }
        public response CreateUser(Userpayload payload)
        {
            return _usermanagementrepository.CreateUser(payload);
        }
    }
}
