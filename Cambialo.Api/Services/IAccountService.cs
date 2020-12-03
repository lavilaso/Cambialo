using Cambialo.Api.Models.Requests;
using System.Threading.Tasks;

namespace Cambialo.Api.Services
{
    public interface IAccountService
    {
        Task<int> AuthenticateAsync(string userName, string password);
        Task<int> RegisterAsync(RegisterRequest registerRequest);
    }
}