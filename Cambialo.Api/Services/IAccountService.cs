using Cambialo.Api.Models.Requests;
using Cambialo.Api.Models.Responses;
using System.Threading.Tasks;

namespace Cambialo.Api.Services
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticateRequest authenticateRequest);
        Task<Response<string>> RegisterAsync(RegisterRequest registerRequest);
    }
}   