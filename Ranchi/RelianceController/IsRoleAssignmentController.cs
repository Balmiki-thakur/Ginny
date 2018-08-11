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
   public  class IsRoleAssignmentController
    {


        #region Private Variable
        static int idIndex = 0;
        static int useridIndex = 0;
        static int roleisIndex = 0;
        static int formIdIndex = 0;
        static int documentFormIdIndex = 0;
        static int documentFieldsIndex = 0;
        static int documentDataidIndex = 0;
        static int isEditIndex = 0;
        static int isViewIndex = 0;
        static int isCreateIndex = 0;
        static bool isInisilization = false;
        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    idIndex = reader.GetOrdinal("Id");
                    useridIndex = reader.GetOrdinal("UserId");
                    roleisIndex = reader.GetOrdinal("RoleId");
                    formIdIndex = reader.GetOrdinal("FormId");
                    documentFormIdIndex = reader.GetOrdinal("DocumentFormId");
                    documentFieldsIndex = reader.GetOrdinal("DocumentFields");
                    documentDataidIndex = reader.GetOrdinal("DocumentDataid");
                    isEditIndex = reader.GetOrdinal("IsEdit");
                    isViewIndex = reader.GetOrdinal("IsView");
                    isCreateIndex = reader.GetOrdinal("IsCreate");

                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static IsROleAssignmentDo ReadData(SqlDataReader reader)
        {
            IsROleAssignmentDo createFormTabledo = new IsROleAssignmentDo();

            if (InisilizationIndex(reader))
            {
                createFormTabledo.Id = reader.GetInt32(idIndex);

                if (!reader.IsDBNull(useridIndex))
                {
                    createFormTabledo.Userid = reader.GetInt32(useridIndex);
                }
                if (!reader.IsDBNull(roleisIndex))
                {
                    createFormTabledo.Roleis = reader.GetInt32(roleisIndex);
                }
                if (!reader.IsDBNull(formIdIndex))
                {
                    createFormTabledo.FormId = reader.GetInt32(formIdIndex);
                }
                if (!reader.IsDBNull(documentFormIdIndex))
                {
                    createFormTabledo.DocumentFormId = reader.GetInt32(documentFormIdIndex);
                }
                if (!reader.IsDBNull(documentFieldsIndex))
                {
                    createFormTabledo.DocumentFields = reader.GetInt32(documentFieldsIndex);
                }

                if (!reader.IsDBNull(documentDataidIndex))
                {
                    createFormTabledo.DocumentDataid = reader.GetString(documentDataidIndex);
                }


                if (!reader.IsDBNull(isEditIndex))
                {
                    createFormTabledo.IsEdit = reader.GetInt32(isEditIndex);
                }
                if (!reader.IsDBNull(isViewIndex))
                {
                    createFormTabledo.IsView = reader.GetInt32(isViewIndex);
                }
                if (!reader.IsDBNull(isCreateIndex))
                {
                    createFormTabledo.IsCreate = reader.GetInt32(isCreateIndex);
                }
               
            }
            return createFormTabledo;
        }
        #endregion


        #region Private Variable
        static int REidIndex = 0;
        static int RformIdIndex = 0;
        static int RFormNameIndex = 0;
        static int RUFormNameIndex = 0;
        static int RWorkFolwIndex = 0; 
        static int RisRoleAssignmentIndex = 0;
        static int RDocunemtFormIdIndex = 0;
        static int RDocumentFieldIndex = 0;
        static bool risInisilization = false;
        #endregion
        #region private Static Methods
        private static bool RInisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!risInisilization)
                {
                    REidIndex = reader.GetOrdinal("EId");
                    RformIdIndex = reader.GetOrdinal("FormId");
                    RFormNameIndex = reader.GetOrdinal("FormName");
                    RUFormNameIndex = reader.GetOrdinal("UFormName");
                    RWorkFolwIndex = reader.GetOrdinal("WorkFlow");    
                    RisRoleAssignmentIndex = reader.GetOrdinal("RoleAssignment");
                    RDocunemtFormIdIndex = reader.GetOrdinal("DocumentFormId");
                    RDocumentFieldIndex = reader.GetOrdinal("DocumentFeieldId");
                    risInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static AllFormRoleAssingment RReadData(SqlDataReader reader)
        {
            AllFormRoleAssingment allFormRoleAssingment = new AllFormRoleAssingment();

            if (RInisilizationIndex(reader))
            {
                allFormRoleAssingment.FormId = reader.GetInt64(RformIdIndex);

                if (!reader.IsDBNull(RFormNameIndex))
                {
                    allFormRoleAssingment.FormName = reader.GetString(RFormNameIndex);
                }   
                if (!reader.IsDBNull(RUFormNameIndex))
                {
                    allFormRoleAssingment.UFormName = reader.GetString(RUFormNameIndex);
                }
                if (!reader.IsDBNull(RWorkFolwIndex))
                {
                    allFormRoleAssingment.Workflow = reader.GetInt32(RWorkFolwIndex);
                }
                if (!reader.IsDBNull(REidIndex))
                {
                    allFormRoleAssingment.Eid = reader.GetInt32(REidIndex);
                }
                if (!reader.IsDBNull(RisRoleAssignmentIndex))
                {
                    allFormRoleAssingment.RoleAssignment = reader.GetInt32(RisRoleAssignmentIndex);
                }

                if (!reader.IsDBNull(RDocunemtFormIdIndex))
                {
                    allFormRoleAssingment.DocumentFormId = reader.GetInt32(RDocunemtFormIdIndex);
                }
                if (!reader.IsDBNull(RDocumentFieldIndex))
                {
                    allFormRoleAssingment.DocumentFieldId = reader.GetInt32(RDocumentFieldIndex);
                }
  
  
            }
            return allFormRoleAssingment;
        }
        #endregion

        public void AddRoleAssingment(IsROleAssignmentDo isROleAssignmentDo)
        {
            var documentDataid = isROleAssignmentDo.DocumentDataid.Remove(isROleAssignmentDo.DocumentDataid.ToString().LastIndexOf(','), 1);
            SqlParameter[] para = new SqlParameter[9];
            para[0] = new SqlParameter("@Roleis", isROleAssignmentDo.Roleis);
            para[1] = new SqlParameter("@Userid", isROleAssignmentDo.Userid);
            para[2] = new SqlParameter("@FormId", isROleAssignmentDo.FormId);
            para[3] = new SqlParameter("@DocumentFormId", isROleAssignmentDo.DocumentFormId);
            para[4] = new SqlParameter("@DocumentFields", isROleAssignmentDo.DocumentFields);
            para[5] = new SqlParameter("@DocumentDataid", documentDataid);
            para[6] = new SqlParameter("@IsCreate", isROleAssignmentDo.IsCreate);
            para[7] = new SqlParameter("@IsEdit", isROleAssignmentDo.IsEdit);
            para[8] = new SqlParameter("@IsView", isROleAssignmentDo.IsView);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddRoleAssignMent, para);
        }
        public  IsROleAssignmentDo IsROleAssignment(string FormId, string FieldId, string UserId, string RoleId, string Form)
        {      

            // MenuDTOList menuDTOList = new MenuDTOList();
            IsROleAssignmentDo isROleAssignmentDo = new IsROleAssignmentDo();
            SqlParameter[] para = new SqlParameter[4];
            para[0] = new SqlParameter("@roleis", RoleId);
            para[1] = new SqlParameter("@userid", UserId);
            para[2] = new SqlParameter("@documentFormId", FormId);
            para[3] = new SqlParameter("@documentFields", FieldId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RoleAssignCheck, para))
            {
                try
                {
                   
                      if (InisilizationIndex(reader))
                            if (reader.Read())
                            {
                                isROleAssignmentDo = ReadData(reader);
                            }
                        isInisilization = false;
                  
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return isROleAssignmentDo;
        }


        public  AllFormRoleAssingmentList AllFormRoleAssingment(string Eid)
        {
            AllFormRoleAssingmentList allFormRoleAssingmentList = new AllFormRoleAssingmentList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Eid", Convert.ToInt32(Eid));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllFormRoleAssinment, para))
            {

                AllFormRoleAssingment allFormRoleAssingment = new AllFormRoleAssingment();
                try
                {
                    if (RInisilizationIndex(reader))
                        while (reader.Read())
                        {
                            allFormRoleAssingment = RReadData(reader);
                            allFormRoleAssingmentList.Add(allFormRoleAssingment);
                        }
                    risInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return allFormRoleAssingmentList;
            }

        }
   }
}
