using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stocks_api.Models
{
    public class GlobalQuotes
    {
        public string symbol { get; set; }

        public float open { get; set; }

        public float high { get; set; }

        public float low { get; set; }

        public decimal price { get; set; }

        public decimal volume { get; set; }

        public string latesttradingday { get; set; }

        public float previousclose { get; set; }

        public float change { get; set; }

        public string changepercent { get; set; }
    }
}
