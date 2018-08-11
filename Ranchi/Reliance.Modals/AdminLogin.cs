using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class AdminLogin
    {
        private int userid = 0;
        private string username = "";
        private string password = "";
        private string email = "";
      //  [Required]
        //public int Userid
        //{
        //    get
        //    {
        //        return this.userid;
        //    }
        //    set
        //    {
        //        this.userid = value;
        //    }
        //}
        //[Required]
        public string Username
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
       // [Required]
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
    //    [Required]
        //public string Email
        //{
        //    get
        //    {
        //        return this.email;
        //    }
        //    set
        //    {
        //        this.email = value;
        //    }
        //}

    }
    public class AdminLoginList : List<AdminLogin>
     {
            public AdminLoginList() { }
     }


  
}

