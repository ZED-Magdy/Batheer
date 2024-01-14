using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batheer.Application.Families.Commands.CreateFamily;
using Batheer.Application.Families.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Batheer.WebUI.Areas.Api
{
    [Area("api/associationsAffiliated/{controller}")]
    public class ManageFamiliesController : ApiControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<Batheer.Application.Families.Queries.GetById.FamilyDetailsDto>> Get(int id)
        {
            var dto = await Mediator.Send(new GetByIdQuery(id));

            if (dto is null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateFamilyCommand command)
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                //command.AssociationAffiliatedId = _currentUserService.CouncilId;
                id = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return CreatedAtAction(nameof(Get), new { id }, null);
        }

    }
}
