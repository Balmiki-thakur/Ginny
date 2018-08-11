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
   public  class GPSMileageReportController
    {
        #region Private Variable

       static int TotalKmIndex = 0;
       static int IMIENOIndex = 0;
       static int SpeedIndex = 0;
       static int DateIndex = 0;
        static bool isInisilization = false;

        #endregion
        private static bool MilageInisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    TotalKmIndex = reader.GetOrdinal("TotalKm");
                    IMIENOIndex = reader.GetOrdinal("IMIENO");
                    SpeedIndex = reader.GetOrdinal("Speed");
                    // Vehicle_NameIndex = reader.GetOrdinal("Vehicle_Name");
                    DateIndex = reader.GetOrdinal("Date");

                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static MilageGPSDataReport MilageReadData(SqlDataReader reader)
        {
            MilageGPSDataReport formsRoleDo = new MilageGPSDataReport();
            if (MilageInisilizationIndex(reader))
            {
                if (!reader.IsDBNull(TotalKmIndex))
                {
                    formsRoleDo.TotalKm =  Convert.ToString(reader.GetDecimal(TotalKmIndex));
                }
                if (!reader.IsDBNull(IMIENOIndex))
                {
                    formsRoleDo.IMIENO = reader.GetString(IMIENOIndex);
                }
                if (!reader.IsDBNull(SpeedIndex))
                {
                    formsRoleDo.Speed = Convert.ToString( reader.GetDecimal(SpeedIndex));
                }
                if (!reader.IsDBNull(DateIndex))
                {
                    formsRoleDo.Date = Convert.ToString(reader.GetDateTime(DateIndex));
                }

            }
            return formsRoleDo;
        }
        public  ListMilageGPSDataReport MilageGPSRecord(string imei_number3, string mstart_date, string mend_date, string mstart_time, string mend_time)
        {
            string startDatetime = mstart_date + " " + mstart_time;
            string EndDatetime = mend_date + " " + mend_time;
          //  string imeino = "356307049848137";
            ListMilageGPSDataReport listgpsdata = new ListMilageGPSDataReport();
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@ctime", Convert.ToDateTime(startDatetime));
            para[1] = new SqlParameter("@enddate", Convert.ToDateTime(EndDatetime));
            para[2] = new SqlParameter("@iMIENO",  imei_number3);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.GridMilageGPsRecord, para))
            {

                MilageGPSDataReport gpsdata = new MilageGPSDataReport();
                try
                {
                    if (MilageInisilizationIndex(reader))
                        while (reader.Read())
                        {
                            gpsdata = MilageReadData(reader);
                            listgpsdata.Add(gpsdata);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listgpsdata;
            }

        }


    }
}
