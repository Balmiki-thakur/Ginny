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
  public  class NeedToActController
    {
        #region Private Variable

        static int FormNameIndex = 0;
        static int UFormNameIndex = 0;
        static int UserNameIndex = 0;
        static int StatusNameIndex = 0;
        static int CreatedOnIndex = 0;
        static int PendingTimeIndex = 0;
        static int FormIdIndex = 0;
        static int docidIndex = 0;
        static int ApprovedIndex = 0;
        static int Rejectndex = 0;
        static int ReconisiderIndex = 0;

        static bool isInisilization = false;

        #endregion
        #region Private Method
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    FormNameIndex = reader.GetOrdinal("FormName");
                    docidIndex = reader.GetOrdinal("DocId");
                    UserNameIndex = reader.GetOrdinal("UserName");
                    StatusNameIndex = reader.GetOrdinal("StatusName");
                    CreatedOnIndex = reader.GetOrdinal("CreateDate");
                    PendingTimeIndex = reader.GetOrdinal("PendingTime");
                    FormIdIndex = reader.GetOrdinal("Formid");
                    ApprovedIndex = reader.GetOrdinal("Approve");
                    Rejectndex = reader.GetOrdinal("Reject");
                    ReconisiderIndex = reader.GetOrdinal("Reconisider");
                    isInisilization = true;
                }
                return true;

            }
            return false;
        }

        private static bool InisilizationRequestIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    FormNameIndex = reader.GetOrdinal("FormName");
                    docidIndex = reader.GetOrdinal("DocId");
                    UserNameIndex = reader.GetOrdinal("UserName");
                    StatusNameIndex = reader.GetOrdinal("StatusName");
                    CreatedOnIndex = reader.GetOrdinal("CreateDate");
                    PendingTimeIndex = reader.GetOrdinal("PendingTime");
                    FormIdIndex = reader.GetOrdinal("Formid");
                  //  ApprovedIndex = reader.GetOrdinal("Approve");
                   // Rejectndex = reader.GetOrdinal("Reject");
                   // ReconisiderIndex = reader.GetOrdinal("Reconisider");
                    isInisilization = true;
                }
                return true;

            }
            return false;
        }


        private static bool InisilizationGridDatatIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    UserNameIndex = reader.GetOrdinal("UserName");
                    CreatedOnIndex = reader.GetOrdinal("CreateDate");
                    PendingTimeIndex = reader.GetOrdinal("UpdateDate");
                    StatusNameIndex = reader.GetOrdinal("Status");                 
                    isInisilization = true;
                }
                return true;

            }
            return false;
        }


        private static NeedToActDo ReadData(SqlDataReader reader)
        {
            NeedToActDo needToActDo = new NeedToActDo();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(FormNameIndex))
                {
                    needToActDo.FormName = reader.GetString(FormNameIndex);
                }
                if (!reader.IsDBNull(UFormNameIndex))
                {
                    needToActDo.DocId = reader.GetInt32(docidIndex);
                }
                if (!reader.IsDBNull(UserNameIndex))
                {
                    needToActDo.UserName = reader.GetString(UserNameIndex);
                }
                if (!reader.IsDBNull(StatusNameIndex))
                {
                    needToActDo.StatusName = reader.GetString(StatusNameIndex);
                }
                if (!reader.IsDBNull(CreatedOnIndex))
                {
                    needToActDo.CreateOn = Convert.ToString(reader.GetDateTime(CreatedOnIndex));
                }
                if (!reader.IsDBNull(PendingTimeIndex))
                { 
                 needToActDo.PendingTime= Convert.ToString(reader.GetInt32(PendingTimeIndex));
                }
                if (!reader.IsDBNull(FormIdIndex))
                {
                    needToActDo.FormId = reader.GetInt32(FormIdIndex);
                }

                if (!reader.IsDBNull(ApprovedIndex))
                {
                    needToActDo.Approve = reader.GetString(ApprovedIndex);
                }
                if (!reader.IsDBNull(Rejectndex))
                {
                    needToActDo.Reject = reader.GetString(Rejectndex);
                }
                if (!reader.IsDBNull(ReconisiderIndex))
                {
                    needToActDo.Reconisider = reader.GetString(ReconisiderIndex);
                }
               
            }
            return needToActDo;
        }


        private static NeedToActDo RequestReadData(SqlDataReader reader)
        {
            NeedToActDo needToActDo = new NeedToActDo();
            if (InisilizationRequestIndex(reader))
            {
                if (!reader.IsDBNull(FormNameIndex))
                {
                    needToActDo.FormName = reader.GetString(FormNameIndex);
                }
                if (!reader.IsDBNull(UFormNameIndex))
                {
                    needToActDo.DocId = reader.GetInt32(docidIndex);
                }
                if (!reader.IsDBNull(UserNameIndex))
                {
                    needToActDo.UserName = reader.GetString(UserNameIndex);
                }
                if (!reader.IsDBNull(StatusNameIndex))
                {
                    needToActDo.StatusName = reader.GetString(StatusNameIndex);
                }
                if (!reader.IsDBNull(CreatedOnIndex))
                {
                    needToActDo.CreateOn = Convert.ToString(reader.GetDateTime(CreatedOnIndex));
                }
                if (!reader.IsDBNull(PendingTimeIndex))
                {
                    needToActDo.PendingTime = Convert.ToString(reader.GetInt32(PendingTimeIndex));
                }
                if (!reader.IsDBNull(FormIdIndex))
                {
                    needToActDo.FormId = reader.GetInt32(FormIdIndex);
                }

             
            }
            return needToActDo;
        }


        private static NeedToActDo GridDataReadData(SqlDataReader reader)
        {
            NeedToActDo needToActDo = new NeedToActDo();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(UserNameIndex))
                {
                    needToActDo.UserName = reader.GetString(UserNameIndex);
                }
                if (!reader.IsDBNull(CreatedOnIndex))
                {
                    needToActDo.CreateOn = Convert.ToString(reader.GetDateTime(CreatedOnIndex));
                }
                if (!reader.IsDBNull(PendingTimeIndex))
                {
                    needToActDo.PendingTime =  Convert.ToString(reader.GetDateTime(PendingTimeIndex));
                }
                if (!reader.IsDBNull(StatusNameIndex))
                {
                    needToActDo.StatusName = reader.GetString(StatusNameIndex);
                }
         
            }
            return needToActDo;
        }


        #endregion
        #region Add MasterMovement 
        public  void AddMasterMoveMent(DynamicWorkFlowDo dynamicWorkFlowDoList)
        {

            SqlParameter[] para = new SqlParameter[7];
            para[0] = new SqlParameter("@Formid", dynamicWorkFlowDoList.Formid);
            para[1] = new SqlParameter("@order", dynamicWorkFlowDoList.order);
            para[2] = new SqlParameter("@Status", dynamicWorkFlowDoList.Status);
            para[3] = new SqlParameter("@RoleId", dynamicWorkFlowDoList.RoleId);
            para[4] = new SqlParameter("@UserId", dynamicWorkFlowDoList.UserId);
            para[5] = new SqlParameter("@docNature", dynamicWorkFlowDoList.docNature);
            para[6] = new SqlParameter("@Eid", dynamicWorkFlowDoList.Eid);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddMasterMovement, para);

        }
        #endregion 
        #region (Need to Act) OR  (MyRequest) retrive
        public  NeedToActList needToAct(int Userid)
        {
            NeedToActList needToActList = new NeedToActList();
            SqlParameter[] pram= new SqlParameter[1];
            pram[0] = new SqlParameter("@userId", Userid);
           //pram[1] = new SqlParameter("@userId", RoleId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.NeedToAct, pram))
            {

                NeedToActDo menuDTO = new NeedToActDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            menuDTO = ReadData(reader);
                            needToActList.Add(menuDTO);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return needToActList;
            }

        }
        public  NeedToActList MyRequest(int Userid)
        {
            SqlConnection constr = new SqlConnection();
            //var DatabaseName = MainDatabaseEntity.Companyid(CompanyName);         
            NeedToActList needToActList = new NeedToActList();
            SqlParameter[] pram = new SqlParameter[1];
            pram[0] = new SqlParameter("@userId", Convert.ToInt32(Userid));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.MyRequest, pram))
            {
                NeedToActDo needToActDo = new NeedToActDo();
                try
                {
                    if (InisilizationRequestIndex(reader))
                        while (reader.Read())
                        {
                            needToActDo = RequestReadData(reader);
                            needToActList.Add(needToActDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return needToActList;
            }
        }
        public  void needtoactApprove(int FormIds, int docid, string statusName, string UserId)
        {         
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@FormIds", FormIds);
            para[1] = new SqlParameter("@docid", docid);
            para[2] = new SqlParameter("@StatusName", statusName);
            para[3] = new SqlParameter("@CurentUserId", UserId);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.NeedtoActApprove, para);       
        }
        public  void needtoactReject(int FormIds, int docid, string statusName, string UserId)
        {          
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@FormIds", FormIds);
            para[1] = new SqlParameter("@docid", docid);
            para[2] = new SqlParameter("@StatusName", statusName);
            para[3] = new SqlParameter("@curentUserId", Convert.ToInt32(UserId));
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.NeedtoActReject, para);
        }
        public  NeedToActList NeedToActGridData(int FormIds, int DocId)
        {
            NeedToActList needToActList = new NeedToActList();
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@formid", FormIds);
            pram[1] = new SqlParameter("@DocId", DocId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.NeedToActGridDetail, pram))
            {
                NeedToActDo needToActDo = new NeedToActDo();
                try
                {
                    if (InisilizationGridDatatIndex(reader))
                        while (reader.Read())
                        {
                            needToActDo = GridDataReadData(reader);
                            needToActList.Add(needToActDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return needToActList;
            }
        }        
        #endregion
    }
}



