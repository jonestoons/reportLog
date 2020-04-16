﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reportLog.Models.DataModels
{
    public class CompanyCustomer : BaseClass
    {
        public int CompanyID { get; set; }
        public string FullName { get; set; }
        public string AltCode { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public string AreaCode { get; set; }
    }
}