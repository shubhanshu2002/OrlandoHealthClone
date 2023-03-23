using AssesmentSc.Models;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AssesmentSc.Controllers
{
    public class BulletListController : Controller
    {
        // GET: BulletList
        public ActionResult Index()
        {
           BulletListModel bulletListModel = new BulletListModel();
            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;

            var dataSource = Sitecore.Context.Database.GetItem(datasourceId);

            var title = dataSource.Fields["Title"];

            var description = dataSource.Fields["Description"];

            bulletListModel.Title = title.ToString();
            bulletListModel.Description = description.ToString();

            MultilistField list1 = dataSource.Fields["dataList1"];

            if(list1 != null)
            {
                foreach (var childDataSource in list1.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childDataSource));

                    var CTA =(LinkField)childItem.Fields["CTA"];

                    bulletListModel.data1.Add(new list1()
                    {
                        ctaText = CTA.Text,
                        url = CTA.Url
                    });
                }
            }


            MultilistField list2 = dataSource.Fields["dataList2"];

            if (list2 != null)
            {
                foreach (var childDataSource in list2.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childDataSource));

                    var CTA = (LinkField)childItem.Fields["CTA"];

                    bulletListModel.data2.Add(new list2()
                    {
                        ctaText = CTA.Text,
                        url = CTA.Url
                    });
                }
            }
            MultilistField list3 = dataSource.Fields["dataList3"];

            if (list3 != null)
            {
                foreach (var childDataSource in list3.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childDataSource));

                    var CTA = (LinkField)childItem.Fields["CTA"];

                    bulletListModel.data3.Add(new list3()
                    {
                        ctaText = CTA.Text,
                        url = CTA.Url
                    });
                }
            }

            MultilistField list4 = dataSource.Fields["dataList4"];

            if (list4 != null)
            {
                foreach (var childDataSource in list4.Value.Split('|'))
                {
                    var childItem = Sitecore.Context.Database.GetItem(new ID(childDataSource));

                    var CTA = (LinkField)childItem.Fields["CTA"];

                    bulletListModel.data4.Add(new list4()
                    {
                        ctaText = CTA.Text,
                        url = CTA.Url
                    });
                }
            }




            return View("~/Views/BulletList/BulletListRendering.cshtml", bulletListModel);
        }
    }
}