using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Net;
using System;
using BugredApi.Model;


namespace BugredApi
{
    public class Tests
    {

        [Test]
        public void TestDoRegisterAUser()
        {
            RequestHelper requestHelper = new RequestHelper();
            string email = Helper.UniqueStringGeneration() + "@someEmail.com";
            string name = Helper.UniqueStringGeneration();
            Dictionary<string, string> body = new Dictionary<string, string>

            {
                { "email", email },
                { "name", name},
                { "password", "Password123" }

            };


            IRestResponse response = requestHelper.RequestSend("/doregister", body);

            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("OK", response.StatusCode.ToString());
            Assert.AreEqual(body["email"], json["email"]?.ToString());
            Assert.AreEqual(body["name"], json["name"]?.ToString());

        }
    }
}




//[Test]
//public void DoRegisterWithNoEmail()
//{

//    {
//        Timeout = 300000
//    };
//    RestRequest request = new RestRequest(Method.POST);
//    request.AddHeader("content-type", "application/json");


//    request.AddJsonBody(body);

//    IRestResponse response = client.Execute(request);

//    JObject json = JObject.Parse(response.Content);

//    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

//    Assert.AreEqual("error", json["type"]?.ToString());
//    Assert.AreEqual(" Некоректный  email ", json["message"]?.ToString());
//    Assert.AreEqual(null, json["email"]?.ToString());
//    Assert.AreEqual(null, json["name"]?.ToString());
//}



