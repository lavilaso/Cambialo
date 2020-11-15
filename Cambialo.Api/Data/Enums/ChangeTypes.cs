using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data.Enums
{
    public enum ChangeTypes
    {
        Request, //El usuario solicita un articulo del segundo usuario sin ofrecer ninguno de sus articulos
        Offer //El usuario solicita un articulo del segundo usuario ofreciendole uno de sus articulos
    }
}
