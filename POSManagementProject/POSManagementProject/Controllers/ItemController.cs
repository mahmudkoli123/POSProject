using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.DAL;
using POSManagementProject.DAL;
using POSManagementProject.Models.ViewModels;

namespace POSManagementProject.Controllers
{
    public class ItemController : Controller
    {
        ItemVM ModelVm = new ItemVM();
        ItemDAL itemDa = new ItemDAL();
        ImageData imageData = new ImageData();

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.SelectList = itemDa.GetItemSelectList();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemVM itemVm, HttpPostedFileBase ItemCategoryFile)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(ItemCategoryFile);

            if (ModelState.IsValid)
            {
                if (itemDa.IsItemSaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.SelectList = itemDa.GetItemSelectList();
            return View(ModelVm);
        }
    }
}