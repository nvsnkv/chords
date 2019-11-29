using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Chords.Server.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public ChallengeResult Login([FromQuery] string redirect)
        {
            return new ChallengeResult(new AuthenticationProperties(){RedirectUri = redirect ?? string.Empty });
        }
    }
}