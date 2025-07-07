using inventure.Models.Payloads;
using inventure.Models.Response;

namespace inventure.Services
{
    public interface ILoginService
    {
        LoginResponse Login(LoginRequestPayload request);
    }
}
