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
    

   public class DemoDataTableController
    {

        #region Private Variable

       static int fld1Index = 0;
       static int fld10Index = 0;
       static int fld14Index = 0;
       
        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                   
                    fld1Index = reader.GetOrdinal("fld1");
                      fld10Index = reader.GetOrdinal("fld10");
                    fld14Index = reader.GetOrdinal("fld14");
                   
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static DemoDataTableDo ReadData(SqlDataReader reader)
        {
            DemoDataTableDo formsRoleDo = new DemoDataTableDo();
            if (InisilizationIndex(reader))
            {
                formsRoleDo.fld1 = reader.GetString(fld1Index);
                formsRoleDo.fld10 = reader.GetString(fld10Index);
                formsRoleDo.fld14 = reader.GetString(fld14Index);
            }
            return formsRoleDo;
        }
        #endregion

        public static DemoDataTableDoList AllFormFields()
        {
            DemoDataTableDoList formsRolelist = new DemoDataTableDoList();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.DemoDataTable))
            {

                DemoDataTableDo formsRoleDo = new DemoDataTableDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            formsRoleDo = ReadData(reader);
                            formsRolelist.Add(formsRoleDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return formsRolelist;
            }

        }


      
    }
     
}
