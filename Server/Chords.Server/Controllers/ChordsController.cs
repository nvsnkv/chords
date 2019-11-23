using System.Collections.Generic;
using Chords.Domain.Contract.Data;
using Chords.Domain.Contract.Registry;
using Chords.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chords.Server.Controllers
{
    [ApiController]
    [Route("api/chords")]
    public class ChordsController : ControllerBase
    {
        private readonly IChordsRegistry _chordsRegistry;

        public ChordsController(IChordsRegistry chordsRegistry)
        {
            _chordsRegistry = chordsRegistry;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<IChord> GetChords()
        {
            return _chordsRegistry.GetItems(Owner.FromPrincipal(User));
        }

        [HttpGet]
        [Route("{id}")]
        public IChord GetChord(string id)
        {
            return _chordsRegistry.Get((UniqueItem)id, Owner.FromPrincipal(User));
        }

        [HttpPut]
        [Authorize]
        public IUniqueItem AddChord(IChord chord)
        {
            return _chordsRegistry.Add(chord, Owner.FromPrincipal(User));
        }

        [HttpPost]
        [Authorize]
        public void UpdateChord(IChord chord)
        {
            _chordsRegistry.Update(chord, Owner.FromPrincipal(User));
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public void DeleteChord(string id)
        {
            _chordsRegistry.Delete((UniqueItem) id, Owner.FromPrincipal(User));
        }
    }
}
