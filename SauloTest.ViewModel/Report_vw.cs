using System;
using System.Collections.Generic;

namespace SauloTest.ViewModel
{
    public class DataReport_vw
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public string Details => $"Name: {Name} has {Quantity}"; 
    }

    public class Report_vw
    {
        public IReadOnlyCollection<DataReport_vw> Data { get; set; }

        public Report_vw(List<DataReport_vw> all)
        {
            this.Data = all;
        }
    }
}
