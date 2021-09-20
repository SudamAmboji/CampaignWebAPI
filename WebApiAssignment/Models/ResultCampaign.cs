using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssignment.Models
{
    public class ResultCampaign
    {
        public string Title { get; set; }

        public double TotalAmount { get; set; }

        public float BackersCount { get; set; }

        public DateTime EndDate { get; set; }
    }
}