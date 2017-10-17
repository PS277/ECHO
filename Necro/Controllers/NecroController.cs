using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Necro.Models;

namespace Necro.Controllers
{
    [Route("api/Necro")]
    public class NecroController : SessionController
    {
        [HttpGet]
        public IEnumerable<NecroModel> Get() => Session.Query<NecroModel>().Customize(x => x.WaitForNonStaleResults());

        [HttpGet("{Id}", Name ="GetNecro")]
        public NecroModel GetById(string Id) => Session.Load<NecroModel>($"NECRO-{Id}");


        [HttpPost]
        public IActionResult Post([FromBody] NecroModel _Necro)
        {
            if (_Necro == null)
                return BadRequest("Can't post null data.");
            Session.Store(_Necro);
            return CreatedAtRoute("GetNecro", new { Id = _Necro.NecroId }, _Necro);
        }
    }
}
