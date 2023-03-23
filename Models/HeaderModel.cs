using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssesmentSc.Models
{
    public class HeaderModel
    {
        public string logo1_src { get; set; }
        public string logo2_src { get; set; }
         public   List<Navigation1> navigation1 { get; set; } = new List<Navigation1>();
        public List<Navigation2> navigation2 { get; set; } = new List<Navigation2>();

        public List<Navigation3> navigation3 { get; set; } = new List<Navigation3>();


    }

    public class Navigation1
    {
        public string CTA { get; set; }
        public string url { get; set; }

    }


    public class Navigation2
    {


        public string imgSrc { get; set; }
        public string CTA { get; set; }
        public string url { get; set; }

    }

    public class Navigation3
    {
        public string CTA { get; set; }
        public string url { get; set; }

    }




}