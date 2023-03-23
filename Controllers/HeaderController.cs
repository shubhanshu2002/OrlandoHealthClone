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
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult Index()
        {
            HeaderModel headermodel = new HeaderModel();

            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            var dataSource = Sitecore.Context.Database.GetItem(datasourceId);

            var logo1 =(ImageField)dataSource.Fields["Logo1"];
            var logo2 = (ImageField)dataSource.Fields["Logo2"];

            headermodel.logo1_src = MediaManager.GetMediaUrl(logo1.MediaItem);
            headermodel.logo2_src = MediaManager.GetMediaUrl(logo2.MediaItem);



            MultilistField nav1 = dataSource.Fields["Navigation1"];

            if(nav1 != null)
            {
                foreach(var childSource in nav1.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(childSource);

                    var cta =(LinkField)childItem.Fields["CTA"];
                    headermodel.navigation1.Add(new Navigation1()
                    {
                        CTA = cta.Text,
                        url= cta.GetFriendlyUrl()
                    });
                }
            }

            MultilistField nav2 = dataSource.Fields["Navigation2"];

            if (nav2 != null)
            {
                foreach (var childSource in nav2.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));

                    var imgField =(ImageField)childItem.Fields["Image"];

                    var cta = (LinkField)childItem.Fields["CTA"];

                    headermodel.navigation2.Add(new Navigation2()
                    {
                        CTA = cta.Text,
                        url = cta.GetFriendlyUrl(),
                        imgSrc = MediaManager.GetMediaUrl(imgField.MediaItem)
                    });
                }
            }




            MultilistField nav3 = dataSource.Fields["Navigation3"];

            if (nav3 != null)
            {
                foreach (var childSource in nav3.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childSource));

                    var cta = (LinkField)childItem.Fields["CTA"];


                    headermodel.navigation3.Add(new Navigation3()
                    {
                        CTA = cta.Text,
                        url = cta.GetFriendlyUrl()
                    });
                }
            }

            return View("~/Views/Header/HeaderRendering.cshtml", headermodel);
        }
    }
}