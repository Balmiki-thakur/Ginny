using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class MenuRoleDo
    {
        #region Private Variable
        private int roleId = 0;
        private string roleName = "";
        private int menuId = 0;
        private string menuName = "";
        private bool isValid = false;
        private bool isedit = false;
        private bool isdelete = false;
        #endregion
        #region Public Variable
        public int RoleId
        {
            get 
            {
                return this.roleId; 
            }
            set
            {
                this.roleId = value;
            }
        }
        public string RoleName
        {
            get
            {
                return this.roleName;
            }
            set
            {
                this.roleName = value;
            }

        }
        public int MenuId
        {
            get
            {
                return this.menuId;
            }
            set
            {
                this.menuId = value;
            }
        }
        public string MenuName
        {
            get
            {
                return this.menuName;
            }
            set
            {
                this.menuName = value;
            }

        }       
        public bool IsValid
        {
            get
            {
                return this.isValid;
            }
            set
            {
                this.isValid = value;
            }
        }
        public bool IsEdit
        {
            get
            {
                return this.isedit;
            }
            set
            {
                this.isedit = value;
            }
        }
        public bool IsDelete
        {
            get
            {
                return this.isdelete;
            }
            set
            {
                this.isdelete = value;
            }
        }
        #endregion
    }
    public class MenuRoleDoList : List<MenuRoleDo>
    {
        public MenuRoleDoList()
           { }
    }
}
