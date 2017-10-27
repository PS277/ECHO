using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core;
using Pokedex.Core.Models;

namespace Pokedex.Controllers
{
    [Produces("application/json")]
    [Route("api/Pokedex")]
    public class PokedexController : SessionController
    {
        ObjectResult Display(object Value) => new ObjectResult(Value);
        bool Exists(string Id) => Session.Load<Pokemon>(Id) == null ? true : false;

        [HttpGet]
        public ActionResult DisplayPokemons()
        {
            var Load = Session.Query<Pokemon>().Customize(x => x.WaitForNonStaleResults()).ToList();
            if (!Load.Any())
                return NotFound(APICodes.EmptyPokedex);
            return Display(Load);
        }

        [HttpGet("{Id}", Name = "PokeById")]
        public ActionResult PokeById(string Id)
        {
            var Load = Session.Load<Pokemon>(Id);
            if (Load == null)
                return NotFound(APICodes.PokeNotFound + Id);
            return Display(Load);
        }

        [HttpPost]
        public ActionResult AddPokemon([FromBody]Pokemon NewPokemon)
        {
            if (Exists(NewPokemon.Id))
                try
                {
                    Session.Store(NewPokemon, NewPokemon.Id);
                    return Ok(APICodes.PokeAdded + NewPokemon.Id);
                }
                catch (Exception Ex)
                {
                    return View(Ex);
                }
            else
                return BadRequest("Already Exists");
        }

        [HttpPut("{Id}")]
        public ActionResult UpdatePokemon(string Id, [FromBody]Pokemon PokeToUpdate)
        {
            if (Exists(Id))
            {
                var Load = Session.Load<Pokemon>(Id);
                Load = PokeToUpdate;
                Session.Store(Load);
                return Ok(APICodes.PokeUpdated + Id);
            }
            else
                return BadRequest(APICodes.PokeNotFound + Id);
        }

        [HttpDelete("{Id}")]
        public void Delete(string Id)
        {

        }
    }
}