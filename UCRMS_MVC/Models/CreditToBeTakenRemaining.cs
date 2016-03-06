using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCRMS_MVC.Models
{
    public class CreditToBeTakenRemaining
    {
        public int Id { get; set; }
        public double CreditToBeTaken { get; set; }
        public double CreditRemaining { get; set; }
    }
}