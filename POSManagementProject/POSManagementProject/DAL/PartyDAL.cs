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
        public List<CheckBoxModel> GetPartyTypeCheckList()
        {
            var list = new List<CheckBoxModel>()
            {
                new CheckBoxModel(){Id = 1,Name = "Customer",Value = "c",Checked = false},
                new CheckBoxModel(){Id = 2,Name = "Supplier",Value = "s",Checked = false}
            };

            return list;
        }
        public string GetPartyType(List<CheckBoxModel> list)
        {
            var value = "";

            foreach (var li in list)
            {
                if (li.Checked)
                {
                    value = value + li.Value + ",";
                }
            }

            return value.TrimEnd(',');
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
                Type = itemVm.Type,
                Image = itemVm.Image,
                Date = itemVm.Date
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