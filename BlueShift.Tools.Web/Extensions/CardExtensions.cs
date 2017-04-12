using BlueShift.Tools.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueShift.Tools.Web.Extensions
{
    public static class CardExtensions
    {
        public static Card UpdateWith(this Card original, Card card)
        {
            if (card == null) return original;

            original.ActionCost = card.ActionCost ?? original.ActionCost;
            original.Burn = card.Burn ?? original.Burn;
            original.Control = card.Control ?? original.Control;
            original.Exploits = card.Exploits ?? original.Exploits;
            original.Faction = card.Faction ?? original.Faction;
            original.FleetDeckSize = card.FleetDeckSize ?? original.FleetDeckSize;
            original.Hull = card.Hull ?? original.Hull;
            original.Icons = card.Icons ?? original.Icons;
            original.MaxCopies = card.MaxCopies ?? original.MaxCopies;
            original.Name = card.Name ?? original.Name;
            original.Reactor = card.Reactor ?? original.Reactor;
            original.ResourceCost = card.ResourceCost ?? original.ResourceCost;
            original.ScannerSize = card.ScannerSize ?? original.ScannerSize;
            original.ShipSelections = card.ShipSelections ?? original.ShipSelections;
            original.StrategyDeckSize = card.StrategyDeckSize ?? original.StrategyDeckSize;
            original.StrategyRefresh = card.StrategyRefresh ?? original.StrategyRefresh;
            original.Subtypes = card.Subtypes ?? original.Subtypes;
            original.Text = card.Text ?? original.Text;
            original.Title = card.Title ?? original.Title;
            original.Type = card.Type ?? original.Type;

            return original;
        }
    }
}
