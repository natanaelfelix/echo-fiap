using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalLCB.Receb.Controllers
{
    /// <summary>
    /// API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {

        /// <summary>
        /// Health
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        public ActionResult Health()
        {
           return Ok();

        }
    }


}
