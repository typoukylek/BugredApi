using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugredApi
{
    public class RequestHelper
    {
        public string BaseUrl = "http://users.bugred.ru/tasks/rest";

        public IRestResponse RequestSend(string path, object body)
        {
            RestClient client = new RestClient(BaseUrl + path)
            {
                Timeout = 300000
            };

            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request);

            return response;
        }

    }
}
