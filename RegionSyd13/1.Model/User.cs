﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._1.Model
{
    public class User
    {
        public int UserID { get; set; }
        public int RegionID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}