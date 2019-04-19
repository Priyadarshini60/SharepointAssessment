using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QWERTY.Models;

using RestSharp;
using Value = QWERTY.Models.Value;

namespace QWERTY.Controllers
{
    public class SharepointController : Controller
    {
        //: Sharepoint
        
        public ActionResult index()
        {

            var uri = "https://login.microsoftonline.com/e8066575-08c8-448e-ae40-9ef77360c48d/oauth2/v2.0/token";
            RestClient client1 = new RestClient(uri);
            RestRequest request = new RestRequest("", Method.POST);
            request.AddParameter("grant_type", "password");
            request.AddParameter("client_id", "c8525a39-e00c-4e99-9a1b-2fcf9abd3847");
            request.AddParameter("client_secret", "bsVvnPJXhBeFmlB9UNvFAP/gYr1l2jUjeI95cj+GS+c=");
            request.AddParameter("scope", "https://graph.microsoft.com/.default");
            request.AddParameter("callback_url", "https://batestazure.azurewebsites.net");
            request.AddParameter("auth_url", "https://login.microsoftonline.com/e8066575-08c8-448e-ae40-9ef77360c48d/oauth2/authorize?resource=https://graph.microsoft.com");
            request.AddParameter("username", "y.khetan@balance.nl");
            request.AddParameter("password", "Detron@ICT");

            IRestResponse response1 = client1.Execute(request);
            var dyn = JsonConvert.DeserializeObject(response1.Content);
            var str = dyn.ToString();
            var jArray = Newtonsoft.Json.Linq.JObject.Parse(str);
            var AccessToken = jArray["access_token"].ToString();


            using (WebClient httpClient = new WebClient())
            {
                httpClient.Headers.Add("Authorization", AccessToken);

                var jsonData = httpClient.DownloadString("https://graph.microsoft.com/beta/sites/balancenl.sharepoint.com,79568886-65b6-4fa7-9da1-0daabbed66d8,124611c0-0d55-492c-be36-9baa04cb17b9/pages/");

                var item = JsonConvert.DeserializeObject<OdataObject<Value>>(jsonData);
                
                return View("abc", item.Value); 
            }
           
        }

    }
}

    
      
