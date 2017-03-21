using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlueShift.Tools.Web.Models;
using NoDb;

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
        public async Task<object> Get()
        {
            return await cardQueries.GetAllAsync("BlueShift");
        }

        // GET: api/CardData/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<object> Get(int id)
        {
            return await cardQueries.FetchAsync("BlueShift", id.ToString());
        }
        
        // POST: api/CardData
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/CardData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
