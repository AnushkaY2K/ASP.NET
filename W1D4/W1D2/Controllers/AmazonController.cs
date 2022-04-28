using BusinessLayer;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace W1D2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmazonController : ControllerBase
    {

        private readonly ILogger<AmazonController> _logger;
        private IAmazonBusiness _amazonBusiness;

        public AmazonController(ILogger<AmazonController> logger, IAmazonBusiness amazonBusiness)
        {
            _logger = logger;
            _amazonBusiness = amazonBusiness;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonCountry>))]
        [Route("Get-AllAmazonCountries")]
        public async Task<ActionResult<IEnumerable<AmazonCountry>>> GetAll()
        {
            try
            {
                var resp = await _amazonBusiness.GetAmazonCountries();

                if (resp == null || resp.Count == 0)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(AmazonCountry))]
        [Route("Get-AmazonCountry")]
        public async Task<ActionResult<AmazonCountry>> GetAmazonCountryById(int id)
        {
            try
            {
                var resp = await _amazonBusiness.GetAmazonCountry(id);

                if (resp == null)
                {
                    return StatusCode(404, "No Data available.");
                }
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("Insert-AmazonCountry")]
        public async Task<ActionResult> InsertAmazonCountry([FromBody] AmazonCountry amazoncountry)
        {
            try
            {
                await _amazonBusiness.InsertAmazonCountry(amazoncountry);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("Update-AmazonCountry")]
        public async Task<ActionResult> UpdateAmazonCountry([FromBody] AmazonCountry amazoncountry)
        {
            try
            {
                await _amazonBusiness.UpdateAmazonCountry(amazoncountry);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("Delete-AmazonCountry")]
        public async Task<ActionResult> DeleteAmazonCountry(int id)
        {
            try
            {
                await _amazonBusiness.DeleteAmazonCountry(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}