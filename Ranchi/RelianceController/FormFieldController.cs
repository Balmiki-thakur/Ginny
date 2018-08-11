using Reliance.Modals;
using Reliance.SqlDll;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceController
{
    public class FormFieldController 
    {
        #region Private Variable

        static int formIdIndex = 0;
        static int FormLoolUpIdIndex = 0;
        static int FormLoolUpNameIndex = 0;
        static int CompanyIdIndex = 0;
        static int fieldTypeIndex = 0;
        static int displayorderIndex = 0;
        static int DisplayNameIndex = 0;
        static int CreatedOnIndex = 0;
        static int fieldDescriptonIndex = 0;
        static int fielddatatypesIndex = 0;
        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    formIdIndex = reader.GetOrdinal("Field_Id");
                    //  CompanyIdIndex = reader.GetOrdinal("CompanyId");
                    DisplayNameIndex = reader.GetOrdinal("Display_Name");
                    fieldTypeIndex = reader.GetOrdinal("Field_Type");
                    displayorderIndex = reader.GetOrdinal("Display_Order");
                    CreatedOnIndex = reader.GetOrdinal("CreatedOn");
                    fieldDescriptonIndex = reader.GetOrdinal("FieldDiscription");
                    FormLoolUpIdIndex = reader.GetOrdinal("FormId");
                    FormLoolUpNameIndex = reader.GetOrdinal("FormName");
                    fielddatatypesIndex = reader.GetOrdinal("Datatypes");
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
                formsRoleDo.FieldId = reader.GetInt32(formIdIndex);

                if (!reader.IsDBNull(CompanyIdIndex))
                {
                    // formsRoleDo.CompanyId = reader.GetInt32(CompanyIdIndex);
                }
                if (!reader.IsDBNull(DisplayNameIndex))
                {
                    formsRoleDo.Display_name = reader.GetString(DisplayNameIndex);
                }

                if (!reader.IsDBNull(CreatedOnIndex))
                {
                    formsRoleDo.CreateOn = reader.GetString(CreatedOnIndex);
                }
                if (!reader.IsDBNull(fieldDescriptonIndex))
                {
                    formsRoleDo.Field_description = reader.GetString(fieldDescriptonIndex);
                }
                if (!reader.IsDBNull(displayorderIndex))
                {

                    formsRoleDo.Order_number = reader.GetInt32(displayorderIndex);
                }
                if (!reader.IsDBNull(fieldTypeIndex))
                {
                    formsRoleDo.Field_type = reader.GetString(fieldTypeIndex);
                }



                if (!reader.IsDBNull(FormLoolUpIdIndex))
                {
                    formsRoleDo.FormId = reader.GetInt64(FormLoolUpIdIndex);
                }
                if (!reader.IsDBNull(FormLoolUpNameIndex))
                {
                    formsRoleDo.FormName = reader.GetString(FormLoolUpNameIndex);
                }
                if (!reader.IsDBNull(fielddatatypesIndex))
                {
                    formsRoleDo.DataTypes = reader.GetString(fielddatatypesIndex);
                }

            }
            return formsRoleDo;
        }
        #endregion
        public  FormRoleList AllFormFields()
        {
            FormRoleList formsRolelist = new FormRoleList();
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllFields))
            {

                FormsFields formsRoleDo = new FormsFields();
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

        public static FormsFields FieldByFormId(int formId)
        {
            // MenuDTOList menuDTOList = new MenuDTOList();
            FormsFields formsFields = new FormsFields();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@formId", formId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.FieldbyFormId, para))
            {

                try
                {
                    if (InisilizationIndex(reader))
                        if (reader.Read())
                        {
                            formsFields = ReadData(reader);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return formsFields;
        }
       
        #region public InsertMethod
        public  void AddFormField(FormsFields formsroledo)
        {
            SqlParameter[] para = new SqlParameter[14];
            para[0] = new SqlParameter("@FieldName", formsroledo.Display_name);
            para[1] = new SqlParameter("@FormName", formsroledo.FormName);
            para[2] = new SqlParameter("@FormId", formsroledo.FormId);
            para[3] = new SqlParameter("@Datatype", formsroledo.SelectedField);
            para[4] = new SqlParameter("@displayOrder", formsroledo.Order_number);
            para[5] = new SqlParameter("@FieldDescription", formsroledo.Field_description);
            para[6] = new SqlParameter("@dcumentName", formsroledo.DocumentName);
            para[7] = new SqlParameter("@documentField", formsroledo.DocumentField);
            para[8] = new SqlParameter("@masterFieldDropDownId", formsroledo.DocumentFieldId);
            para[9] = new SqlParameter("@dataway",     formsroledo.DataTypes);
            para[10] = new SqlParameter("@uFieldName", formsroledo.UFieldName);
            para[11] = new SqlParameter("@Eid",        formsroledo.Eid);
            para[12] = new SqlParameter("@MaxLenght",  formsroledo.MaxLenght);
            para[13] = new SqlParameter("@MinLenght",  formsroledo.MinLenght);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddFormFields, para);
        }
        public  TextBoxViewModel InsertMetada(string formName, string deviceType, TextBoxList deviceFields)
        {
            TextBoxViewModel textBoxList = new TextBoxViewModel();
            StringBuilder strb = new StringBuilder();            
            // deviceType.TrimEnd(',');
            strb.Append(string.Format("INSERT INTO {0} {1}( ", formName, deviceType.ToString().ToUpper()));
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
           string Query = strb.ToString();       
            SqlParameter[] para = new SqlParameter[1];
              para[0] = new SqlParameter("@strb", Query.ToString());
              SqlDb sqlDb = new SqlDb();
              var Output = sqlDb.ExecuteScalarSP(StoreProcesureName.InsertMasterData, para);
              
              textBoxList.IdentityId = Convert.ToInt32(Output);
              return textBoxList;
     
        }
        public  void UpdateMasterField(string formName, string id, string deviceType, TextBoxList deviceFields)
        {
            
            TextBoxViewModel textBoxViewModel = new TextBoxViewModel();
            StringBuilder strb = new StringBuilder();

            strb.Append(" update " + formName + " Set ");

            foreach (var item in deviceFields)
            {
                strb.Append("" + item.FieldId.ToString() + "= '" + item.Value.ToString() + "' , ");
            }
            var Index = strb.ToString().LastIndexOf(',');

            strb.Append("  where  Id= " + id);

            if (Index >= 0)
                strb.Remove(Index, 1);
            {
                SqlDb sqlDb = new SqlDb();
                sqlDb.ExecuteNonQueryQuery(strb.ToString());
            }
        }     
        #endregion
        public  IEnumerable<dynamic> SelectMethod(string FormName)
        {

            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@formid", FormName);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllformDynamicData, para))
            {
                var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                //foreach (IDataRecord record in reader as IEnumerable)
                //{
                //    var expando = new ExpandoObject() as IDictionary<string, object>;
                //    foreach (var name in names)
                //        expando[name] = record[name];

                //    // yield return expando;
                //}
                yield return names;
            }
        }
        public  IEnumerable<dynamic> SelectMethod1(string FormName)
        {
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@formid", FormName);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllformDynamicData, para))
            {
                var names = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                foreach (IDataRecord record in reader as IEnumerable)
                {
                    var expando = new ExpandoObject() as IDictionary<string, object>;
                    foreach (var name in names)
                        expando[name] = record[name];
                    yield return expando.Values;
                }
                //  yield return names;
            }
        }
        public  DropDownValueDoList DropDownbind(string tableName, string ColloumName)
        {
            DropDownValueDoList dropDownValueDoList = new DropDownValueDoList();
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@formName", tableName);
            pram[1] = new SqlParameter("@colloumName", ColloumName);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.DropDownSP, pram))
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!isInisilization)
                        {
                            DropDownValueDo dropdownvalue = new DropDownValueDo();
                            dropdownvalue.Values = reader[ColloumName] is DBNull ? null : reader[ColloumName].ToString();
                            dropdownvalue.Key = reader["Id"].ToString();
                            dropdownvalue.FormName = reader["formName"].ToString();
                            isInisilization = true;
                            dropDownValueDoList.Add(dropdownvalue);
                        }
                        isInisilization = false;
                    }
                }
                return dropDownValueDoList;
            }

        }
        public  DropDownValueDoList DropDownvaluebind(string FormId, string FieldId)
        {
            DropDownValueDoList dropDownValueDoList = new DropDownValueDoList();
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@fromId", FormId);
            pram[1] = new SqlParameter("@fieldId", FieldId);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.DropDownbindSP, pram))
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
        public  DropDownValueDoList DropDownFunctionbind(string colloumType, string formName, string fieldtype, string fieldName, string ColloumName)
        {
            DropDownValueDoList dropDownValueDoList = new DropDownValueDoList();
            SqlParameter[] pram = new SqlParameter[5];
            pram[0] = new SqlParameter("@colloumType", colloumType);
            pram[1] = new SqlParameter("@formName", formName);
            pram[2] = new SqlParameter("@fieldtype", fieldtype);
            pram[3] = new SqlParameter("@fieldName", fieldName);
            pram[4] = new SqlParameter("@colloumName", ColloumName);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.DropDownFunctionSp, pram))
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!isInisilization)
                        {
                            DropDownValueDo dropdownvalue = new DropDownValueDo();
                            dropdownvalue.Values = reader["ColumName"] is DBNull ? null : reader["ColumName"].ToString();
                            dropdownvalue.Key = reader["Id"].ToString();
                            isInisilization = true;
                            dropDownValueDoList.Add(dropdownvalue);
                        }
                        isInisilization = false;
                    }
                }
                return dropDownValueDoList;
            }

        }
        //public static ListLooKup LookUpDataValue(string currentFieldId, string Id)
        //{
        //    ListLooKup listLooKup = new ListLooKup();
        //    SqlParameter[] pram = new SqlParameter[3];
        //    pram[0] = new SqlParameter("@fieldId", currentFieldId);
        //    pram[1] = new SqlParameter("@LookUpId", Convert.ToInt32(Id));
        //    using (SqlDataReader reader = SqlDb.GetDataReaderSP(StoreProcesureName.checkParentDropDown, pram))
        //    {
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                if (!isInisilization)
        //                {
        //                    LooKUPDO looKUPDO = new LooKUPDO();
        //                    looKUPDO.LookUpData = reader["ColumName"] is DBNull ? null : reader["ColumName"].ToString();
        //                    looKUPDO.Id = reader["Id"].ToString();
        //                    looKUPDO.LookUpId = reader["LookUpId"].ToString();
        //                    isInisilization = true;
        //                    listLooKup.Add(looKUPDO);
        //                }
        //                isInisilization = false;
        //            }
        //        }
        //        return listLooKup;
        //    }

        //}
        public  ListLooKup LookUpDataValue(string currentFieldId, string Id)
        {

            ListLooKup listLooKup = new ListLooKup();
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@fieldId", currentFieldId);
            pram[1] = new SqlParameter("@Id", Convert.ToInt32(Id));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.CheckData, pram))
            {
                while (reader.Read())
                {
                    string lookUpfieldName = reader[0].ToString();
                    SqlParameter[] prams = new SqlParameter[3];
                    prams[0] = new SqlParameter("@fieldId", currentFieldId);
                    prams[1] = new SqlParameter("@Id", Convert.ToInt32(Id));
                    prams[2] = new SqlParameter("@dynamicColloum", lookUpfieldName);
                   
                    using (SqlDataReader readers = sqlDb.GetDataReaderSP(StoreProcesureName.MasterLookupdata, prams))
                    {
                        while (readers.Read())
                        {
                            if (readers.HasRows)
                            {
                                if (!isInisilization)
                                {
                                    int dbFields = readers.FieldCount;
                                    int j = (dbFields - 1) / 2;
                                    for (int i = 1; i <= j; i++)
                                    {
                                        int k = j + i;
                                        LooKUPDO looKUPDO = new LooKUPDO();
                                        looKUPDO.LookUpData = readers.GetValue(i).ToString();
                                        looKUPDO.LookUpId = readers.GetValue(k).ToString();
                                        listLooKup.Add(looKUPDO);
                                    }
                                    isInisilization = false;
                                }

                            }
                        }

                    }


                }
                return listLooKup;

            }
            //  return listLooKup;
        }

        public  DropDownValueDoList DDlFilterDataValue(string currentFieldId, string Id)
        {
            DropDownValueDoList dropDownValueDoList = new DropDownValueDoList();
            SqlParameter[] pram = new SqlParameter[2];
            pram[0] = new SqlParameter("@fieldId", currentFieldId);
            pram[1] = new SqlParameter("@Id", Convert.ToInt32(Id));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.DDlFilterData, pram))
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
            //  return listLooKup;
        }

        public EditDynamicDataList EditDynamicData(string formid, string Id)
        {
            EditDynamicDataList editdynamicdataList = new EditDynamicDataList();
            SqlParameter[] prams = new SqlParameter[1];
            prams[0] = new SqlParameter("@FormId", formid);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader readers = sqlDb.GetDataReaderSP(StoreProcesureName.FormFieldsType, prams))
            {
                while (readers.Read())
                {
                    if (readers.HasRows)
                    {
                        if (!isInisilization)
                        {

                            SqlParameter[] pram = new SqlParameter[2];
                            pram[0] = new SqlParameter("@FormId", formid);
                            pram[1] = new SqlParameter("@Id", Convert.ToInt32(Id));
                            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.EditField, pram))
                            {
                                EditDynamicDataDo editdynamicdatado = new EditDynamicDataDo();

                                while (reader.Read())
                                {
                                    if (reader.HasRows)
                                    {
                                        if (!isInisilization)
                                        {
                                            editdynamicdatado.FormId = readers["FormId"] is DBNull ? null : readers["FormId"].ToString();
                                            editdynamicdatado.FieldId = readers["FieldId"] is DBNull ? null : readers["FieldId"].ToString();
                                            editdynamicdatado.FieldName = readers["FieldName"] is DBNull ? null : readers["FieldName"].ToString();
                                            editdynamicdatado.FieldType = readers["FieldType"] is DBNull ? null : readers["FieldType"].ToString();
                                            editdynamicdatado.DocumentType = readers["DocumentType"] is DBNull ? null : readers["DocumentType"].ToString();
                                            editdynamicdatado.DocumentField = readers["DocumentField"] is DBNull ? null : readers["DocumentField"].ToString();
                                            editdynamicdatado.FieldValue = reader[editdynamicdatado.FieldName] is DBNull ? null : reader[editdynamicdatado.FieldName].ToString();
                                            editdynamicdatado.IsLooKup = readers["IsLooKup"] is DBNull ? null : readers["IsLooKup"].ToString();
                                            editdynamicdatado.DataType = readers["Datatypes"] is DBNull ? null : readers["Datatypes"].ToString();
                                            editdynamicdatado.FormName = readers["FormName"] is DBNull ? null : readers["FormName"].ToString();
                                            editdynamicdatado.IsRoleAssignment = readers["IsRoleAssignment"] is DBNull ? null : readers["IsRoleAssignment"].ToString();
                                            editdynamicdataList.Add(editdynamicdatado);
                                            isInisilization = false;
                                        }

                                    }

                                }

                            }
                           
                        }
                    }
                }
                return editdynamicdataList;
            }
        }
        public  List<string> GetAutoComplet(string Prefix,string FormId, string FieldId)
        {  
          string FieldIds="15";
           string FormIds="14";
           List<string> empResult = new List<string>();  
            SqlParameter[] prams = new SqlParameter[3];
            prams[0] = new SqlParameter("@term", Prefix);
            prams[1] = new SqlParameter("@fieldId", FieldIds);
            prams[2] = new SqlParameter("@fromId", FormIds);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AutoComplete, prams))
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        if (!isInisilization)
                        {
                           
                            string Values = reader["DefutColloum"] is DBNull ? null : reader["DefutColloum"].ToString();
                            string Key = reader["Id"].ToString();
                            // dropdownvalue.FormName = reader["formName"].ToString();
                            isInisilization = true;
                            empResult.Add(Values);
                        }
                        isInisilization = false;
                    }
                }

            }
            return empResult;
       }
        public  DropDownValueDoList DropDownvaluewithRole(string FormId, string FieldId,string isRole)
        {
            DropDownValueDoList dropDownValueDoList = new DropDownValueDoList();
            SqlParameter[] pram = new SqlParameter[3];
            pram[0] = new SqlParameter("@fromId", FormId);
            pram[1] = new SqlParameter("@fieldId", FieldId);
            pram[2] = new SqlParameter("@RoleId", isRole);
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.DropDownbindSPwithIsRole, pram))
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





    }
}  


