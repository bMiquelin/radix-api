﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadixAPI.Gateways.Stone
{
    public class OrderResultModel
    {
        public DateTime CreateDate { get; set; }
        public string OrderKey { get; set; }
        public string OrderReference { get; set; }
    }
}
