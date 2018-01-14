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
    public class OrganizationController : Controller
    {
        OrganizationVM ModelVm = new OrganizationVM();
        OrganizationDAL organizationDa = new OrganizationDAL();
        ImageData imageData = new ImageData();

        // GET: Organization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.Code = organizationDa.GetOrganizationCode();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationVM itemVm, HttpPostedFileBase ItemCategoryFile)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(ItemCategoryFile);
            if (ModelState.IsValid)
            {
                if (organizationDa.IsOrganizationSaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }
            
            ModelVm.Code = organizationDa.GetOrganizationCode();
            return View(ModelVm);
        }

    }
}