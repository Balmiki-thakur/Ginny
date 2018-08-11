using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class DynamicUserRegistationDo
    {

        #region private variable
        private string fieldId = "";
        private string values = "";
        private string fieldMapping = "";
        private int userid = 0;
        private string username = "";
        private int companyId =0;
        private string password = "";
        private bool isAuthantication = false;
        private string email = "";
        private string mobileNo = "";
        private int role = 0;
        private DateTime dob = new DateTime(1990, 01, 01);
        private DateTime createOn = new DateTime(1990, 01, 01);
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
        [Required]
        public string Value
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



        public int Userid
        {
            get
            {
                return this.userid;
            }
            set
            {
                this.userid = value;
            }
        }
       
       [Required(ErrorMessage="UserName Required:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$",ErrorMessage="Special Characters not  allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string UserName
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }
        public int Company
       {
           get
           {
               return this.companyId;
           }
           set
           {
               this.companyId = value;
           }
       }      
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
       
        [Required(ErrorMessage = "EmailId Required:")]
        [DisplayName("Email Id:")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }      
        public string MobileNo
        {
            get
            {
                return this.mobileNo;
            }
            set
            {
                this.mobileNo = value;
            }
        }
        [Required]
        public int Role
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }
        public DateTime DOB
        {
            get
            {
                return this.dob;
            }
            set
            {
                this.dob = value;
            }
        }
        public bool IsAuthantication
        {
            get
            {
                return this.isAuthantication;
            }
            set
            {
                this.isAuthantication = value;
            }
        }
        public DateTime CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        #endregion
    }
   public class DynamicUserRegistationDoList : List<DynamicUserRegistationDo>
    {
       public DynamicUserRegistationDoList()
        { }
    }
}
