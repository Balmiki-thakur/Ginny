using Reliance.Modals;
using Reliance.SqlDll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceController
{
   public class RuleEnginController
    {
        #region Private Variable
      
        static int IdIndex = 0;
        static int RuleNameIndex = 0;
        static int RuleErrorMessageIndex = 0;
        static int FormIdIndex = 0;
        static int FieldIdIndex = 0;
        static int CategoryNameIndex = 0;
        static int RulesIndex = 0;
        static int CreateOnIdIndex = 0;
        static int LastModifiedIdIndex = 0;
        static int FormFIeldconditionIdIndex = 0;
       static int CompairFieldConditionIndex = 0;
       static int EidIndex = 0;
       static int MainFormIndex = 0;
       static int EquelfieldIndex = 0;
       static int PriceConditionruleIndex = 0;
       static int FieldValueIndex = 0;
       static int FieldConditionidIndex = 0;
        static bool isInisilization = false;

        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
   
                    IdIndex = reader.GetOrdinal("Id");
                    RuleNameIndex = reader.GetOrdinal("RuleName");
                    RuleErrorMessageIndex = reader.GetOrdinal("RuleErrorMessage");
                    FormIdIndex = reader.GetOrdinal("FromId");
                    FieldIdIndex = reader.GetOrdinal("FieldId");
                    RulesIndex = reader.GetOrdinal("Rules");
                    MainFormIndex = reader.GetOrdinal("MainConditon");
                    EquelfieldIndex = reader.GetOrdinal("Equelfield");
                    PriceConditionruleIndex = reader.GetOrdinal("PriceConditionrule");
                    FieldValueIndex = reader.GetOrdinal("FieldValue");
                    FieldConditionidIndex = reader.GetOrdinal("FieldConditionid");
                    // FormFIeldconditionIdIndex = reader.GetOrdinal("FormFIeldcondition");
                    // CompairFieldConditionIndex = reader.GetOrdinal("CompairFieldCondition");
                    // EidIndex = reader.GetOrdinal("Eid");


                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static RuleEnginDo ReadData(SqlDataReader reader)
        {
            RuleEnginDo role = new RuleEnginDo();
            if (InisilizationIndex(reader))
            {            

                if (!reader.IsDBNull(RuleNameIndex))
                {
                    role.RuleName = reader.GetString(RuleNameIndex);
                }
                if (!reader.IsDBNull(RuleErrorMessageIndex))
                {
                    role.ErrorMessage = reader.GetString(RuleErrorMessageIndex);
                }
                if (!reader.IsDBNull(FormIdIndex))
                {
                    role.FormName = reader.GetInt32(FormIdIndex);
                }
                if (!reader.IsDBNull(FieldIdIndex))
                {
                    role.FieldName = reader.GetInt32(FieldIdIndex);
                }
                if (!reader.IsDBNull(RulesIndex))
                {
                    role.Clientcondition = reader.GetString(RulesIndex);
                }
              
                if (!reader.IsDBNull(MainFormIndex))
                {
                    role.MainConditon = reader.GetString(MainFormIndex);
                }
                if (!reader.IsDBNull(FieldValueIndex))
                {
                    role.Fieldvalue = reader.GetString(FieldValueIndex);
                }
                if (!reader.IsDBNull(EquelfieldIndex))
                {
                    role.Equelfield = reader.GetString(EquelfieldIndex);
                }
                 if (!reader.IsDBNull(PriceConditionruleIndex))
                {
                    role.PriceConditionrule = reader.GetString(PriceConditionruleIndex);
                }
                 if (!reader.IsDBNull(FieldConditionidIndex))
                 {
                     role.ConditionField = reader.GetInt32(FieldConditionidIndex);
                 }
            }
            return role;
        }
        #endregion
       public void AddRuleEngin(RuleEnginDo ruleEnginDo)
       {         
           SqlParameter[] para = new SqlParameter[13];
           para[0] = new SqlParameter("@Eid", ruleEnginDo.Eid);
           para[1] = new SqlParameter("@formid", ruleEnginDo.FormName);
           para[2] = new SqlParameter("@fieldid", ruleEnginDo.FieldName);
           para[3] = new SqlParameter("@conditionformid", ruleEnginDo.ConditionFormName);
           para[4] = new SqlParameter("@CompairFieldId", ruleEnginDo.CompairFieldName);
           para[5] = new SqlParameter("@rulename", ruleEnginDo.RuleName);
           para[6] = new SqlParameter("@errormessage", ruleEnginDo.ErrorMessage);
           para[7] = new SqlParameter("@equelfield", ruleEnginDo.Equelfield);       
           para[8] = new SqlParameter("@Clientcondition", ruleEnginDo.Clientcondition);
           para[9] = new SqlParameter("@MainConditon", ruleEnginDo.MainConditon);
           para[10] = new SqlParameter("@FieldValue", ruleEnginDo.Fieldvalue);
           para[11] = new SqlParameter("@PriceConditionrule", ruleEnginDo.PriceConditionrule);
           para[12] = new SqlParameter("@ConditionField", ruleEnginDo.ConditionField);
           SqlDb sqlDb = new SqlDb();
           sqlDb.ExecuteNonQuerySP(StoreProcesureName.InsertRuleEngin, para);
       }
       public static RuleEnginDoList RuleByFormId(string formid)
       {
           RuleEnginDoList roleMasterDoList = new RuleEnginDoList();
           SqlParameter[] para = new SqlParameter[1];
           para[0] = new SqlParameter("@formid", Convert.ToInt32(formid));
           SqlDb sqlDb = new SqlDb();
           using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RuleEnginformId, para))
           {
               RuleEnginDo roleDTO = new RuleEnginDo();
               try
               {
                   if (InisilizationIndex(reader))
                       while (reader.Read())
                       {
                           roleDTO = ReadData(reader);
                           roleMasterDoList.Add(roleDTO);
                       }
                   isInisilization = false;
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               return roleMasterDoList;
           }

       }
       public  static string RuleConditonCheck(string CurrentFeildValue, string ConditionField, string Conditionid,string RuleFieldName)
       {
           var flags = "0";     
           SqlParameter[] para = new SqlParameter[3];     
           para[0] = new SqlParameter("@ConditionField", Convert.ToInt32(ConditionField));
           para[1] = new SqlParameter("@Conditionid", Convert.ToInt32(Conditionid));
           para[2] = new SqlParameter("@RuleFieldName", RuleFieldName);
           SqlDb sqlDb = new SqlDb();
           using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.RuleConditionFieldCheck, para))
           {             
               try
               {
                   if (reader.HasRows)
                   {
                       if (reader.Read())
                       {

                          var flag = reader["DefultName"] is DBNull ? null : reader["DefultName"].ToString();
                           if (Convert.ToInt32(CurrentFeildValue) < Convert.ToInt32(flag))
                           {
                               return "1";
                           }                         
                           //  roleDTO = ReadData(reader);                        
                       }
                   }
               
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               return flags;
           }

       }
    }
}
