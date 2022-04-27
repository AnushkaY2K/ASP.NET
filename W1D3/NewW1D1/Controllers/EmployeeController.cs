using BusinessLayer;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDotNetCoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBusiness employeeBusiness)
        {
            _logger = logger;
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json", Type = typeof(IEnumerable<EmployeeDto>))]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            try
            {
                var resp = await _employeeBusiness.GetEmployees();

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
        [Produces("application/json", Type = typeof(EmployeeDto))]
        [Route("get-employee")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            try
            {
                var resp = await _employeeBusiness.GetEmployee(id);

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
        [Route("insert-employee")]
        public async Task<ActionResult> InsertEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                await _employeeBusiness.InsertEmployee(employee);
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
        [Route("update-employee")]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeDto employee)
        {
            try
            {
                await _employeeBusiness.UpdateEmployee(employee);
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
        [Route("delete-employee")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeBusiness.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
