using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
