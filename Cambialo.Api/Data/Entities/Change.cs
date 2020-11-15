using Cambialo.Api.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data.Entities
{
    public class Change : BaseEntity<Guid>
    {
        public DateTime StartDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public ChangeTypes ChangeType { get; set; }
        public ChangeStatus ChangeStatus { get; set; }

        public ICollection<Article> RequestedArticles { get; set; }
        public ICollection<Article> OffertedArticles { get; set; }


    }
}
