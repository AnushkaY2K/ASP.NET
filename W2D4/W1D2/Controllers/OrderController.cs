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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IAmazonBusiness _amazonBusiness;

        public OrderController(ILogger<OrderController> logger, IAmazonBusiness amazonBusiness)
        {
            _logger = logger;
            _amazonBusiness = amazonBusiness;
        }

        //AmazonOrders
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrder>))]
        [Route("Get-All-AmazonOrder")]
        public async Task<ActionResult<IEnumerable<AmazonOrder>>> GetAllAmazonOrders()
        {
            try
            {
                var resp = await _amazonBusiness.GetOrders();

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
        [Produces("application/json", Type = typeof(AmazonOrder))]
        [Route("Get-AmazonOrderById")]
        public async Task<ActionResult<AmazonOrder>> GetAmazonOrderById(int id)
        {
            try
            {
                var resp = await _amazonBusiness.GetOrder(id);

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
        [Route("Insert-AmazonOrder")]
        public async Task<ActionResult> InsertAmazonOrder([FromBody] List<AmazonOrder> order)
        {
            try
            {


                foreach (var orp in order)
                {
                    await _amazonBusiness.InsertOrder(orp);
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
        [Route("Update-AmazonOrder")]
        public async Task<ActionResult> UpdateAmazonOrder([FromBody] AmazonOrder order)
        {
            try
            {
                await _amazonBusiness.UpdateOrder(order);
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
        [Route("Delete-AmazonOrder")]
        public async Task<ActionResult> DeleteAmazonOrder(int id)
        {
            try
            {
                await _amazonBusiness.DeleteOrder(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //GetAllOrderByCountryName
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrder>))]
        [Route("GetAllOrderByCountryName")]
        public async Task<ActionResult<List<AmazonOrder>>> GetAllOrdersByCountryName(string name)
        {
            try
            {
                var resp = await _amazonBusiness.GetAllOrderByCountry(name);

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


        //SumOfOrderCostByCountryName
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrder>))]
        [Route("GetSumOfOrderCostByCountryName")]
        public async Task<ActionResult<SumOfOrderCost>> SumOfOrdersCostByCountryName(string name)
        {
            try
            {

                var resp = await _amazonBusiness.SumOfOrdersCostByCountryName(name);

                return Ok(resp);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        //GetAllOrderByCreatedDate
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrder>))]
        [Route("GetAllOrderByCreatedDate")]
        public async Task<ActionResult<List<AmazonOrder>>> GetAllOrdersByCreatedDate(DateTime dt)
        {
            try
            {
                var resp = await _amazonBusiness.GetAllOrderByCreatedDate(dt);

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


        //GetAllUserName
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<AmazonOrder>))]
        [Route("GetAllUserName")]
        public async Task<ActionResult<List<string>>> GetAllUserName()
        {
            try
            {
                var resp = await _amazonBusiness.GetAllUserName();

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
    }


}