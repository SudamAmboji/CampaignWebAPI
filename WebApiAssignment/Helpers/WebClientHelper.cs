using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApiAssignment.Helpers
{
    public class WebClientHelper
    {
        public static string GetJsonString()
        {
            string url = "https://testapi.donatekart.com/api/campaign";
            WebClient webClient = new WebClient();
            var jsonData = webClient.DownloadString(url);
            return jsonData;
        }
    }
}