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
    public class BranchDAL
    {
        POSDBContext dbContext = new POSDBContext();
        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            var list = dbContext.Organizations.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<Branch> GetBranchList()
        {
            var list = dbContext.Branches.ToList();
            return list;
        }
        public string GetBranchCode()
        {
            long code;

            if (dbContext.Branches.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Branches.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:000}", (code + 1));
        }
        public bool IsBranchSaved(BranchVM itemVm)
        {
            Branch item = new Branch()
            {
                Code = itemVm.Code,
                Contact = itemVm.Contact,
                Address = itemVm.Address,
                OrganizationId = itemVm.OrganizationId,
                Date = itemVm.Date
            };

            dbContext.Branches.Add(item);
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