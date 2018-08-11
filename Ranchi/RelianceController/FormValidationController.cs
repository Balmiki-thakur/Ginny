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
   public class FormValidationController
   {
       #region Private Variable
       private static int IdIndex;
       private static int CompanIdIndex;
       private static int formIdIndex;
       private static int FieldIdIndex;
       private static int ValidationTypeIndex;
       private static int OperatorIndex;
       private static int valueIndex;
       private static int ErrorMessageIndex;
       private static int DocNatureIndex;
       private static int CreateOnIndex;
       private static bool isInisilization;

       #endregion
       #region private Method 
       private static bool InisilizationIndex(SqlDataReader reader)
       {
           if (reader.HasRows)
           {
               if (!isInisilization)
               {
                   IdIndex = reader.GetOrdinal("Id");
                   CompanIdIndex = reader.GetOrdinal("CompanyId");
                   formIdIndex = reader.GetOrdinal("FormId");
                   FieldIdIndex = reader.GetOrdinal("FieldId");
                   valueIndex = reader.GetOrdinal("Value");
                   ErrorMessageIndex = reader.GetOrdinal("ErrorMessage");
                   DocNatureIndex = reader.GetOrdinal("DocNature");
                   CreateOnIndex = reader.GetOrdinal("CreateON");
                   ValidationTypeIndex = reader.GetOrdinal("ValidationType");
                   isInisilization = true;
               }
               return true;
           }
           return false;
       }
       private static FieldValidationDO ReadData(SqlDataReader reader)
       {
           FieldValidationDO fieldvalidationDO = new FieldValidationDO();
           if (InisilizationIndex(reader))
           {
               fieldvalidationDO.id = reader.GetInt32(IdIndex);

               if (!reader.IsDBNull(CompanIdIndex))
               {
                   fieldvalidationDO.CompanyId = reader.GetInt32(CompanIdIndex);
               }
               if (!reader.IsDBNull(formIdIndex))
               {
                   fieldvalidationDO.FormId = reader.GetInt32(formIdIndex);
               }

               if (!reader.IsDBNull(FieldIdIndex))
               {
                   fieldvalidationDO.FieldId = reader.GetInt32(FieldIdIndex);
               }
               if (!reader.IsDBNull(ValidationTypeIndex))
               {
                   fieldvalidationDO.ValidationType = reader.GetInt32(ValidationTypeIndex);
               }
               if (!reader.IsDBNull(OperatorIndex))
               {
                   fieldvalidationDO.Operator = reader.GetInt32(OperatorIndex);
               }
               if (!reader.IsDBNull(valueIndex))
               {
                   fieldvalidationDO.Value = reader.GetString(valueIndex);
               }


               if (!reader.IsDBNull(ErrorMessageIndex))
               {
                   fieldvalidationDO.ErrorMsg = reader.GetString(ErrorMessageIndex);
               }
               if (!reader.IsDBNull(DocNatureIndex))
               {
                   fieldvalidationDO.DocNature = reader.GetInt32(DocNatureIndex);
               }
               if (!reader.IsDBNull(CreateOnIndex))
               {
                   fieldvalidationDO.CreateON = reader.GetDateTime(CreateOnIndex);
               }

           }
           return fieldvalidationDO;
       }
       #endregion


       public  void AddFieldValidation(FieldValidationDO fieldvalidationDO)
       {
           // MenuDTO menudto = new MenuDTO();
           SqlParameter[] para = new SqlParameter[7];
           para[0] = new SqlParameter("@FieldId", fieldvalidationDO.FieldId);
           para[1] = new SqlParameter("@FormId", fieldvalidationDO.FormId);
           para[2] = new SqlParameter("@ValidationType", fieldvalidationDO.ValidationType);
           para[3] = new SqlParameter("@Operator", fieldvalidationDO.Operator);
           para[4] = new SqlParameter("@Value", fieldvalidationDO.Value);
           para[5] = new SqlParameter("@DocNature", fieldvalidationDO.DocNature);
           para[6] = new SqlParameter("@Errormessage", fieldvalidationDO.ErrorMsg);
           SqlDb sqlDb = new SqlDb();
           sqlDb.ExecuteNonQuerySP(StoreProcesureName.FieldValidation, para);
       }


       public  FieldValidationList FormvalidationbyFormid(string formid)
       {
           FieldValidationList fieldValidationList = new FieldValidationList();
           SqlParameter[] para = new SqlParameter[1];
           para[0] = new SqlParameter("@formId", Convert.ToInt32(formid));
           SqlDb sqlDb = new SqlDb();
           using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.validationbyFormId, para))
           {
               FieldValidationDO fieldValidationDO = new FieldValidationDO();
               try
               {
                   if (InisilizationIndex(reader))
                       while (reader.Read())
                       {
                           fieldValidationDO = ReadData(reader);
                           fieldValidationList.Add(fieldValidationDO);
                       }
                   isInisilization = false;
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           return fieldValidationList;

       
       }
   }
}
