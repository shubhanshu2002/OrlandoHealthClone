using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AssesmentSc.Models
{
    public class FooterModel
    {
        public string imgsrc { get; set; }
        public string copyRightText { get; set; }

        public List<ListFooter1> list1 { get; set; } = new List<ListFooter1>();
        public List<ListFooter2> list2 { get; set; } = new List<ListFooter2>();
        public List<ListFooter3> list3 { get; set; } = new List<ListFooter3>();
        public List<ListFooter4> list4 { get; set; } = new List<ListFooter4>();
        public List<ListFooter5> list5 { get; set; } = new List<ListFooter5>(); 

    }

    public class ListFooter1 {
    
        public string url { get; set;}
        public string text { get; set;}
    }

    public  class ListFooter2
    {
        public string iconSrc { get; set; }
        public string cta { get; set; }
    }
    public class ListFooter3
    {

        public string url { get; set; }
        public string text { get; set; }
    }
    public class ListFooter4
    {

        public string url { get; set; }
        public string text { get; set; }
    }
    public class ListFooter5
    {

        public string url { get; set; }
        public string text { get; set; }
    }


}