﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photosharing.Models
{
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string avatar { get; set; }

    }
}