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
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Index()
        {
            FooterModel footerModel = new FooterModel();

            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            var dataSource = Sitecore.Context.Database.GetItem(datasourceId);

            var imgField = (ImageField)dataSource.Fields["FooterLogo"];

            footerModel.imgsrc = MediaManager.GetMediaUrl(imgField.MediaItem);

            var Copyright = dataSource.Fields["CopyRightText"];

            footerModel.copyRightText = Copyright.ToString();

            MultilistField List1 = dataSource.Fields["List1"];

            if (List1 != null)
            {
                foreach (var childsource in List1.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childsource));

                    var CTA = (LinkField)childItem.Fields["CTA"];

                    footerModel.list1.Add(new ListFooter1()
                    {
                        text = CTA.Text,
                        url = CTA.GetFriendlyUrl()
                    });

                }
            }

            MultilistField List2 = dataSource.Fields["ListLogo2"];

            if (List2 != null)
            {
                foreach (var childsource in List2.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childsource));

                    var img = (ImageField)childItem.Fields["Image"];
                    var CTA = (LinkField)childItem.Fields["CTA"];

                    footerModel.list2.Add(new ListFooter2()
                    {
                        iconSrc = MediaManager.GetMediaUrl(img.MediaItem),
                        cta = CTA.GetFriendlyUrl()
                    });

                }
            }

            MultilistField List3 = dataSource.Fields["List3"];

            if (List3 != null)
            {
                foreach (var childsource in List3.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childsource));

                    var CTA = (LinkField)childItem.Fields["CTA"];

                    footerModel.list3.Add(new ListFooter3()
                    {
                        text = CTA.Text,
                        url = CTA.GetFriendlyUrl()
                    });

                }
            }








            MultilistField List4 = dataSource.Fields["List4"];

            if (List4 != null)
            {
                foreach (var childsource in List4.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childsource));

                    var CTA = (LinkField)childItem.Fields["CTA"];

                    footerModel.list4.Add(new ListFooter4()
                    {
                        text = CTA.Text,
                        url = CTA.GetFriendlyUrl()
                    });

                }
            }



            MultilistField List5 = dataSource.Fields["List5"];

            if (List5 != null)
            {
                foreach (var childsource in List5.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childsource));

                    var CTA = (LinkField)childItem.Fields["CTA"];

                    footerModel.list5.Add(new ListFooter5()
                    {
                        text = CTA.Text,
                        url = CTA.GetFriendlyUrl()
                    });

                }
            }
            return View("~/Views/Footer/FooterRendering.cshtml", footerModel);
        }
    }
}