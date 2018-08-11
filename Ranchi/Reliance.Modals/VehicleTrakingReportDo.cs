using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class VehicleTrakingReportDo
    {
       public string DateTime { get; set; }
       public string Latitude { get; set; }
       public string Longitude { get; set; }
       public string Distance { get; set; }
    }
   public class VehicleTrakingList : List<VehicleTrakingReportDo>
   {
       public VehicleTrakingList() 
       { }
   }
}
