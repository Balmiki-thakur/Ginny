using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class MenuMasterDo
    {
        private long menunId = 0;
        private int eId = 0;
        private string menuname = "";
        private string submenuname = "";
        private long pmenu = 0;
        private string menuLink = "";
        private int menuOrder = 0;
        private string image = "";
        private string role = "";
        private string menutype = "";
        private DateTime createOn = new DateTime();
        private string menuDescription = "";
           
        public long MenunId
        {
            get
            {
                return this.menunId;
            }
            set
            {
                this.menunId = value;
            }
        }
        public int Eid
        {

            get
            {
                return this.eId;
            }
            set
            {
                this.eId = value;
            }
        }
        public string Menuname
        {
            get
            {
                return this.menuname;
            }
            set
            {
                this.menuname = value;
            }
        }
        public string SubMenuname
        {
            get
            {
                return this.submenuname;
            }
            set
            {
                this.submenuname = value;
            }
        }
        public long PMenu
        {
            get
            {
                return this.pmenu;
            }
            set
            {
                this.pmenu = value;
            }
        }
        public string MenuLink
        {
            get
            {
                return this.menuLink;
            }
            set
            {
                this.menuLink = value;
            }
        }
        public int MenuOrder
        {
            get
            {
                return this.menuOrder;
            }
            set
            {
                this.menuOrder = value;
            }
        }
        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }
        public string Role
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
        public string Menutype
        {
            get
            {
                return this.menutype;
            }
            set
            {
                this.menutype = value;
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
        public string MenuDescription
        {
            get
            {
                return this.menuDescription;
            }
            set
            {
                this.menuDescription = value;
            }
        }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
    public class MenuMasterList : List<MenuMasterDo>
    {
        public MenuMasterList() { }
    }

}
