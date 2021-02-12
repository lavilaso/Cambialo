using Cambialo.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Models.Requests
{
    public class ArticleRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public ArticleStatus Status { get; set; }
    }
}
