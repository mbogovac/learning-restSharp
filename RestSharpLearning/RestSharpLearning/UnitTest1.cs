using Dynamitey.DynamicObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using RestSharp.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace RestSharpLearning
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public string TestMethod1()
        {
            var client = new RestClient("http://localhost:3000/");

            var request = new RestRequest("posts/{postid}", Method.Get);
            request.AddUrlSegment("postid", 1);

            var response = client.Execute(request);

            //ovo ne radi
            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["author"];

            JObject obs = JObject.Parse(response.Content);
            return obs[response].ToString();
        }
    }
}
