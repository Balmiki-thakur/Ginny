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
    public class MasterDocumentController
    {

        #region Private Variable
        static int IdIndex = 0;
        static int DocIdIndex = 0;
        static int FormIdIndex = 0;
        static int UserIdIndex = 0;
        static int CreateDateIndex = 0;
        static int UpdateDateIndex = 0;
        static int FormNameIndex = 0;
        static int DataCountIndex = 0;
        static bool isInisilization = false;
        #endregion
        #region Private Method
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                   // IdIndex = reader.GetOrdinal("Id");
                  //  DocIdIndex = reader.GetOrdinal("DocId");
                    FormIdIndex = reader.GetOrdinal("FormId");
                   // UserIdIndex = reader.GetOrdinal("UserId");
                   // CreateDateIndex = reader.GetOrdinal("CreateDate");
                   // UpdateDateIndex = reader.GetOrdinal("UpdateDate");
                    FormNameIndex = reader.GetOrdinal("FormName");
                    DataCountIndex = reader.GetOrdinal("DataCount");
                    isInisilization = false;
                }
                return true;
            }
            return false;
        }
        private static MasterMomentDo ReadData(SqlDataReader reader)
        {
            MasterMomentDo masterMomentDo = new MasterMomentDo();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(IdIndex))
                {
                    masterMomentDo.Id = reader.GetInt32(IdIndex);
                }
                if (!reader.IsDBNull(DocIdIndex))
                {
                    masterMomentDo.docid = reader.GetInt32(DocIdIndex);
                }
                if (!reader.IsDBNull(FormIdIndex))
                {
                    masterMomentDo.Formid = reader.GetInt32(FormIdIndex);
                }
                if (!reader.IsDBNull(UserIdIndex))
                {
                    masterMomentDo.UserId = reader.GetInt32(UserIdIndex);
                }
                //if (!reader.IsDBNull(CreateDateIndex))
                //{
                //    masterMomentDo.CreateDate = reader.GetDateTime(CreateDateIndex);
                //}
                //if (!reader.IsDBNull(UpdateDateIndex))
                //{
                //    masterMomentDo.UpdateDate = reader.GetDateTime(UpdateDateIndex);
                //}
                if (!reader.IsDBNull(FormNameIndex))
                {
                    masterMomentDo.FormName = reader.GetString(FormNameIndex);
                }
                if (!reader.IsDBNull(DataCountIndex))
                {
                    masterMomentDo.FormCount = reader.GetInt64(DataCountIndex);
                }
            }
            return masterMomentDo;
        }
        #endregion

        public  void AddMasterDocument(MasterDocumentDo masterDocumentDo) 
        {
           
            SqlParameter[] para = new SqlParameter[5];
            para[0] = new SqlParameter("@docid", masterDocumentDo.docid);
            para[1] = new SqlParameter("@Formid", masterDocumentDo.Formid);
            para[2] = new SqlParameter("@UserId", masterDocumentDo.UserId);
            para[3] = new SqlParameter("@FormName", masterDocumentDo.FormName);
            para[4] = new SqlParameter("@roleId", masterDocumentDo.RoleId);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddMasterDocumet, para);
            
        }

        public  MasterMomentList mastermomentId(int UserId)
        {
            MasterMomentList masterMomentList = new MasterMomentList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@userId", UserId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.MomentdocumentCount, para))
            {
                MasterMomentDo masterMomentDo = new MasterMomentDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            masterMomentDo = ReadData(reader);
                            masterMomentList.Add(masterMomentDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return masterMomentList;
        }
    }
}
