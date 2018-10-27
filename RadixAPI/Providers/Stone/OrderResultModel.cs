using System;

namespace RadixAPI.Providers.Stone
{
    public class OrderResultModel
    {
        public DateTime CreateDate { get; set; }
        public string OrderKey { get; set; }
        public string OrderReference { get; set; }
    }
}
