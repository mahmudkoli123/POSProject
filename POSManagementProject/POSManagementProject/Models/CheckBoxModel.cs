using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSManagementProject.Models
{
    public class CheckBoxModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Checked { get; set; }
    }
}