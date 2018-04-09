using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UAT_TESTINGS.Models
{
    public class USERDETAILS
    {
        public string SearchNamee
        {
            get;
            set;
        }

        [Required(ErrorMessage = "BatchName Is Required")]
        public string BatchName
        {
            get;
            set;
        }


        public DateTime BatchStartDate
        {
            get;
            set;
        }

        public DateTime BatchEndDate
        {
            get;
            set;
        }
        public DateTime PreferedAssessmentDate
        {
            get;
            set;
        }

        public IEnumerable<USERDETAILS> oUserList { get; set; }
    }
}