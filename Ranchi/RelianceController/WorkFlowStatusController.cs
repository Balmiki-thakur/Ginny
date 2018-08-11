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
   public  class WorkFlowStatusControllers
    {

        #region Private Variable

        static int workflowStatusIddex = 0;
        static int CompanyIdIndex = 0;
        static int FormIdIndex = 0;
        static int StatusNameIndex = 0;
        static int DocumentTypeIndex=0;
        static int IsAuthIndex=0;
        static int ApproveIndex=0;
        static int RejectIndex = 0;
        static int ReconisiderIndex=0;
        static int FormNameIndex = 0;
     
        static bool isInisilization = false;

        #endregion
        
        #region Private Method 
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows) 
            {
                if (!isInisilization)
                {
                    workflowStatusIddex = reader.GetOrdinal("WorkStatusId");
                    //  CompanyIdIndex = reader.GetOrdinal("CompanyId");
                    CompanyIdIndex = reader.GetOrdinal("CompanyId");
                    FormIdIndex = reader.GetOrdinal("FormId");
                    StatusNameIndex = reader.GetOrdinal("StatusName");
                    DocumentTypeIndex = reader.GetOrdinal("DocumentType");
                    IsAuthIndex = reader.GetOrdinal("IsAuth");
                    ApproveIndex = reader.GetOrdinal("Approve");
                    RejectIndex = reader.GetOrdinal("Reject");
                    ReconisiderIndex = reader.GetOrdinal("Reconisider");
                    FormNameIndex = reader.GetOrdinal("FormName");
                    isInisilization = true;
                }
                return true;

            }
            return false;
        }
        private static  WorkFlowStatusDo ReadData(SqlDataReader reader)
        {
            WorkFlowStatusDo workFlowStatusDo = new WorkFlowStatusDo();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(workflowStatusIddex))
                {
                    workFlowStatusDo.workflowStatusId = reader.GetInt32(workflowStatusIddex);
                }
                if (!reader.IsDBNull(CompanyIdIndex))
                {
                 
                }
                if (!reader.IsDBNull(FormIdIndex))
                {
                    workFlowStatusDo.DocumentType = reader.GetInt32(FormIdIndex);
                }
                if (!reader.IsDBNull(StatusNameIndex))
                {
                    workFlowStatusDo.StatusName = reader.GetString(StatusNameIndex);
                }
                if (!reader.IsDBNull(ApproveIndex))
                {
                    workFlowStatusDo.ApproveCaption = reader.GetString(ApproveIndex);
                }
                if (!reader.IsDBNull(RejectIndex))
                {
                    workFlowStatusDo.RejectCaption = reader.GetString(RejectIndex);
                }
                if (!reader.IsDBNull(ReconisiderIndex))
                {
                    workFlowStatusDo.ReconsiderCaption = reader.GetString(ReconisiderIndex);
                }
                if (!reader.IsDBNull(FormNameIndex))
                {
                    workFlowStatusDo.FormName = reader.GetString(FormNameIndex);
                }

            }
            return workFlowStatusDo;
        }
        #endregion



        #region Private Variable

        static int UserNameIndex = 0;       
        static int SStatusNameIndex = 0;
        static int OrderIndex = 0;
        static int RoleIndex = 0;
        static int CreateonIndex = 0;
        static int DocNatureIndex = 0;
        static int UFormNameIndex = 0;
        static bool UisInisilization = false;

        #endregion

        #region Private Method
        private static bool UInisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    UserNameIndex = reader.GetOrdinal("UserName");
                    SStatusNameIndex = reader.GetOrdinal("Approve");
                    RoleIndex = reader.GetOrdinal("RoleName");
                    OrderIndex = reader.GetOrdinal("Orderid");
                    CreateonIndex = reader.GetOrdinal("CreateOn");
                    DocNatureIndex = reader.GetOrdinal("DocNature");
                    UFormNameIndex = reader.GetOrdinal("FormName");
                    isInisilization = true;
                }
                return true;

            }
            return false;
        }
        private static DynamicWorkFlowgrid UReadData(SqlDataReader reader)
        {
            DynamicWorkFlowgrid dynamicWorkFlowgrid = new DynamicWorkFlowgrid();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(UserNameIndex))
                {
                    dynamicWorkFlowgrid.UserName = reader.GetString(UserNameIndex);
                }     
                if (!reader.IsDBNull(UFormNameIndex))
                {
                    dynamicWorkFlowgrid.FormName = reader.GetString(UFormNameIndex);
                }
                if (!reader.IsDBNull(OrderIndex))
                {
                    dynamicWorkFlowgrid.Order = reader.GetInt32(OrderIndex);
                }
                if (!reader.IsDBNull(RoleIndex))
                {
                    dynamicWorkFlowgrid.Rolename = reader.GetString(RoleIndex);
                }
                if (!reader.IsDBNull(DocNatureIndex))
                {
                    dynamicWorkFlowgrid.DocNature = reader.GetString(DocNatureIndex);
                }
                if (!reader.IsDBNull(SStatusNameIndex))
                {
                    dynamicWorkFlowgrid.Status = reader.GetString(SStatusNameIndex);
                }
            }
            return dynamicWorkFlowgrid;
        }
        #endregion
        public  void AddworkFlowStatus(WorkFlowStatusDo WorkFlowValue)
        {
            // MenuDTO menudto = new MenuDTO();
            SqlParameter[] para = new SqlParameter[5];
             para[0] = new SqlParameter("@formId",WorkFlowValue.DocumentType);
             para[1] = new SqlParameter("@statusname", WorkFlowValue.StatusName);
             para[2] = new SqlParameter("@approve",WorkFlowValue.ApproveCaption);
             para[3] = new SqlParameter("@reject",WorkFlowValue.RejectCaption);
             para[4] = new SqlParameter("@reconisider",WorkFlowValue.ReconsiderCaption);
             SqlDb sqlDb = new SqlDb();
             sqlDb.ExecuteNonQuerySP(StoreProcesureName.Add_WorkFlowStatuss, para);
        }

        public  WorkFlowList StatusbyformId(string formId)
        {
            WorkFlowList workFlowList = new WorkFlowList();
            SqlParameter[] pram= new SqlParameter[1];
            pram[0] = new SqlParameter("@formId", Convert.ToInt32(formId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.WorkFlowStatubyFormId,pram))
            {

                WorkFlowStatusDo workFlowStatusDo = new WorkFlowStatusDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            workFlowStatusDo = ReadData(reader);
                            workFlowList.Add(workFlowStatusDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return workFlowList;
            }

        }



        public  WorkFlowList WorkFlowStatus()
        {
            WorkFlowList workFlowList = new WorkFlowList();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.WorkFlowStatuby))
            {

                WorkFlowStatusDo workFlowStatusDo = new WorkFlowStatusDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            workFlowStatusDo = ReadData(reader);
                            workFlowList.Add(workFlowStatusDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return workFlowList;
            }

        }


        public  DynamicWorkFlowGridList DynamicWorkFlowformId(string formId)
        {
            DynamicWorkFlowGridList dynamicWorkFlowGridList = new DynamicWorkFlowGridList();
            SqlParameter[] pram = new SqlParameter[1];
            pram[0] = new SqlParameter("@formId", Convert.ToInt32(formId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.DynamicWorkFlowByFormid, pram))
            {

                DynamicWorkFlowgrid dynamicWorkFlowgrid = new DynamicWorkFlowgrid();
                try
                {
                    if (UInisilizationIndex(reader))
                        while (reader.Read())
                        {
                            dynamicWorkFlowgrid = UReadData(reader);
                            dynamicWorkFlowGridList.Add(dynamicWorkFlowgrid);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return dynamicWorkFlowGridList;
            }

        }


    }
}
