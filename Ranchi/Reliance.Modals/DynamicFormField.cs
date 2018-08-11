using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace Reliance.Modals
{

    public class TextBoxViewModel 
    {   
        #region private variable
        private string fieldId = "";
        private string values = "";
        private string fieldMapping="";
           #endregion
        #region public properties
     
        public string FieldId
        {
            get
            {
                return fieldId;
            }
            set
            {
                fieldId = value;
            }
        }      
        public string  Value
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
            }
        }
        public string FieldMapping
        {
            get
            {
                return fieldMapping;
            }
            set
            {
                fieldMapping = value;
            }
        }
        public int IdentityId { get; set; }

        #endregion
    }
    public class TextBoxList :List<TextBoxViewModel>{
        public TextBoxList() 
        { }
    }
    public  class DynamicControlsBase
    {
        private string txt1 = "";
        private string txt2 = "";
        private string txt3 = "";
        private string txt4 = "";
        private string txt5 = "";

        public string Txt1
        {
            get
            {
                return txt1;
            }
            set
            {
                txt1 = value;
            }
        }
        public string Txt2
        {
            get
            {
                return txt2;
            }
            set
            {
                txt2 = value;
            }
        }
        public string Txt3
        {
            get
            {
                return txt3;
            }
            set
            {
                txt3 = value;
            }
        }
        public string Txt4
        {
            get
            {
                return txt4;
            }
            set
            {
                txt4 = value;
            }
        }
        public string Txt5
        {
            get
            {
                return txt5;
            }
            set
            {
                txt5 = value;
            }
        }
    }
    public class DynamicControlsBaseList : List<DynamicControlsBase>
    {
        public DynamicControlsBaseList()
        { }
    }
   
}
