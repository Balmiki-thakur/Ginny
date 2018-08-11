using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class UserAttendanceDo: GpsData
    {
        #region private member

        private int userid = 0;
        private DateTime capturedate = DateTime.Now;
        private bool  attendanceflag = false;
        private string geolocation = string.Empty;
        private string siteid = string.Empty;
        #endregion

       
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
        public string Connectiondb { get; set; }
        public DateTime Capturedate
        {
            get
            {
                return this.capturedate;
            }
            set
            {
                this.capturedate = value;
            }
        }
        public bool Attendanceflag
        {
            get
            {
                return this.attendanceflag;
            }
            set
            {
                this.attendanceflag = value;
            }
        }
        public string Geolocation
        {
            get
            {
                return this.geolocation;
            }
            set
            {
                this.geolocation = value;
            }
        }
        public string SiteId
        {
            get
            {
                return this.siteid;
            }
            set
            {
                this.siteid = value;
            }
        }

        

    }

    public class UserAttendanceDoList : List<UserAttendanceDo>
    {
        public UserAttendanceDoList()
        { }


    }
}
