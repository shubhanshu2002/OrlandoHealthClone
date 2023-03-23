using AssesmentSc.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssesmentSc.Controllers
{
    public class CarouselController : Controller
    {
        // GET: Carousel
        public ActionResult Index()
        {
            CarouselModel carouselModel= new CarouselModel();

            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            var dataSource = Sitecore.Context.Database.GetItem(datasourceId);


            var imgField =(ImageField)dataSource.Fields["Image"];

            carouselModel.backImgSrc = MediaManager.GetMediaUrl(imgField.MediaItem);

            var abouttxt = dataSource.Fields["About_Patient"];

            carouselModel.title = abouttxt.ToString();

            MultilistField slides = dataSource.Fields["Slides"];
            
            if(slides != null )
            {
                foreach(var childDataSource in slides.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childDataSource));
                    var title = childItem.Fields["Title"];
                    var subTitle = childItem.Fields["SubTitle"];
                    var CTA =(LinkField)childItem.Fields["CTA"];
                    var imgSrc =(ImageField)childItem.Fields["Image"];
                    var name = childItem.Fields["Name"];
                    carouselModel.slides.Add(new Slides()
                    {
                        Title = title.ToString(),
                        sub_Title= subTitle.ToString(),
                        ctaText = CTA.Text,
                        ctaSrc = CTA.GetFriendlyUrl(),
                        imgSrc = MediaManager.GetMediaUrl(imgSrc.MediaItem),
                        Name= name.ToString(),
                    });
                }
            }
            return View("~/Views/Carousel/CarouselRendering.cshtml", carouselModel);
        }
    }
}