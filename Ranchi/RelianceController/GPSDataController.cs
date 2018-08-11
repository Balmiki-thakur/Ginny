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
   public class GPSDataController
    {
        #region Private Variable

        static int imienoIndex = 0;
        static int lattitudeIndex = 0;
        static int longitudeIndex = 0;
        static int altitudeIndex = 0;
        static int cTimeIndex = 0;
        static int rTimeIndex = 0;
        static int angleIndex = 0;
        static int SpeedIndex = 0;
        static int noofSatIndex = 0;
        static int distanceIndex = 0;
        static bool isInisilization = false;

        #endregion
        #region private Static Methods      
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    imienoIndex = reader.GetOrdinal("IMIENO");
                    lattitudeIndex = reader.GetOrdinal("lattitude");
                    longitudeIndex = reader.GetOrdinal("longitude");
                    lattitudeIndex = reader.GetOrdinal("lattitude");
                    altitudeIndex = reader.GetOrdinal("altitude");
                    rTimeIndex = reader.GetOrdinal("rTime");
                    cTimeIndex = reader.GetOrdinal("cTime");
                    SpeedIndex = reader.GetOrdinal("speed");
                    angleIndex = reader.GetOrdinal("angle");
                    noofSatIndex = reader.GetOrdinal("noofSat");
                    distanceIndex = reader.GetOrdinal("distance");
                    
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static GpsData ReadData(SqlDataReader reader)
        {
            GpsData formsRoleDo = new GpsData();
            if (InisilizationIndex(reader))
            {

                if (!reader.IsDBNull(imienoIndex))
                {
                    formsRoleDo.IMIENO = reader.GetString(imienoIndex);
                }
                if (!reader.IsDBNull(lattitudeIndex))
                {
                    formsRoleDo.lattitude = reader.GetDecimal(lattitudeIndex);
                }
                if (!reader.IsDBNull(longitudeIndex))
                {
                    formsRoleDo.longitude = reader.GetDecimal(longitudeIndex);
                }
                if (!reader.IsDBNull(angleIndex))
                {
                    formsRoleDo.angle = reader.GetDecimal(angleIndex);
                }
                if (!reader.IsDBNull(cTimeIndex))
                {
                    formsRoleDo.cTime = Convert.ToDateTime(reader.GetDateTime(cTimeIndex));
                }
                
                if (!reader.IsDBNull(rTimeIndex))
                {
                    formsRoleDo.rTime = Convert.ToDateTime(reader.GetDateTime(rTimeIndex));
                }
                if (!reader.IsDBNull(SpeedIndex))
                {
                    formsRoleDo.speed = reader.GetDecimal(SpeedIndex);
                }
                if (!reader.IsDBNull(distanceIndex))
                {
                    formsRoleDo.distance = reader.GetInt32(distanceIndex);
                }
            }
            return formsRoleDo;
        }
        #endregion
        public ListGpsData AllGPSRecord()
        {
            ListGpsData listgpsdata = new ListGpsData();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.LatestGPsRecord))
            {

                GpsData gpsdata = new GpsData();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            gpsdata = ReadData(reader);
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
        public ListGpsData GrsphGPSRecord()
        {
            ListGpsData listgpsdata = new ListGpsData();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.MilageGraphRecord))
            {

                GpsData gpsdata = new GpsData();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            gpsdata = ReadData(reader);
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
        public DropDownValueDoList MilageReportBind(string FormId, string FieldId)
        {
            DropDownValueDoList dropDownValueDoList = new DropDownValueDoList();
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@fromId", FormId);
            pram[1] = new SqlParameter("@fieldId", FieldId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.MilageGPsRecord, pram))
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!isInisilization)
                        {
                            DropDownValueDo dropdownvalue = new DropDownValueDo();
                            dropdownvalue.Values = reader["DefutColloum"] is DBNull ? null : reader["DefutColloum"].ToString();
                            dropdownvalue.Key = reader["Id"].ToString();
                            // dropdownvalue.FormName = reader["formName"].ToString();
                            isInisilization = true;
                            dropDownValueDoList.Add(dropdownvalue);
                        }
                        isInisilization = false;
                    }
                }
                return dropDownValueDoList;
            }

        }

        public int InsertGpsdata(GpsData gpsdatamodel)
        {
            int insertedid = 0;
            if ( gpsdatamodel !=null)
            {
                SqlParameter[] para = new SqlParameter[10];
                para[0] = new SqlParameter("@imieno",gpsdatamodel.IMIENO);
                para[1] = new SqlParameter("@lattitude", gpsdatamodel.lattitude);
                para[2] = new SqlParameter("@longitude", gpsdatamodel.longitude);
                para[3] = new SqlParameter("@altitude", gpsdatamodel.altitude);
                para[4] = new SqlParameter("@angle", gpsdatamodel.angle);
                para[5] = new SqlParameter("@rTime", gpsdatamodel.rTime);
                para[6] = new SqlParameter("@cTime", gpsdatamodel.cTime);
                para[7] = new SqlParameter("@distance", gpsdatamodel.distance);
                para[8] = new SqlParameter("@speed", gpsdatamodel.speed);
                para[9] = new SqlParameter("@noofSat", gpsdatamodel.noofSat);
                SqlDb sqlDb = new SqlDb();
               insertedid=  Convert.ToInt32(sqlDb.ExecuteScalarSP(StoreProcesureName.InsertGps, para));

            }
            return insertedid;
        } 
    }
}