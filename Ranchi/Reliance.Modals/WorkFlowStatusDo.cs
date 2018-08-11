using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
    public class WorkFlowStatusDo
    {
        public int workflowStatusId { get; set; }
        public int DocumentType { get; set; }
        public string StatusName { get; set; }
        public string Displayorder { get; set; }
        public string ApproveCaption { get; set; }
        public string RejectCaption { get; set; }
        public string ReconsiderCaption { get; set; }
        public string FormName { get; set; }
    }
    public class WorkFlowList : List<WorkFlowStatusDo> 
    {
        public WorkFlowList()
        { }
    }
}
