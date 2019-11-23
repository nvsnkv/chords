using System.Collections.Generic;
using Chords.Domain.Contract.Data;
using Chords.Domain.Contract.Registry;
using Chords.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chords.Server.Controllers
{
    [ApiController]
    [Route("api/targets")]
    public class TargetsController : ControllerBase
    {
        private IChordTargetsRegistry _targetsRegistry;

        public TargetsController(IChordTargetsRegistry targetsRegistry)
        {
            _targetsRegistry = targetsRegistry;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<IChordTarget> GetTargets()
        {
            return _targetsRegistry.GetItems(Owner.FromPrincipal(User));
        }

        [HttpPut]
        [Authorize]
        public IUniqueItem AddTarget(IChordTarget target)
        {
            return _targetsRegistry.Add(target, Owner.FromPrincipal(User));
        }

        [HttpPost]
        [Authorize]
        public void UpdateTarget(IChordTarget target)
        {
            _targetsRegistry.Update(target, Owner.FromPrincipal(User));
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public void DeleteTarget(string id)
        {
            _targetsRegistry.Delete((UniqueItem)id, Owner.FromPrincipal(User));
        }
    }
}