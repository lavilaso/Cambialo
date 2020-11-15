using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data.Entities
{
    public class User : IdentityUser<Guid>
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Change> CreatedChanges { get; set; }
        public ICollection<Change> ReceivedChanges { get; set; }
    }
}
