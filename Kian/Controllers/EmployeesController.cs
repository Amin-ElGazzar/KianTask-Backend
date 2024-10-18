using Kian.Features.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerMain
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetEmployeeQuery());
            return GetResponse(result);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            return GetResponse(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand() { Id = id });
            return GetResponse(result);
        }

        [HttpPut("ActiveEmployee")]
        public async Task<IActionResult> ActiveEmployee([FromBody] ActiveEmployeeCommand request)
        {
            var result = await _mediator.Send(request);
            return GetResponse(result);
        }
    }
}
