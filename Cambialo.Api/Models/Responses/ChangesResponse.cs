using Cambialo.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Models.Responses
{
    public class ChangesResponse
    {
        public Guid UserId { get; set; }
        public List<ChangeResponseDTO> InitializedChanges { get; set; }
        public List<ChangeResponseDTO> ReceivedChanges { get; set; }

    }
}
