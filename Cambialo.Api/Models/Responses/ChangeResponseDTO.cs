using Cambialo.Api.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Models.Responses
{
    public class ChangeResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public Guid CreatorUser { get; set; }
        public Guid ReceivedUser { get; set; }
        public ChangeTypes ChangeType { get; set; }
        public ChangeStatus ChangeStatus { get; set; }
    }
}
