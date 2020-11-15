using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data.Entities
{
    public class Article : BaseEntity<Guid>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ArticleStatus Status { get; set; }   

        public Guid? RequestedInChangeId { get; set; }
        public Change RequestedInChange { get; set; }
        public Guid? OfferInChangeId { get; set; }
        public Change OfferInChange { get; set; }
    }
}
    