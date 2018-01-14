using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.DAL;
using POSManagementProject.Models.Context;
using POSManagementProject.Models.EntityModels;
using POSManagementProject.Models.ViewModels;
using System.Net;

namespace POSManagementProject.Controllers
{
    public class ItemCategoryController : Controller
    {
        ItemCategoryDAL itemCategoryDa = new ItemCategoryDAL();
        ItemCategoryVM ModelVm = new ItemCategoryVM();
        ImageData imageData = new ImageData();

        // GET: ItemCategory
        public ActionResult Index()
        {
            ModelVm.ItemCategories = itemCategoryDa.GetItemCategoryList();
            return View(ModelVm.ItemCategories);
        }

        public ActionResult Create()
        {
            ModelVm.SelectList = itemCategoryDa.GetItemCategorySelectList();
            ModelVm.Code = itemCategoryDa.GetItemCategoryCode();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCategoryVM itemVm, HttpPostedFileBase ItemCategoryFile)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(ItemCategoryFile);
            if (ModelState.IsValid)
            {
                if (itemCategoryDa.IsItemCategorySaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.SelectList = itemCategoryDa.GetItemCategorySelectList();
            ModelVm.Code = itemCategoryDa.GetItemCategoryCode();
            return View(ModelVm);
        }
        
        public ActionResult Details(long id)
        {
            ItemCategoryVM itemVm = itemCategoryDa.FindItemCategory(id);
            return PartialView("_Details", itemVm);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ModelVm = itemCategoryDa.FindItemCategory(id);

            if (ModelVm == null)
            {
                return HttpNotFound();
            }
            
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemCategoryVM itemVm)
        {
            if (ModelState.IsValid)
            {
                if (itemCategoryDa.IsItemCategoryUpdated(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(itemVm);
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = itemCategoryDa.IsItemCategoryDeleted(id);

            return Json(isDeleted,JsonRequestBehavior.AllowGet);
        }

    }
}