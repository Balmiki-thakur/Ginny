using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reliance.Modals;
using Reliance.SqlDll;
using System.Data.SqlClient;

namespace RelianceController
{
    class UserAttendenceController
    {

        #region Private Variable

        static int userIndex = 0;
        static int capturedateIndex = 0;
        static int attendanceflagIndex = 0;
        static int geolocationIndex = 0;
        static int siteidIndex = 0;
        static bool isInisilization = false;

        #endregion

        //private static bool InisilizationIndex(SqlDataReader reader)
        //{
        //    if (reader.HasRows)
        //    {
        //        if (!isInisilization)
        //        {

        //            return true;



        //        }
        //    }
        //}
    }
}
