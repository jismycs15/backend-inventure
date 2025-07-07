using inventure.Models.Payloads;
using inventure.Models.Response;

namespace inventure.Repositories
{
    public interface IUserManagementRepository
    {
        response CreateUser(Userpayload payload);
    }
}
