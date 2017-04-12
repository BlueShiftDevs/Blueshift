using System;
using System.Collections.Generic;
using System.Text;

namespace BlueShift.Tools.Web.Models
{
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string[] Subtypes { get; set; }
        public string[] Text { get; set; }
        public string Faction { get; set; }

        public int? ResourceCost { get; set; }
        public string[] ShipSelections { get; set; }
        public string ActionCost { get; set; }
        public string[] Icons { get; set; }
        public int? Burn { get; set; }

        public int? Control { get; set; }
        public int? Hull { get; set; }
        public int? Exploits { get; set; }
        public int? Reactor { get; set; }

        public int? FleetDeckSize { get; set; }
        public int? MaxCopies { get; set; }
        public int? StrategyDeckSize { get; set; }
        public int? StrategyRefresh { get; set; }
        public string ScannerSize { get; set; }

        //move these to separate services/models later
        public string Comments { get; set; }
    }
}
