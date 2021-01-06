using Cambialo.Api.Data;
using Cambialo.Api.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Services
{
    public class ChangesService : IChangesService
    {
        private readonly ApplicationDbContext dbContext;

        public ChangesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Response<ChangesResponse> GetChangesByUser(Guid id)
        {
            var initializedChanges = dbContext.Changes
                .Where(c => c.CreatorUserId == id).ToList();

            var receivededChanges = dbContext.Changes
                .Where(c => c.ReceivedUserId == id).ToList();

            if (!initializedChanges.Any() && !receivededChanges.Any())
            {
                return new Response<ChangesResponse>("No data");
            }
            return new Response<ChangesResponse>("Recovered data", true,
                new ChangesResponse()
                {
                    UserId = id,
                    InitializedChanges = initializedChanges.Select(iC => new ChangeResponseDTO()
                    {
                        Id = iC.Id,
                        ChangeType = iC.ChangeType,
                        ChangeStatus = iC.ChangeStatus,
                        CreatorUser = iC.CreatorUserId,
                        ReceivedUser = iC.ReceivedUserId,
                        StartDate = iC.StartDate,
                        FinishedDate = iC.FinishedDate
                    }).ToList(),
                    ReceivedChanges = receivededChanges.Select(rC => new ChangeResponseDTO()
                    {
                        Id = rC.Id,
                        ChangeType = rC.ChangeType,
                        ChangeStatus = rC.ChangeStatus,
                        CreatorUser = rC.CreatorUserId,
                        ReceivedUser = rC.ReceivedUserId,
                        StartDate = rC.StartDate,
                        FinishedDate = rC.FinishedDate
                    }).ToList()
                });
        }
    }
}
