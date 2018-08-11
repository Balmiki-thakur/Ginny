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
  public  class VehicleTrakingReportController
    {
        #region Private Variable

        static int DateTimeIndex = 0;
        static int LatitudeIndex = 0;
        static int LogitudeIndex = 0;
        static int DistanceIndex = 0;
       
        static bool isInisilization = false;

        #endregion
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {

                    DateTimeIndex = reader.GetOrdinal("DateTime");
                    LatitudeIndex = reader.GetOrdinal("lat");
                    LogitudeIndex = reader.GetOrdinal("long");
                    DistanceIndex = reader.GetOrdinal("Distance");

                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static VehicleTrakingReportDo ReadData(SqlDataReader reader)
        {
            VehicleTrakingReportDo vehicleTrakingReportDo = new VehicleTrakingReportDo();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(DateTimeIndex))
                {
                    vehicleTrakingReportDo.DateTime = reader.GetString(DateTimeIndex);
                }
                if (!reader.IsDBNull(LatitudeIndex))
                {
                    vehicleTrakingReportDo.Latitude = Convert.ToString(reader.GetDecimal(LatitudeIndex));
                }
                if (!reader.IsDBNull(LogitudeIndex))
                {
                    vehicleTrakingReportDo.Longitude = Convert.ToString(reader.GetDecimal(LogitudeIndex));
                }
                if (!reader.IsDBNull(DistanceIndex))
                {
                    vehicleTrakingReportDo.Distance = Convert.ToString(reader.GetDecimal(DistanceIndex));
                }

            }
            return vehicleTrakingReportDo;
        }

        public static VehicleTrakingList VehicleReport(string Imeino, string StartDataTime, string EndDateTime)
        {

            VehicleTrakingList listgpsdatas = new VehicleTrakingList();
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@StartDataTime", StartDataTime);
            para[1] = new SqlParameter("@EndDateTime", EndDateTime);
            para[2] = new SqlParameter("@Imeino", Imeino);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.VehicleTrakingReport, para))
            {

                VehicleTrakingReportDo gpsdatas = new VehicleTrakingReportDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            gpsdatas = ReadData(reader);
                            listgpsdatas.Add(gpsdatas);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return listgpsdatas;
            }

        }

    }
}
