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
    public class ReportControllers
    {
        public string ReportQuery(string formid, string FieldId, string FormGridId)
        {
            StringBuilder Joinstring = new StringBuilder();
            string query1 = "";
            var Formids = formid.Remove(formid.ToString().LastIndexOf(','), 1);
            var FieldIds = FieldId.Remove(FieldId.ToString().LastIndexOf(','), 1);
            var FormGridIds = FormGridId.Remove(FormGridId.ToString().LastIndexOf(','), 1);
            string[] Formidsvalues = Formids.Split(',').Select(sValue => sValue.Trim()).ToArray();
            string[] FieldIdvalues = FieldId.Split(',').Select(sValue => sValue.Trim()).ToArray();
            if (Formidsvalues.Count() == 1)
            {

                query1 = " Select id, " + FieldIds + " from " + Formidsvalues[0];

                SqlParameter[] para = new SqlParameter[2];
                para[0] = new SqlParameter("@Query", query1);
                para[1] = new SqlParameter("@FormGridId", FormGridIds);
                SqlDb sqlDb = new SqlDb();
                sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddGridData, para);
                return query1;
            }
            return query1;
        }



        public string ReportJoinQuery(string formid, string FieldId, string FormGridId, string FormJoin)
        {
            string myString = "";
            string JoinFieldCondition = "";
            StringBuilder Joinstrings = new StringBuilder();

            var FormidName = formid.Remove(formid.ToString().LastIndexOf(','), 1);
            var FormFieldId = FieldId.Remove(FieldId.ToString().LastIndexOf(','), 1);
            var FormJoinField = FormGridId.Remove(FormGridId.ToString().LastIndexOf(','), 1);
            var FieldNameFormId = FormJoin.Remove(FormJoin.ToString().LastIndexOf(','), 1);
            var FormFieldIds = FormFieldId.ToString().Split(',');
            Joinstrings.Append(" Select "+ FormidName + ".id, ");
            foreach (var FormField in FormFieldIds)
            {
                Joinstrings.Append(FormidName + "." + FormField + " , ");
            }

            var Formjoin = FormJoinField.ToString().Split(',');
            if (Formjoin.Length == 1)
            {
                for (int i = 0; i < Formjoin.Length; i++)
                {
                    var FormIdvalue = Formjoin[i].ToString().Split('/');
                    string Form = FormIdvalue[0];
                    string Field = FormIdvalue[1];
                    Joinstrings.Append(Form + "." + Field + " , ");
                }
            }
            else {
                for (int i = 0; i < Formjoin.Length-1; i++)
                {
                    var FormIdvalue = Formjoin[i].ToString().Split('/');
                    string Form = FormIdvalue[0];
                    string Field = FormIdvalue[1];
                    Joinstrings.Append(Form + "." + Field + " , ");
                }
            }
      
            Joinstrings = Joinstrings.Remove(Joinstrings.ToString().LastIndexOf(','), 1);
            Joinstrings.Append(" From " + formid);
            var FormName = FormJoinField.ToString().Split(',');
            if (FormName.Length == 1)
            {
                for (int J = 0; J < FormName.Length; J++)
                {
                    var FormNameS = FormName[J].ToString().Split('/');
                    string Form = FormNameS[0];

                    Joinstrings.Append(Form + " , ");

                }
            }
            else 
            {
                for (int J = 0; J < FormName.Length-1; J++)
                {
                    var FormNameS = FormName[J].ToString().Split('/');
                    string Form = FormNameS[0];

                    Joinstrings.Append(Form + " , ");

                }
            }
            Joinstrings = Joinstrings.Remove(Joinstrings.ToString().LastIndexOf(','), 1);
            Joinstrings.Append(" WHERE ");
            var FormJoins = FormJoinField.ToString().Split(',');
            if (FormJoins.Length==1)
            {
                for (int J = 0; J < FormJoins.Length; J++)
                {
                    var FormJoinDate = FormJoins[J].ToString().Split('/');
                    string FormJoinDates = FormJoinDate[0].Trim();
                    string FieldJoinDates = FormJoinDate[1].Trim();
                    var FormIdJoinFields = FieldNameFormId.ToString().Split(',');
                    for (int i = J; i <= J; i++)
                    {
                        var FormIdvalue = FormIdJoinFields[i].ToString().Split('/');
                        string JoinCondition = FormIdvalue[0].Trim();
                        JoinFieldCondition = FormIdvalue[1].Trim();


                        Joinstrings.Append(FormidName + "." + JoinCondition + " = " + FormJoinDates + ".id and ");

                        myString = Convert.ToString(Joinstrings);
                        myString = myString.Remove(myString.Length - 4);
                    }

                }
            }
            else 
            {
                for (int J = 0; J < FormJoins.Length - 1; J++)
                {
                    var FormJoinDate = FormJoins[J].ToString().Split('/');
                    string FormJoinDates = FormJoinDate[0].Trim();
                    string FieldJoinDates = FormJoinDate[1].Trim();
                    var FormIdJoinFields = FieldNameFormId.ToString().Split(',');
                    for (int i = J; i <= J; i++)
                    {
                        var FormIdvalue = FormIdJoinFields[i].ToString().Split('/');
                        string JoinCondition = FormIdvalue[0].Trim();
                        JoinFieldCondition = FormIdvalue[1].Trim();


                        Joinstrings.Append(FormidName + "." + JoinCondition + " = " + FormJoinDates + ".id and ");

                        myString = Convert.ToString(Joinstrings);
                        myString = myString.Remove(myString.Length - 4);
                    }

                }
            
            }
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Query", myString);
            para[1] = new SqlParameter("@FormGridId", JoinFieldCondition);
            SqlDb sqlDb = new SqlDb();
            sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddGridData, para);
            return Convert.ToString(myString);
        }
    }
}
