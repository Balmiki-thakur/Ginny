using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class DynamicWorkFlowDo
    {
        public int Id { get; set; }
        public int Formid { get; set; }
        public string order { get; set; }
        public string Status { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public string docNature { get; set; }
        public string Eid { get; set; }

    }
    public class DynamicWorkFlowDoList : List<DynamicWorkFlowDo>
    {
        public DynamicWorkFlowDoList()
        { }
    }
  
}
