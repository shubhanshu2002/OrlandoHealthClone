using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssesmentSc.Models
{
    public class CarouselModel
    {
        public string backImgSrc {get; set;}
        public string title { get; set;}
        public List<Slides> slides { get; set; } = new List<Slides>();


    }
    public class Slides
    {
        public string Title { get; set;}
        public string sub_Title { get; set; }

        public string ctaText { get; set; }

        public string ctaSrc { get; set; }

        public string imgSrc { get; set; }

        public string Name { get; set; }

    }


}