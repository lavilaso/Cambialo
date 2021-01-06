using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cambialo.Api.Models.Responses;

namespace Cambialo.Api.Services
{
    public interface IChangesService
    {
        Response<ChangesResponse> GetChangesByUser(Guid id);
    }
}
