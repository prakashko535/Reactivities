using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities() //returning List of Activity, thats why we used <ActionResult<List<Activity>>>
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id) //returning Activity, thats why we used <ActionResult<Activity>>
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity) // returning nothing thats why we used <IActionResult>
        {
            return Ok(await Mediator.Send(new Create.Command { Activity = activity }));
        }
    }
}



