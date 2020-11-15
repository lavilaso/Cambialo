using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cambialo.Api.Data.Enums
{
    public enum ChangeStatus
    {
        Opened, //Avierto por usuario que solicita y ofrece o solo solicita
        Rejected, //Rechazado por el segundo usuario
        InProgress, //Aceptado por el segundo usuario y en progreso comunicandose
        CompletedFirstUser, //Marcado completado por el usuario que abrió
        CompletedSecondUser, //Marcado completado por el usuario receptor
        Completed, //Marcado completado por ambos usuarios
        CanceledFirstUser, //Cancelado por usuario que abre
        CanceledSecondUser //cancelado por usuario receptor
    }
}
