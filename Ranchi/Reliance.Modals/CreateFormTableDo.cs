using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class CreateFormTableDo
    {
        #region private variable
        private long id = 123;
        private int eid=0;
        private string formName = " ";
        private string tableName ="";
        private string uformName ="";
        private string formlayout ="";
        private string formdescription="";
        private string lastUpdateBy ="";
        private string column1DataType="VARCHAR(32)";
        private string column1Name = "formName";
        private string column1Nullable="Not Null";
        private DateTime lastUpdateOn=new DateTime(1990, 01, 01);
        private DateTime createdOn=new DateTime(1990, 01, 01);
        private int workflow= 0;
        private int isRoleAssignment = 0;
        private string formsource = "";
        private string statusaction = "";
        private string docstatus = "";
        private string staticpages = "";
        private int documentid = 0;
        #endregion
        #region public properties
        public long Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
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
        public string FormName  
        {
           
            get
            {
                return this.formName;
            }
            set
            {
                
                this.formName = value;
            }
        }
        public string TableName
        {
            get
            {
                return this.tableName;
            }
            set
            {
                this.tableName = value;
            }
        }
        public string Formlayout
        {
            get
            {
                return this.formlayout;
            }
            set
            {
                this.formlayout = value;
            }
        }
        public string Formdescription
        {
            get
            {
                return formdescription;
            }
            set
            {
                formdescription = value;
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
        public string Column1Nullable
        {
            get
            {
                return column1Nullable;
            }
            set
            {
                column1Nullable = value;
            }
        }
        public string Column1DataType
        {
            get
            {
                return column1DataType;
            }
            set
            {
                column1DataType = value;
            }
        }
        public string Column1Name
        {
            get
            {
                return column1Name;
            }
            set
            {
                column1Name = value;
            }
        }
        public int WorkFlow
        {
            get
            {
                return this.workflow;
            }
            set
            {
                this.workflow = value;
            }
        }
        public int IsRoleAssignment
        {
            get
            {
                return isRoleAssignment;
            }
            set
            {
                isRoleAssignment = value;
            }
        }     
        public string LastUpdateBy
        {
            get
            {
                return lastUpdateBy;
            }
            set
            {
                lastUpdateBy = value;
            }
        }
        public DateTime LastUpdateOn
        {
            get
            {
                return lastUpdateOn;
            }
            set
            {
                lastUpdateOn = value;
            }
        }
        public DateTime CreatedOn
        {
            get
            {
                return createdOn;
            }
            set
            {
                createdOn = value;
            }
        }
        public string FormSource
        {
            get
            {
                return this.formsource;
            }
            set
            {
                this.formsource = value;
            }
        }
        public string StatusAction
        {
            get
            {
                return this.statusaction;
            }
            set
            {
                this.statusaction = value;
            }
        }
        public string DocStatus
        {
            get
            {
                return this.docstatus;
            }
            set
            {
                this.docstatus = value;
            }
        }
        public int DocumentId
        {
            get
            {
                return this.documentid;
            }
            set
            {
                this.documentid = value;
            }
        }
        public string StaticPages
        {
            get
            {
                return this.staticpages;
            }
            set
            {
                this.staticpages = value;
            }
        }

        #endregion
    }
    public class CreateTableDoList : List<CreateFormTableDo>
    {
        public CreateTableDoList()
        { }
    }
}
