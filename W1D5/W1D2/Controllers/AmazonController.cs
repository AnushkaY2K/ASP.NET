using BusinessLayer;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmazonController : ControllerBase
    {
        private readonly ILogger<AmazonController> _logger;
        private readonly IAmazonBusiness _amazonBusiness;

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
        [Route("Get-All-AamazonCountry")]
        public async Task<ActionResult<IEnumerable<AmazonCountry>>> GetAllAmazonCountry()
        {
            try
            {
                var resp = await _amazonBusiness.GetCountries();

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
        [Route("Get-AmazonCountryById")]
        public async Task<ActionResult<AmazonCountry>> GetAmazonCountryById(int id)
        {
            try
            {
                var resp = await _amazonBusiness.GetCountry(id);

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
        [Route("insert-AmazonCountry")]
        public async Task<ActionResult> InsertAmazonCountry([FromBody] List<AmazonCountry> country)
        {
            try
            {


                foreach (var orp in country)
                {
                    await _amazonBusiness.InsertCountry(orp);
                }

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
        public async Task<ActionResult> UpdateAmazonCountry([FromBody] AmazonCountry country)
        {
            try
            {
                await _amazonBusiness.UpdateCountry(country);
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
                await _amazonBusiness.DeleteCountry(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }


}