﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUsModel.Models
{
    public class ResponseModel
    {
        public bool success { get; set; }
        public string message { get; set; }
        public int code { get; set; }
    }
}
