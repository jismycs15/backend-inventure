using inventure.Models.Payloads;
using inventure.Models.Response;

namespace inventure.Services
{
    public interface IUserManagementService
    {
        response CreateUser(Userpayload payload);
    }
}
