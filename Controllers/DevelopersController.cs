using Microsoft.AspNetCore.Mvc;

namespace JashariDenisLB_295_V2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevelopersController : ControllerBase
    {
        private static List<Developer> developers = new List<Developer>();

        // GET: /developers
        [HttpGet]
        public ActionResult<List<Developer>> GetAllDevelopers()
        {
            return Ok(developers);
        }

        // POST: /developers
        [HttpPost]
        public ActionResult<Developer> CreateDeveloper([FromBody] Developer developer)
        {
            developers.Add(developer);
            return CreatedAtAction(nameof(GetDeveloperById), new { developerId = developer.DeveloperId }, developer);
        }

        // GET: /developers/{developerId}
        [HttpGet("{developerId}")]
        public ActionResult<Developer> GetDeveloperById(int developerId)
        {
            var developer = developers.FirstOrDefault(d => d.DeveloperId == developerId);
            if (developer == null)
            {
                return NotFound();
            }
            return Ok(developer);
        }

        // PUT: /developers/{developerId}
        [HttpPut("{developerId}")]
        public ActionResult UpdateDeveloper(int developerId, [FromBody] Developer developerUpdate)
        {
            var developer = developers.FirstOrDefault(d => d.DeveloperId == developerId);
            if (developer == null)
            {
                return NotFound();
            }
            developer.Name = developerUpdate.Name;
            developer.ContactInfo = developerUpdate.ContactInfo;
            developer.Speciality = developerUpdate.Speciality;
            return NoContent();
        }

        // DELETE: /developers/{developerId}
        [HttpDelete("{developerId}")]
        public ActionResult DeleteDeveloper(int developerId)
        {
            var developer = developers.FirstOrDefault(d => d.DeveloperId == developerId);
            if (developer == null)
            {
                return NotFound();
            }
            developers.Remove(developer);
            return NoContent();
        }
    }
}
