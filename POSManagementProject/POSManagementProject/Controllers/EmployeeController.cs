using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.DAL;
using POSManagementProject.Models.ViewModels;

namespace POSManagementProject.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeVM ModelVm = new EmployeeVM();
        EmployeeDAL employeeDa = new EmployeeDAL();
        ImageData imageData = new ImageData();

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ModelVm.Code = employeeDa.GetEmployeeCode();
            ModelVm.SelectListBranch = employeeDa.GetEmployeeBranchSelectList();
            ModelVm.SelectListReference = employeeDa.GetEmployeeSelectList();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM itemVm,HttpPostedFileBase ItemCategoryFile)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(ItemCategoryFile);

            if (ModelState.IsValid)
            {
                if (employeeDa.IsEmployeeSaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.Code = employeeDa.GetEmployeeCode();
            ModelVm.SelectListBranch = employeeDa.GetEmployeeBranchSelectList();
            ModelVm.SelectListReference = employeeDa.GetEmployeeSelectList();
            return View(ModelVm);
        }

    }
}