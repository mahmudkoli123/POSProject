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
    public class OrganizationDAL
    {
        POSDBContext dbContext = new POSDBContext();
        public List<Organization> GetOrganizationList()
        {
            var list = dbContext.Organizations.ToList();
            return list;
        }
        public string GetOrganizationCode()
        {
            long code;

            if (dbContext.Organizations.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Organizations.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:000}", (code + 1));
        }
        public bool IsOrganizationSaved(OrganizationVM itemVm)
        {
            Organization item = new Organization()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Contact = itemVm.Contact,
                Address = itemVm.Address,
                Image = itemVm.Image,
                Date = itemVm.Date
                
            };

            dbContext.Organizations.Add(item);
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