using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceController
{
    public class MasterDashBoard
    {
        #region Private Variable 
        static int Idndex = 0;
        static int FormNameIndex = 0;
        static int CreatedOnIndex = 0;
        static int lastmodifiedOnIndex = 0;
        static int FormDiscriptionIndex = 0;
        static int FormLayoutIndex = 0;
        static bool isInisilization = false;
        #endregion
        #region Private Method
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    Idndex = reader.GetOrdinal("Id");
                    FormNameIndex = reader.GetOrdinal("FormName");
                    CreatedOnIndex = reader.GetOrdinal("CreatedOn");
                    lastmodifiedOnIndex = reader.GetOrdinal("LastModifiedOn");
                    FormDiscriptionIndex = reader.GetOrdinal("FormDiscription");
                    FormLayoutIndex = reader.GetOrdinal("FormLayout");
                    isInisilization = false;
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
