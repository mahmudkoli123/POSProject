using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSManagementProject.Models;
using POSManagementProject.Models.Context;
using POSManagementProject.Models.EntityModels;
using POSManagementProject.Models.ViewModels;

namespace POSManagementProject.DAL
{
    public class PartyDAL
    {
        POSDBContext dbContext = new POSDBContext();
        public List<Party> GetPartyList()
        {
            var list = dbContext.Parties.ToList();
            return list;
        }
        public string GetPartyCode()
        {
            long code;

            if (dbContext.Parties.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Parties.Select(x => x.Code).Max());
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:0000000000}", (code + 1));
        }

        public bool IsPartySaved(PartyVM itemVm)
        {
            Party item = new Party()
            {
                Name = itemVm.Name,
                Code = itemVm.Code,
                Contact = itemVm.Contact,
                Address = itemVm.Address,
                Email = itemVm.Email,
                Image = itemVm.Image,
                Date = itemVm.Date,
                IsCustomer = itemVm.IsCustomer,
                IsSupplier = itemVm.IsSupplier
            };

            dbContext.Parties.Add(item);
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