using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using WebApiAssignment.Models;
using WebApiAssignment.Helpers;

namespace WebApiAssignment.Controllers
{
    public class CampaignController : ApiController
    {
        //Endpoint-1
        //Get the list of campaigns sorted by Total Amount in descending order

        [Route("api/Campaign/GetCampaignByHighestTotalAmount")]
        public IEnumerable<ResultCampaign> GetCampaignByHighestTotalAmount()
        {
            var campaignDetails = JsonConvert.DeserializeObject<List<Campaign>>(WebClientHelper.GetJsonString());
            int countCampaignItems = campaignDetails.Count();

            List<ResultCampaign> campaignResult = new List<ResultCampaign>();

            for (int i = 0; i < countCampaignItems; i++)
            {
                ResultCampaign tempResultCampaign = new ResultCampaign
                {
                    Title = campaignDetails[i].Title,
                    TotalAmount = campaignDetails[i].TotalAmount,
                    BackersCount = campaignDetails[i].BackersCount,
                    EndDate = DateTime.Parse(campaignDetails[i].EndDate)
                };
                campaignResult.Add(tempResultCampaign);
            }
            IEnumerable<ResultCampaign> sortedCampaign = campaignResult.OrderByDescending(x => x.TotalAmount).ToList();
            return sortedCampaign;
        }


        //Endpoint-2
        //get active campaigns that are created within the last 1 month. 
        //A campaign is active if the end date is greater than or equal to today.
        //Filter the list further to get the campaigns that are created within the last 30 days.
        [Route("api/Campaign/GetActiveCampaignsCreatedLastMonth")]
        public IEnumerable<Campaign> GetActiveCampaignsCreatedLastMonth()
        {
            var campaignDetails = JsonConvert.DeserializeObject<List<Campaign>>(WebClientHelper.GetJsonString());
            int countCampaignItems = campaignDetails.Count();

            List<Campaign> listCampaign = new List<Campaign>();

            bool IsActiveCampaign = false;
            bool IsCreatedWithinLastMonth = false;

            for (int i = 0; i < countCampaignItems; i++)
            {
                if (DateTime.Parse(campaignDetails[i].EndDate) >= DateTime.Today)
                {
                    IsActiveCampaign = true;
                }
                if (DateTime.Parse(campaignDetails[i].Created) > (DateTime.Today.AddDays(-30)))
                {
                    IsCreatedWithinLastMonth = true;
                }

                if (IsActiveCampaign && IsCreatedWithinLastMonth)
                {
                    listCampaign.Add(campaignDetails[i]);
                }
                IsActiveCampaign = false;
                IsCreatedWithinLastMonth = false;
            }
            return listCampaign;
        }

        //Endpoint-3
        //get closed campaigns.
        //A campaign is closed if the end date is less than today, or Procured Amount is greater than or equal to Total Amount.

        [Route("api/Campaign/GetClosedCampaigns")]
        public IEnumerable<Campaign> GetClosedCampaigns()
        {
            var campaignDetails = JsonConvert.DeserializeObject<List<Campaign>>(WebClientHelper.GetJsonString());
            int countCampaignItems = campaignDetails.Count();

            List<Campaign> listCampaign = new List<Campaign>();

            bool IsClosedCampaign = false;

            for (int i = 0; i < countCampaignItems; i++)
            {
                if ((DateTime.Parse(campaignDetails[i].EndDate) < DateTime.Today) ||(campaignDetails[i].ProcuredAmount >= campaignDetails[i].TotalAmount))
                {
                    IsClosedCampaign = true;
                }
               
                if (IsClosedCampaign)
                {
                    listCampaign.Add(campaignDetails[i]);
                }
                IsClosedCampaign = false;
            }
            return listCampaign;
        }
    }
}
