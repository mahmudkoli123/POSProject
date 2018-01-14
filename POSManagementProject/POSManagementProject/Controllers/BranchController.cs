using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.DAL;
using POSManagementProject.Models.ViewModels;

namespace POSManagementProject.Controllers
{
    public class BranchController : Controller
    {
        BranchVM ModelVm = new BranchVM();
        BranchDAL branchDa = new BranchDAL();

        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.SelectList = branchDa.GetBranchSelectList();
            ModelVm.Code = branchDa.GetBranchCode();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BranchVM itemVm)
        {
            itemVm.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (branchDa.IsBranchSaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.SelectList = branchDa.GetBranchSelectList();
            ModelVm.Code = branchDa.GetBranchCode();
            return View(ModelVm);
        }
    }
}