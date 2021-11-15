using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using BugredApi.Helper;
using Newtonsoft.Json.Linq;
using System.Net;
using System;
using BugredApi.Model;

namespace BugredApi
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDoRegisterAUser()
        {
            RestClient client = new RestClient("http://users.bugred.ru/tasks/rest/doregister")
            {
                Timeout = 300000
            };
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");

            Dictionary<string, string> body = Helper;
            {
                { "email", "1234@somemail.com" },
                { "name", "somename"}

            };

            
   
    request.AddJsonBody(body);

            IRestResponse response = client.Execute(request);

    JObject json = JObject.Parse(response.Content);

    Assert.AreEqual("OK", response.StatusCode.ToString());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(body["email"], json["email"]?.ToString());
        
        }
    }

        private void UniqueStringGeneration()
        {
            throw new NotImplementedException();
        }
    }