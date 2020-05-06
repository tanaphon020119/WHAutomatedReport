using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Models
{
    public class ReportChartViewModel
    {
        public string SMCreateDate { get; set; }
        public int NumberofSM { get; set; }
        
    }

    public class BarChartData
    {
        public string[] labels { get; set; }
        public BarChartDataSet[] datasets { get; set; }
    }

    public class BarChartDataSet
    {
        public string type { get; set; }
        public string label { get; set; }
        public double[] data { get; set; }
        public string[] backgroundColor { get; set; }
        public string[] borderColor { get; set; }
        public int borderWidth { get; set; }       
    }
}