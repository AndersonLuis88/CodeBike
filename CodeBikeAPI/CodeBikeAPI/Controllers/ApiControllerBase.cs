using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using CodeBikeAPI.Services;

namespace CodeBikeAPI.Controllers
{
    /// Classe Base
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(void), Description = HttpStatusMessages.BadRequest)]
    public abstract class ApiControllerBase<TServices, TDataContext> : ControllerBase
        where TServices : ControllerServices<TDataContext>
        where TDataContext : class
    {

        #region Helper methods
        
        protected IActionResult OkOrNotFound(bool condition)
        {
            return condition ? (IActionResult)Ok() : NotFound();
        }

        protected IActionResult OkOrNotFound<T>(T value) where T : class
        {
            return value == null ? (IActionResult)NotFound() : Ok(value);
        }

        protected IActionResult OkOrNotFoundOrConflict(bool? condition)
        {
            return condition == true ? Ok() : condition == false ? (IActionResult)NotFound() : Conflict();
        }

        protected IActionResult OkOrNotFoundOrConflict(bool? condition, string conflictMessage)
        {
            return condition == true ? Ok() : condition == false ? (IActionResult)NotFound() : Conflict(conflictMessage);
        }
        #endregion

    }

}
