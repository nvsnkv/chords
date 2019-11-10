using System.Collections.Generic;
using System.Linq;
using Chords.Server.Model.Chords;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Chords.Server.Controllers
{
    [ApiController]
    [Route("api/chords")]
    public class ChordsController : ControllerBase
    {
        private readonly ILogger<ChordsController> _logger;

        public ChordsController(ILogger<ChordsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Chord> GetChords()
        {
            return Enumerable.Empty<Chord>();
        }

        [HttpGet]
        [Route("{id}")]
        public Chord GetChord(string id)
        {
            return null;
        }

        [HttpPut]
        public void AddChord(Chord chord)
        {
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteChord(string id)
        {
        }

        [HttpPost]
        public void Touch(Chord chord)
        {
        }

    }
}
