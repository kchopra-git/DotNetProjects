using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Data;
using UserRegistration.Model;


namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            return await _context.registrations.ToListAsync();
        }

        // GET: api/
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.registrations.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        // POST: api/Registration
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {   
            LoginModels login=new LoginModels();
           

            _context.registrations.Add(registration);

            await _context.SaveChangesAsync();
            login.UserEmail = registration.UserEmail;
            login.password = registration.password;
            _context.loginModel.Add(login);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRegistration", new { id = registration.UserId }, registration);
        }


        // PUT: api/Registration/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(int id, Registration registration)
        {
            if (id != registration.UserId)
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                //_context.registrations.Update(registration);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRegistration", new { id = registration.UserId }, registration);
        }

        // DELETE: api/Registration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var registration = await _context.registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.registrations.Remove(registration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrationExists(int id)
        {
            return _context.registrations.Any(e => e.UserId == id);
        }
    }
}
