﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class Expression
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string Result { get; set; }

    }
}