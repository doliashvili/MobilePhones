using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WandioMobilePhones.Application.Phone.Dtos;
using WandioMobilePhones.Application.Phone.Queries;

namespace WandioMobilePhones.Contollers
{
    [Route("Phone")]
   public class PhoneQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhoneQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PhoneMobileDto>> GetAll([FromQuery] GetAllPhoneQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("Filter")]
        public async Task<List<PhoneMobileDto>> GetFilteredPhoneMobiles([FromQuery] GetFilteredMobilesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _mediator.Send(new GetPhoneByIdQuery(id));

            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

    }
}
