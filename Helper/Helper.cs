﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugredApi.Helper
{
   public class Helper
    {
        public static string UniqueStringGeneration()
        {
            return DateTime.Now.ToString("ddMMyyyyhhmmss");
        }
    }
}