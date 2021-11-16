using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugredApi
{
    class Helper
    {
        public static string UniqueStringGeneration => DateTime.Now.ToString("ddMMyyyyhhmmss");


        public class HelperUserData
        {
            static public Dictionary<string, string> ValidUserData() => new Dictionary<string, string>()
            {
                {"email", "somemail@mail.ok"},
                {"name", "somename"},
                {"password", "123123"},

            };
        }
    }
}