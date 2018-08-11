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
    public class CreateFormField
    {
        #region Private Variable

        static int fieldIdIndex = 0;
        static int formIdIndex = 0;
        static int fieldNameIndex = 0;
        static int fieldTypeIndex = 0;
        static int createdOnIndex = 0;
        static int lastUpdateOnIndex = 0;
        static int displayOrderIndex = 0;
        static int fieldDesCriptionIndex = 0;
        static int formNameIndex = 0;
        static int documentNameIndex = 0;
        static int documentFieldIndex = 0;
        static int isLooKupndex = 0;
        static int fielddatatypesIndex = 0;
        static int isRoleAssignment = 0;
        static int UFieldNameIndex = 0;
        static int IsDDLFilterIndex = 0;
        static int isimeinoIndex = 0;
        static int minLenghtIndex = 0;
        static int maxlenghtIndex = 0;
        static int EidIndex = 0;
        static int FormulaFieldIndex = 0;
        static int FormWorkFlowIndex = 0;

        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    fieldIdIndex = reader.GetOrdinal("FieldId");
                    formIdIndex = reader.GetOrdinal("FormId");
                    fieldNameIndex = reader.GetOrdinal("FieldName");
                    fieldTypeIndex = reader.GetOrdinal("FieldType");
                    createdOnIndex = reader.GetOrdinal("CreatedOn");
                    lastUpdateOnIndex = reader.GetOrdinal("LastUpdateOn");
                    displayOrderIndex = reader.GetOrdinal("DisplayOrder");
                    fieldDesCriptionIndex = reader.GetOrdinal("FieldDesCription");
                    formNameIndex = reader.GetOrdinal("FormName");
                    documentNameIndex = reader.GetOrdinal("DocumentType");
                    documentFieldIndex = reader.GetOrdinal("DocumentField");
                    isLooKupndex = reader.GetOrdinal("IsLooKup");
                    fielddatatypesIndex = reader.GetOrdinal("Datatypes");
                    isRoleAssignment = reader.GetOrdinal("IsRoleAssignment");
                    UFieldNameIndex = reader.GetOrdinal("UFieldName");
                    IsDDLFilterIndex = reader.GetOrdinal("IsDDLFilter");
                    isimeinoIndex=reader.GetOrdinal("IsIMIE");
                    maxlenghtIndex  = reader.GetOrdinal("MaxLenght");
                    minLenghtIndex = reader.GetOrdinal("MinLenght");
                    EidIndex = reader.GetOrdinal("EId");
                    FormulaFieldIndex = reader.GetOrdinal("FormulaField");
                    FormWorkFlowIndex = reader.GetOrdinal("WorkFlow");
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static FormsFields ReadData(SqlDataReader reader)
        {
            FormsFields formsRoleDo = new FormsFields();
            if (InisilizationIndex(reader))
            {
                formsRoleDo.FieldId = reader.GetInt64(fieldIdIndex);

                if (!reader.IsDBNull(formIdIndex))
                {
                    formsRoleDo.FormId = reader.GetInt64(formIdIndex);
                }
                if (!reader.IsDBNull(fieldNameIndex))
                {
                    formsRoleDo.Display_name = reader.GetString(fieldNameIndex);
                }
                if (!reader.IsDBNull(fieldTypeIndex))
                {
                    formsRoleDo.Field_type = reader.GetString(fieldTypeIndex);
                }
                if (!reader.IsDBNull(createdOnIndex))
                {
                    formsRoleDo.CreateOn = Convert.ToString(reader.GetDateTime(createdOnIndex));
                }
                if (!reader.IsDBNull(formNameIndex))
                {
                    formsRoleDo.FormName = reader.GetString(formNameIndex);
                }
                if (!reader.IsDBNull(displayOrderIndex))
                {
                    formsRoleDo.Order_number = reader.GetInt32(displayOrderIndex);
                }
                if (!reader.IsDBNull(fieldDesCriptionIndex))
                {
                    formsRoleDo.Field_description = reader.GetString(fieldDesCriptionIndex);
                }
                if (!reader.IsDBNull(documentNameIndex))
                {
                    formsRoleDo.DocumentName = reader.GetString(documentNameIndex);
                }
                if (!reader.IsDBNull(documentFieldIndex))
                {
                    formsRoleDo.DocumentField = reader.GetString(documentFieldIndex);
                }
                if (!reader.IsDBNull(isLooKupndex))
                {
                    formsRoleDo.IsLookUp = reader.GetInt32(isLooKupndex);
                }
                if (!reader.IsDBNull(fielddatatypesIndex))
                {
                    formsRoleDo.DataTypes = reader.GetString(fielddatatypesIndex);
                }

                if (!reader.IsDBNull(isRoleAssignment))
                {
                    formsRoleDo.IsRoleAssignment = reader.GetInt32(isRoleAssignment);
                }
                if (!reader.IsDBNull(UFieldNameIndex))
                {
                    formsRoleDo.UFieldName = reader.GetString(UFieldNameIndex);
                }
                if (!reader.IsDBNull(IsDDLFilterIndex))
                {
                    formsRoleDo.IsDDLFilter = reader.GetInt32(IsDDLFilterIndex);
                }
                if (!reader.IsDBNull(isimeinoIndex))
                {
                    formsRoleDo.IsIMEINo = reader.GetInt32(isimeinoIndex);
                }
                if (!reader.IsDBNull(maxlenghtIndex))
                {
                    formsRoleDo.MaxLenght = reader.GetInt32(maxlenghtIndex);
                }
                if (!reader.IsDBNull(minLenghtIndex))
                {
                    formsRoleDo.MinLenght = reader.GetInt32(minLenghtIndex);
                }
                if (!reader.IsDBNull(EidIndex))
                {
                    formsRoleDo.Eid = reader.GetInt32(EidIndex);
                }
                if (!reader.IsDBNull(FormulaFieldIndex))
                {
                    formsRoleDo.FormulaField = reader.GetString(FormulaFieldIndex);
                }
                if (!reader.IsDBNull(FormWorkFlowIndex))
                {
                    formsRoleDo.FormWorkFlow = reader.GetInt32(FormWorkFlowIndex);
                }
            }
            return formsRoleDo;
        }

        private static bool InisilizationLookUpIndex(SqlDataReader reader)
        {
            if (reader.HasRows) 
            {
                if (!isInisilization)
                {

                    fieldIdIndex = reader.GetOrdinal("FieldId");

                    formIdIndex = reader.GetOrdinal("FormId");
                    formNameIndex = reader.GetOrdinal("FormName");
                    fieldNameIndex = reader.GetOrdinal("FieldName");
                    documentNameIndex = reader.GetOrdinal("DocumentType");
                    documentFieldIndex = reader.GetOrdinal("DocumentField");

                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static bool InisilizationLookUpFieldIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    fieldIdIndex = reader.GetOrdinal("FieldId");
                    fieldNameIndex = reader.GetOrdinal("FieldName");
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static FormsFields ReadLookUpFieldData(SqlDataReader reader)
        {
            FormsFields formsRoleDo = new FormsFields();
            if (InisilizationLookUpFieldIndex(reader))
            {
                if (!reader.IsDBNull(fieldNameIndex))
                {
                    formsRoleDo.FieldId = reader.GetInt64(fieldIdIndex);
                    formsRoleDo.Display_name = reader.GetString(fieldNameIndex);
                }

            }
            return formsRoleDo;
        }
        private static FormsFields ReadLookUpData(SqlDataReader reader)
        {
            FormsFields formsRoleDo = new FormsFields();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(fieldIdIndex))
                {
                    formsRoleDo.FieldId = reader.GetInt64(fieldIdIndex);
                }
                if (!reader.IsDBNull(formIdIndex))
                {
                    formsRoleDo.FormId = reader.GetInt64(formIdIndex);
                }

                if (!reader.IsDBNull(formNameIndex))
                {
                    formsRoleDo.FormName = reader.GetString(formNameIndex);
                }
                if (!reader.IsDBNull(fieldNameIndex))
                {
                    formsRoleDo.Display_name = reader.GetString(fieldNameIndex);
                }

                if (!reader.IsDBNull(documentNameIndex))
                {
                    formsRoleDo.DocumentName = reader.GetString(documentNameIndex);
                }
                if (!reader.IsDBNull(documentFieldIndex))
                {
                    formsRoleDo.DocumentField = reader.GetString(documentFieldIndex);
                }

            }
            return formsRoleDo;
        }
      
        public  void InsertMetada(string deviceType, TextBoxList deviceFields)
        {

            StringBuilder strb = new StringBuilder();
            // deviceType.TrimEnd(',');
            strb.Append(string.Format("INSERT INTO TextFields{0} ( ", deviceType.ToString().ToUpper()));
            // var count = deviceFields.Count;
            foreach (var item in deviceFields)
            {

                strb.Append(string.Format(" {0}, ", item.FieldId.ToString()));
            }
            var index1 = strb.ToString().LastIndexOf(',');
            if (index1 >= 0)
                strb.Remove(index1, 1);
            // deviceFields.RemoveAt(deviceFields.Count - 1);
            strb.Append(") VALUES ( ");
            foreach (var item in deviceFields)
            {
                strb.Append(string.Format(" '{0}', ", item.Value.ToString()));


            }
            var index = strb.ToString().LastIndexOf(',');
            if (index >= 0)
                strb.Remove(index, 1);
            strb.Append(")");
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQueryQuery(strb.ToString());
        }
        #endregion
        public  void AddFormField(FormsFields formsroledo)
        {
            // MenuDTO menudto = new MenuDTO();
            SqlParameter[] para = new SqlParameter[6];
            para[0] = new SqlParameter("@FieldName", formsroledo.Display_name);
            para[1] = new SqlParameter("@FormName", formsroledo.FormName);
            para[2] = new SqlParameter("@FormId", formsroledo.FormId);
            para[3] = new SqlParameter("@Datatype", formsroledo.SelectedField);
            para[4] = new SqlParameter("@displayOrder", formsroledo.Order_number);
            para[5] = new SqlParameter("@FieldDescription", formsroledo.Field_description);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddFormFields, para);
        }
        public  FormRoleList FieldByFormId(string formId, string CompanyId)
        {
            FormRoleList formRoleList = new FormRoleList();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@formId", Convert.ToInt32(formId));
            para[1] = new SqlParameter("@Eid", Convert.ToInt32(CompanyId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.FieldbyFormId, para))
            {
                FormsFields formsFields = new FormsFields();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {

                            formsFields = ReadData(reader);

                            formRoleList.Add(formsFields);

                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return formRoleList;
        }
        public  FormRoleList AllFormLookUp(string formId)
        {
            FormRoleList LookUpList = new FormRoleList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@formId", Convert.ToInt32(formId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllLookUpForm, para))
            {
                FormsFields formLookUpField = new FormsFields();
                try
                {
                    if (InisilizationLookUpIndex(reader))
                        while (reader.Read())
                        {
                            formLookUpField = ReadLookUpData(reader);
                            LookUpList.Add(formLookUpField);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
                return LookUpList;
            }
        }
        public  FormRoleList AllFieldLookUp(string FieldId)
        {
            FormRoleList LookUpList = new FormRoleList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@FieldId", Convert.ToInt32(FieldId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllLookUpField, para))
            {
                FormsFields formLookUpField = new FormsFields();
                try
                {
                    if (InisilizationLookUpFieldIndex(reader))
                        while (reader.Read())
                        {
                            formLookUpField = ReadLookUpFieldData(reader);
                            LookUpList.Add(formLookUpField);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;

                }
                return LookUpList;
            }
        }
        public  FormRoleList AllFieldByFormId(string Index)
        {
            FormRoleList formRoleList = new FormRoleList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@formId", Index);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.ReportFieldbyFormId, para))
            {
                FormsFields formsFields = new FormsFields();

                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {

                            formsFields = ReadData(reader);

                            formRoleList.Add(formsFields);

                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return formRoleList;
        }
        public  FormRoleList JoinQuery(string formId)
        {
            FormRoleList formRoleList = new FormRoleList();

            var Formids = formId.Remove(formId.ToString().LastIndexOf(','), 1);
            var FormIdFields = formId.ToString().Split(',');
            for(int i=0;i< FormIdFields.Length-1;i++)
            {
            var FormIdvalue = FormIdFields[i].ToString().Split('/');
           // string[] Formidsvalues = Formids.Split('/', ',').Select(sValue => sValue.Trim()).ToArray();            
            FormsFields formsRoleDo = new FormsFields();
           
                formsRoleDo.UFieldName = FormIdvalue[0];
                formsRoleDo.FieldId = Convert.ToInt64(FormIdvalue[1]);
               



                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@formId", formsRoleDo.FieldId);
                para[1] = new SqlParameter("@FieldName", formsRoleDo.UFieldName);
                SqlDb sqlDb = new SqlDb();
                using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.joinFieldbyFormId, para))
                {
                    FormsFields formsFields = new FormsFields();

                    try
                    {
                        if (InisilizationIndex(reader))
                            while (reader.Read())
                            {
                                formsFields = ReadData(reader);
                                formRoleList.Add(formsFields);
                            }
                        isInisilization = false;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return formRoleList;
        }
        public  FormRoleList FieldForAproveNeedtoAct(int FormIds, string StatusName)
        {
            FormRoleList formRoleList = new FormRoleList();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@formId", FormIds);
            para[1] = new SqlParameter("@DocStatus", StatusName);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AproveActionField, para))
            {
                FormsFields formsFields = new FormsFields();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {

                            formsFields = ReadData(reader);

                            formRoleList.Add(formsFields);

                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return formRoleList;
        }


        public  FormRoleList FieldForRejectNeedtoAct(int FormIds, string StatusName)
        {
            FormRoleList formRoleList = new FormRoleList();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@formId", FormIds);
            para[1] = new SqlParameter("@DocStatus", StatusName);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AproveActionField, para))
            {
                FormsFields formsFields = new FormsFields();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {

                            formsFields = ReadData(reader);

                            formRoleList.Add(formsFields);

                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return formRoleList;
        }
    }
}