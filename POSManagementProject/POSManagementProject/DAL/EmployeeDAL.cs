using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.Models.Context;
using POSManagementProject.Models.EntityModels;
using POSManagementProject.Models.ViewModels;

namespace POSManagementProject.DAL
{
    public class EmployeeDAL
    {
        POSDBContext dbContext = new POSDBContext();
        public IEnumerable<SelectListItem> GetEmployeeBranchSelectList()
        {
            var list = dbContext.Branches.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Address, Value = li.Id.ToString() }));

            return selectList;
        }
        public IEnumerable<SelectListItem> GetEmployeeSelectList()
        {
            var list = dbContext.Employees.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<Employee> GetEmployeeList()
        {
            var list = dbContext.Employees.ToList();
            return list;
        }
        public string GetEmployeeCode()
        {
            long code;

            if (dbContext.Employees.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Employees.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:0000}", (code + 1));
        }
        public bool IsEmployeeSaved(EmployeeVM itemVm)
        {
            Employee item = new Employee()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                BranchId = itemVm.BranchId,
                JoiningDate = itemVm.JoiningDate,
                Image = itemVm.Image,
                Contact = itemVm.Contact,
                Email = itemVm.Email,
                ReferenceId = itemVm.ReferenceId,
                EmergencyContact = itemVm.EmergencyContact,
                NID = itemVm.NID,
                FathersName = itemVm.FathersName,
                MothersName = itemVm.MothersName,
                PresentAddress = itemVm.PresentAddress,
                PermanentAddress = itemVm.PermanentAddress,
                Date = itemVm.Date
            };

            dbContext.Employees.Add(item);
            var isAdded = dbContext.SaveChanges();

            if (isAdded > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}