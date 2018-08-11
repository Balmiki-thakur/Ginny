using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
  public  class RoleMasterDo
    {
         private int roleId = 0;
         private int companyId = 0;      
         private string roleName = "";
         private string roledescription = "";
         private DateTime createOn = new DateTime();
          
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
         public int CompanyId
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
         public string RoleDescription
        {
            get
            {
                return this.roledescription;
            }
            set
            {
                this.roledescription = value;
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
    }

  public class RoleMasterDoList : List<RoleMasterDo>
    {
      public RoleMasterDoList()
      { }
    }
}
