using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Model
{
    public class UserWorkSheet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CostDesc { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalCost { get; set; }
        public string CostInd { get; set; }
    }
}
