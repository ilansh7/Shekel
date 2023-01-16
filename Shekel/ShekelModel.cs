using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;

namespace Shekel
{
    public class ShekelModel
    {
        #region c'tor
        public ShekelModel()
        {
            //throw new NotImplementedException();
            this.customerId = "0";
            this.customerName = null;
        }
        #endregion c'tor
        
        //public string JavascriptToRun { get; set; }
        [Display(Name = "ת.ז.")]
        public string customerId { get; set; }
        [Display(Name = "שם לקוח")]
        public string customerName { get; set; }
        [Display(Name = "כתובת")]
        public string customerAddress { get; set; }
        [Display(Name = "טלפון")]
        public string customerPhone { get; set; }
        public int groupCode { get; set; }
        public int factoryCode { get; set; }
        //public bool CanBeDeleted { get; set; }
    }
}