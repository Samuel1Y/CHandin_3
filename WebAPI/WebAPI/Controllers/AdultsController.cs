using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApplication.Data.Impl.Adults;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdults adults;

        public AdultsController(IAdults adults)
        {
            this.adults = adults;
        }
        //GET
        [HttpGet]
        public async Task<ActionResult<IList<Adult>>>
            GetAdults([FromQuery] int? userId, [FromQuery] string? FirstName,[FromQuery] string? LastName,
                      [FromQuery] string? HairColor,[FromQuery] string? EyeColor,[FromQuery] int? age,
                      [FromQuery] int? Weight, [FromQuery] int? height, [FromQuery] string? Sex, [FromQuery] Job? JobTitle)
        {
            try
            {
                IList<Adult> adults = await this.adults.GetAdultsAsync();
                if (userId != null)
                {
                    adults = adults.Where(adult => adult.Id == userId).ToList();
                }

                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        //DELETE
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await adults.RemoveAdultAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await adults.AddAdultAsync(adult);
                return Created($"/{added.Id}", added); // return newly added to-do, to get the auto generated id
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updatedAdult = await adults.UpdateAdultAsync(adult);
                return Ok(updatedAdult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}