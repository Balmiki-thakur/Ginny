using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class IsROleAssignmentDo
    {
        private int id = 0;
        private int userid = 0;
        private int roleis = 0;
        private int formId = 0;
        private int documentFormId = 0;
        private int documentFields = 0;
        private string documentDataid = "";
        private DateTime createdOn = new DateTime();
        private DateTime lastUpdateOn = new DateTime();
        private int isEdit = 0;
        private int isView = 0;
        private int isCreate = 0;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
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
        public int Roleis
        {
            get
            {
                return this.roleis;
            }
            set
            {
                this.roleis = value;
            }
        }
        public int FormId
        {
            get
            {
                return this.formId;
            }
            set
            {
                this.formId = value;
            }
        }
        public int DocumentFormId
        {
            get
            {
                return this.documentFormId;
            }
            set
            {
                this.documentFormId = value;
            }
        }
        public int DocumentFields
        {
            get
            {
                return this.documentFields;
            }
            set
            {
                this.documentFields = value;
            }
        }
        public string DocumentDataid
        {
            get
            {
                return this.documentDataid;
            }
            set
            {
                this.documentDataid = value;
            }
        }
        public int IsEdit
        {
            get
            {
                return this.isEdit;
            }
            set
            {
                this.isEdit = value;
            }
        }
        public int IsView
        {
            get
            {
                return this.isView;
            }
            set
            {
                this.isView = value;
            }
        }
        public int IsCreate
        {
            get
            {
                return this.isCreate;
            }
            set
            {
                this.isCreate = value;
            }
        }
        public DateTime CreateOn
        {
            get
            {
                return this.createdOn;
            }
            set
            {
                this.createdOn = value;
            }
        }
        public DateTime LastUpdateOn
        {
            get
            {
                return this.lastUpdateOn;
            }
            set
            {
                this.lastUpdateOn = value;
            }
        }
           
    }
    public class IsROleAssignmentDoList : List<IsROleAssignmentDo>
    {
        public IsROleAssignmentDoList() 
        { }
    }
   // 7014322945
    public class AllFormRoleAssingment 
    {
       
        private int eid = 0;
        private long formId = 0;
        private string formName = "";
        private string uformName = "";
        private int workflow = 0;
        private int roleAssignment = 0;
        private int documentFormId = 0;
        private int documentFieldId = 0;
      

      
        public int Eid
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
            }
        }
        public long FormId
        {
            get
            {
                return formId;
            }
            set
            {
                formId = value;
            }
        }
        public string FormName
        {
            get
            {
                return formName;
            }
            set
            {
                formName = value;
            }
        }
        public string UFormName
        {
            get
            {
                return uformName;
            }
            set
            {
                uformName = value;
            }
        }
        public int Workflow
        {
            get
            {
                return workflow;
            }
            set
            {
                workflow = value;
            }
        }
        public int RoleAssignment
        {
            get
            {
                return roleAssignment;
            }
            set
            {
                roleAssignment = value;
            }
        }
        public int DocumentFormId
        {
            get
            {
                return documentFormId;
            }
            set
            {
                documentFormId = value;
            }
        }
        public int DocumentFieldId
        {
            get
            {
                return documentFieldId;
            }
            set
            {
                documentFieldId = value;
            }
        }
    }
    public class AllFormRoleAssingmentList : List<AllFormRoleAssingment>
    {
        public AllFormRoleAssingmentList() { }
    }
}
