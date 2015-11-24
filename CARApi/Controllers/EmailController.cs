using CAR.DAL;
using CAR.PE.Models;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CAR.PL.Controllers
{
    public class EmailController : ApiController
    {
        // POST: api/Email
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post(EmailModel email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(string.IsNullOrWhiteSpace(email.Email))
            {
                return BadRequest("Email cannot be empty.");
            }

            EmailRepository emailRepository = new EmailRepository();

            if(emailRepository.EmailExists(email.Email))
            {
                return BadRequest("Email is already registered.");
            }
            
            await emailRepository.Add(email.Email);

            return Ok(email);
        }
    }
}