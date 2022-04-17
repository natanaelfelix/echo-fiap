using ECHO.BLL.interfaces;
using ECHO.MODEL.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECHO.API.Controllers {
    /// <summary>
    /// API Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : ControllerBase {

        private IMapBLL _mapBLL;

        public MapController(IMapBLL mapBLL) {
            _mapBLL = mapBLL;
        }
        /// <summary>
        /// Retorno Dos valores da API do fisco
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GeallMap() {
            try {
                var OK  = await _mapBLL.GetAllMap();
                return Ok(OK);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("OneMap")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetOneMap(int idMap) {
            try {
                var OK = await _mapBLL.GetOneMap(idMap);
                return Ok(OK);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> InsertMap([FromBody] List<Mapeamento> MapItens) {
            try {
                await _mapBLL.InsertMap(MapItens);
                return Ok("Order successfully");
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> DeleteMap(int idMap) {
            try {
                await _mapBLL.DeleteMap(idMap);
                return Ok("Order successfully");
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
    }    
}

    
