using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class LooKUPDO
    {
        private string id = "";
        private string lookUpData = "";
        private string lookUpId = "";


        public string Id
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
        public string LookUpData 
        {
            get
            {
                return this.lookUpData;
            }
             set
            {
                this.lookUpData = value;
            }
        }
        public string LookUpId {
            get 
        { 
            return this.lookUpId;
        }
            set
            {
                this.lookUpId = value; 
            }
        }
    }
    public class ListLooKup : List<LooKUPDO>
    {
        public ListLooKup() { }
    }
}
