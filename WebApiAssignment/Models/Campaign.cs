using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiAssignment.Models
{
    public class Campaign
    {
        public string Code { get; set; }

        public string Title { get; set; }

        public bool Featured { get; set; }

        public int Priority { get; set; }

        public string ShortDesc { get; set; }

        public string ImageSrc { get; set; }

        public string Created { get; set; }

        public string EndDate { get; set; }

        public double TotalAmount { get; set; }

        public double ProcuredAmount { get; set; }

        public double TotalProcured { get; set; }

        public float BackersCount { get; set; }

        public int CategoryId { get; set; }

        public string Location { get; set; }

        public string NgoCode { get; set; }

        public string NgoName { get; set; }

        public int DaysLeft { get; set; }

        public double Percentage { get; set; }
    }
}