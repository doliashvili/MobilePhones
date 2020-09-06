using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WandioMobilePhones.Domain.Commands;

namespace WandioMobilePhones.Contollers
{
    [Route("Phone")]
    public class PhoneCommandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhoneCommandController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("AddPhone")]
        public async Task<IActionResult> Add([FromBody] CreatePhone command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("UpdatePhone")]
        public async Task<IActionResult> Update([FromBody] UpdatePhone Command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }

            await _mediator.Send(Command);

            return Ok();
        }

        [HttpDelete("DeletePhone/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }

            await _mediator.Send(new DeletePhone(id));

            return Ok();
        }

        [HttpDelete("RemovePhoneImage")]
        public async Task<IActionResult> Delete([FromBody] RemoveImage command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut("UpdatePhoneName")]
        public async Task<IActionResult> UpdatePhoto([FromBody] UpdatePhoneName comand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }

            await _mediator.Send(comand);

            return Ok();
        }
    }
}
