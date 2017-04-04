using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlueShift.Tools.Web.Models;
using NoDb;
using Newtonsoft.Json;
using BlueShift.Tools.Web.Extensions;

namespace BlueShift.Tools.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/CardData")]
    public class CardDataController : Controller
    {
        IBasicCommands<Card> cardCommands;
        IBasicQueries<Card> cardQueries;

        public CardDataController(
            IBasicCommands<Card> cardCommands,
            IBasicQueries<Card> cardQueries)
        {
            this.cardCommands = cardCommands;
            this.cardQueries = cardQueries;

            //temp code to populate DB
            //cardCommands.UpdateAsync("BlueShift", "1", new Card {
            //    Name = "Club Asteroid",
            //    Id = 1,
            //    Title = "Slammin Spaceclub",
            //    Type = "Asset",
            //    Subtypes = new[] { "Station", "Opulent" },
            //    ResourceCost = 2,
            //    Icons = new[] { "Exploit", "Maneuver" },
            //    Burn = 1,
            //    Control = 1,
            //    Hull = 4,
            //    MaxCopies = 1,
            //    Text = new[] { "Cycle -> Gain $1 for each Aristocrat on this.", "Aristocrats may be deployed here." }
            //});
            //cardCommands.UpdateAsync("BlueShift", "2", new Card {
            //    Name = "Radiation Blast",
            //    Id = 2,
            //    Type = "Event",
            //    Subtypes = new[] { "Tactic" },
            //    ResourceCost = 4,
            //    ActionCost = "Activate",
            //    ShipSelections = new[] { "Mandatory" },
            //    Burn = 2,
            //    Text = new[] { "Spend up to %3, then deal that much DMG to all targets here." }
            //});
            //cardCommands.CreateAsync("BlueShift", "3", new Card { Name = "From Db 3", Id = 3, Title = "Sweet Dude" });
        }

        // GET: api/CardData
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await cardQueries.GetAllAsync("BlueShift"));
        }

        // GET: api/CardData/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var card = await cardQueries.FetchAsync("BlueShift", id);

            return card != null ? (IActionResult)Ok(card) : BadRequest(new { error = $"Card with id [{id}] does not exist. You must create a card with this id to retrieve it." });
        }

        // POST: api/CardData
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]object value)
        {
            var card = JsonConvert.DeserializeObject<Card>(value.ToString());

            if (card != null)
            {
                if ((await cardQueries.FetchAsync("BlueShift", card.Id)) != null)
                    return BadRequest(new { error = $"Card with id [{card.Id}] already exists. You must update the existing card or choose a new id." });

                await cardCommands.CreateAsync("BlueShift", card.Id, card);
                return Ok();
            }
            return BadRequest(new { error = "Improperly formatted POST body" });
        }

        // PUT: api/CardData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]object value)
        {
            try
            {
                var original = await cardQueries.FetchAsync("BlueShift", id);
                if (original == null) return BadRequest(new { error = $"Card with id [{id}] does not exist. You must create a new card or update a card with an existing id." });
                
                var card = JsonConvert.DeserializeObject<Card>(value.ToString());
                await cardCommands.UpdateAsync("BlueShift", id, original.UpdateWith(card));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if ((await cardQueries.FetchAsync("BlueShift", id)) != null)
            {
                await cardCommands.DeleteAsync("BlueShift", id);
                return Ok();
            }
            return BadRequest(new { error = $"Card with id [{id}] does not exist. You can only delete existing cards." });
        }
    }
}
