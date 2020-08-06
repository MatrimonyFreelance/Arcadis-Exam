using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class ExampleWorkSheet
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Cost { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalCost { get; set; }
        public string CostInd { get; set; }
    }
}
