using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssesmentSc.Models
{
    public class BulletListModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public List<list1> data1 { get; set; } = new List<list1>();
        public List<list2> data2 { get; set; } = new List<list2>();

        public List<list3> data3 { get; set; } = new List<list3>();
        public List<list4> data4 { get; set; } = new List<list4>();

    }

    public class list1
    {
        public string url { get; set; }
        public string ctaText {get; set; }  
    }
    public class list2
    {
        public string url { get; set; }
        public string ctaText { get; set; }
    }
    public class list3
    {
        public string url { get; set; }
        public string ctaText { get; set; }
    }
    public class list4
    {
        public string url { get; set; }
        public string ctaText { get; set; }
    }


}