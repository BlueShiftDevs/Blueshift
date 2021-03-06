﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BlueShift.Data.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string[] Subtypes { get; set; }
        public string[] Text { get; set; }

        public int? ResourceCost { get; set; }
        public int[] EnergyCosts { get; set; }
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
    }
}
