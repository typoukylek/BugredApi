﻿using NUnit.Framework;
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

        [Test]
        public void TestDoRegisterUserWithEmptyEmail()
        {
            RequestHelper requestHelper = new RequestHelper();
            string email = "";
            string name = Helper.UniqueStringGeneration();
            Dictionary<string, string> body = new Dictionary<string, string>

          {
                { "email", email },
                { "name", name},
                { "password", "Password123" }

            };

            IRestResponse response = requestHelper.RequestSend("/doregister", body);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual(" Некоректный  email ", json["message"]?.ToString());
            Assert.AreEqual(null, json["email"]?.ToString());
            Assert.AreEqual(null, json["name"]?.ToString());
        }

        [Test]
        public void TestCreateUserAllField()// ?
        {
            RequestHelper requestHelper = new RequestHelper();
            CreateUser body = new CreateUser();
            body.adres = Helper.UniqueStringGeneration();
            body.birthday = Helper.UniqueStringGeneration();
            body.cat = Helper.UniqueStringGeneration();
            body.cavy = Helper.UniqueStringGeneration();
            body.date_start = Helper.UniqueStringGeneration();
            body.dog = Helper.UniqueStringGeneration();
            body.email = Helper.UniqueStringGeneration() + "@User.mail";

            //Dictionary<string, string> body = new Dictionary<string, string>

            IRestResponse response = requestHelper.RequestSend("/createuser", body);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("OK", response.StatusCode.ToString());
        }

        [Test]
        public void TestCreateCompanyValid()
        {
            RequestHelper requestHelper = new RequestHelper();
            CreateCompany company = new CreateCompany();
            {
                company.company_name = "TestCompany";
                company.company_type = "ООО";
                new List<string>()
      {
          "somemail@mail.ok",
          "somemail@mail.ok"

                };
                company.email_owner = "apiuzer1@com.ok";
            };

            IRestResponse response = requestHelper.RequestSend("/createcompany", company);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("OK", response.StatusCode.ToString());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void TestCreateuserWithTask()
        {
            RequestHelper requestHelper = new RequestHelper();
            CreateUser body = new CreateUser();
            body.email = "apiuzer1@com.ok";
            body.name = Helper.UniqueStringGeneration();
            body.tasks = new List<string>()

           { "title", "Первая задача",
              "description", "про задачу задача 11"
            };
            IRestResponse response = requestHelper.RequestSend("/createuserwithtasks", body);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("OK", response.StatusCode.ToString());
            Assert.AreEqual(null, json["companies"].ToString());
        }

        [Test]
        public void AddAvatar()
        {
            RequestHelper requestHelper = new RequestHelper();
            CreateUser body = new CreateUser();
            body.email = "apiuzer1@com.ok";
            IRestResponse response = requestHelper.RequestSend("/addavatar/?email=apiuzer1@com.ok.st4", body);
            //JObject json = FileParameter.Create;
            //JObject json = 
        }
    }
}