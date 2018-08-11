using Reliance.Modals;
using Reliance.SqlDll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceController
{
    public class DynamicUserRegistationController
    {

        //   public static DynamicUserRegistationDo InsertMetada(string formName, string deviceType, DynamicUserRegistationDoList deviceFields)
        //    {
        //        string formName1 = "UserRegistation";
        //        DynamicUserRegistationDo textBoxList = new DynamicUserRegistationDo();
        //        StringBuilder strb = new StringBuilder();
        //        // deviceType.TrimEnd(',');
        //        strb.Append(string.Format("INSERT INTO {0} {1}( ", formName1, deviceType.ToString().ToUpper()));
        //        // var count = deviceFields.Count;
        //        foreach (var item in deviceFields)
        //        {

        //            strb.Append(string.Format(" {0}, ", item.FieldId.ToString()));
        //        }
        //        var index1 = strb.ToString().LastIndexOf(',');
        //        if (index1 >= 0)
        //            strb.Remove(index1, 1);
        //        // deviceFields.RemoveAt(deviceFields.Count - 1);
        //        strb.Append(") VALUES ( ");
        //        foreach (var item in deviceFields)
        //        {
        //            strb.Append(string.Format(" '{0}', ", item.Value.ToString()));


        //        }
        //        var index = strb.ToString().LastIndexOf(',');
        //        if (index >= 0)
        //            strb.Remove(index, 1);
        //        strb.Append(")");
        //        string Query = strb.ToString();
        //        SqlParameter[] para = new SqlParameter[1];
        //        para[0] = new SqlParameter("@strb", Query.ToString());
        //        var Output = SqlDb.ExecuteScalarSP(StoreProcesureName.InsertMasterData, para);
        //        textBoxList.IdentityId = Convert.ToInt32(Output);
        //        return textBoxList;

        //    }

        //}
    }
}
