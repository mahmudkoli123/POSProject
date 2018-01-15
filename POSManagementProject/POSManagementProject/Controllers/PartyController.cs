using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.DAL;
using POSManagementProject.Models.EntityModels;
using POSManagementProject.Models.ViewModels;

namespace POSManagementProject.Controllers
{
    public class PartyController : Controller
    {
        PartyVM ModelVm = new PartyVM();
        PartyDAL partyDa = new PartyDAL();
        ImageData imageData = new ImageData();

        // GET: Party
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.Code = partyDa.GetPartyCode();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartyVM itemVm, HttpPostedFileBase ItemCategoryFile)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(ItemCategoryFile);

            if (ModelState.IsValid)
            {
                if (partyDa.IsPartySaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }
            
            ModelVm.Code = partyDa.GetPartyCode();
            return View(ModelVm);
        }
    }
}