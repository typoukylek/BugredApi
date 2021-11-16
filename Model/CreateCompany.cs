using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugredApi.Model
{
    class CreateCompany
    {

        [JsonProperty("company_name")]
        public string company_name;

        [JsonProperty("company_type")]
        public string company_type;


        [JsonProperty("company_users")]
        public string company_users;

        [JsonProperty("email_owner")]
        public string email_owner;
    }
}