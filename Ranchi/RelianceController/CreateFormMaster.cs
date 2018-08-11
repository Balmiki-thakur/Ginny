using Reliance.Modals;
using Reliance.SqlDll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace RelianceController
{
   public class CreateFormMaster
    {
        #region Private Variable
        static int formIdIndex = 0;
        static int FormNameIndex = 0;
        static int CreatedOnIndex = 0;
        static int lastmodifiedOnIndex = 0;
        static int FormDiscriptionIndex = 0;
        static int FormLayoutIndex = 0;
        static int UFormNameIndex = 0;
        static int WorkFolwIndex = 0;
        static int EidIndex = 0;
        static int isRoleAssignmentIndex = 0;       
        static int formSourceIndex = 0;
        static int statusActionIndex = 0;
        static int DocStatusIndex = 0;
        static int DocumentIdIndex = 0;
        static bool isInisilization = false;
        #endregion
        #region private Static Methods
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    formIdIndex = reader.GetOrdinal("FormId");
                    FormNameIndex = reader.GetOrdinal("FormName");
                    CreatedOnIndex = reader.GetOrdinal("CreatedOn");
                    lastmodifiedOnIndex = reader.GetOrdinal("LastModifiedOn");
                    FormDiscriptionIndex = reader.GetOrdinal("FormDiscription");
                    FormLayoutIndex = reader.GetOrdinal("FormLayout");
                    UFormNameIndex = reader.GetOrdinal("UFormName");
                    WorkFolwIndex = reader.GetOrdinal("WorkFlow");
                    EidIndex = reader.GetOrdinal("EId");
                    isRoleAssignmentIndex = reader.GetOrdinal("RoleAssignment");
                    formSourceIndex = reader.GetOrdinal("FromSource");
                    statusActionIndex = reader.GetOrdinal("StatusAction");
                    DocStatusIndex = reader.GetOrdinal("DocStatus");
                    DocumentIdIndex = reader.GetOrdinal("DocumentId");
                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static CreateFormTableDo ReadData(SqlDataReader reader)
        {
            CreateFormTableDo createFormTabledo = new CreateFormTableDo();   
            if (InisilizationIndex(reader))
            {
                createFormTabledo.Id = reader.GetInt64(formIdIndex);

                if (!reader.IsDBNull(FormNameIndex))
                {
                    createFormTabledo.FormName = reader.GetString(FormNameIndex);
                }
                if (!reader.IsDBNull(CreatedOnIndex))
                {
                    createFormTabledo.CreatedOn = reader.GetDateTime(CreatedOnIndex);
                }
                if (!reader.IsDBNull(lastmodifiedOnIndex))
                {
                    createFormTabledo.LastUpdateOn = reader.GetDateTime(lastmodifiedOnIndex);
                }
                if (!reader.IsDBNull(FormDiscriptionIndex))
                {
                    createFormTabledo.Formdescription = reader.GetString(FormDiscriptionIndex);
                }
                if (!reader.IsDBNull(FormLayoutIndex))
                {
                    createFormTabledo.Formlayout = reader.GetString(FormLayoutIndex);
                }
                if (!reader.IsDBNull(UFormNameIndex))
                {
                    createFormTabledo.UFormName = reader.GetString(UFormNameIndex);
                }
                if (!reader.IsDBNull(WorkFolwIndex))
                {
                    createFormTabledo.WorkFlow = reader.GetInt32(WorkFolwIndex);
                }
                if (!reader.IsDBNull(EidIndex))
                {
                    createFormTabledo.Eid = reader.GetInt32(EidIndex);
                }
                if (!reader.IsDBNull(isRoleAssignmentIndex))
                {
                    createFormTabledo.IsRoleAssignment = reader.GetInt32(isRoleAssignmentIndex);
                }

                if (!reader.IsDBNull(formSourceIndex))
                {
                    createFormTabledo.FormSource = reader.GetString(formSourceIndex);
                }
                if (!reader.IsDBNull(statusActionIndex))
                {
                    createFormTabledo.StatusAction = reader.GetString(statusActionIndex);
                }
                if (!reader.IsDBNull(DocStatusIndex))
                {
                    createFormTabledo.DocStatus = reader.GetString(DocStatusIndex);
                }
                if (!reader.IsDBNull(DocumentIdIndex))
                {
                    createFormTabledo.DocumentId = reader.GetInt32(DocumentIdIndex);
                }
            }
            return createFormTabledo;
        }  
        #endregion

        public  void Addform(CreateFormTableDo formrole)
       {

               SqlParameter[] para = new SqlParameter[14];
               para[0] = new SqlParameter("@TableName", formrole.FormName);
               para[1] = new SqlParameter("@Column1Name", formrole.Column1Name);
               para[2] = new SqlParameter("@Column1DataType", formrole.Column1DataType);
               para[3] = new SqlParameter("@Column1Nullable", formrole.Column1Nullable);
               para[4] = new SqlParameter("@FormLayout", formrole.Formlayout);
               para[5] = new SqlParameter("@FormDiscription", formrole.Formdescription);
               para[6] = new SqlParameter("@UFormName", formrole.UFormName);
               para[7] = new SqlParameter("@workfolw", formrole.WorkFlow);
               para[8] = new SqlParameter("@Eid", formrole.Eid);
               para[9] = new SqlParameter("@FromSource", formrole.FormSource);
               para[10] = new SqlParameter("@StatusAction", formrole.StatusAction);
               para[11] = new SqlParameter("@DocStatus", formrole.DocStatus);
               para[12] = new SqlParameter("@DocumentId", formrole.DocumentId);
               para[13] = new SqlParameter("@Staticpage", formrole.StaticPages);
               SqlDb sqlDb = new SqlDb();
               sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddFormRole, para);
          
       }

        public CreateTableDoList AllCreateForm(string Eid)
        {
            CreateTableDoList createTableDoList = new CreateTableDoList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@Eid", Convert.ToInt32(Eid));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllForms, para))
            {

                CreateFormTableDo createFormTableDo = new CreateFormTableDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            createFormTableDo = ReadData(reader);
                            createTableDoList.Add(createFormTableDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return createTableDoList;
            }
        }

        public  CreateTableDoList AllworkFlowForm(string Eid)
        {
            CreateTableDoList createTableDoList = new CreateTableDoList();
            if (Eid == "")
            {
                return createTableDoList;
            }
               
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@Eid", Convert.ToInt32(Eid));
                SqlDb sqlDb = new SqlDb();
                using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.AllWorkFlowForm, para))
                {

                    CreateFormTableDo createFormTableDo = new CreateFormTableDo();
                    try
                    {
                        if (InisilizationIndex(reader))
                            while (reader.Read())
                            {
                                createFormTableDo = ReadData(reader);
                                createTableDoList.Add(createFormTableDo);
                            }
                        isInisilization = false;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return createTableDoList;
                }
                  
            
           
        }

        public CreateTableDoList EditForm(string Eid,string formid)
        {
            CreateTableDoList createTableDoList = new CreateTableDoList();
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@Eid", Convert.ToInt32(Eid));
            para[1] = new SqlParameter("@formid", Convert.ToInt64(formid));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.EditForm, para))
            {

                CreateFormTableDo createFormTableDo = new CreateFormTableDo();
                try
                {
                    if (InisilizationIndex(reader))
                        while (reader.Read())
                        {
                            createFormTableDo = ReadData(reader);
                            createTableDoList.Add(createFormTableDo);
                        }
                    isInisilization = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return createTableDoList;
            }

        }

        public bool IsValueExist(string formid, string fieldid,string Value)
        {
            // bool flag = false;
            SqlParameter[] para = new SqlParameter[3];
            para[0] = new SqlParameter("@formid", formid.ToString());
            para[1] = new SqlParameter("@fieldid", fieldid.ToString());
            para[2] = new SqlParameter("@Value", Value);
            SqlDb sqlDb = new SqlDb();
            var flag = sqlDb.ExecuteScalarSP(StoreProcesureName.formFieldUnicCheck, para);
            flag = true;
            return Convert.ToBoolean(flag);
        }

        //public XElement REGISTER(Stream Data)
        //{
        //    dynamic Result = "";

        //    try
        //    {
        //        StreamReader reader = new StreamReader(Data);
        //        string strData = reader.ReadToEnd();
        //        strData = HttpUtility.UrlDecode(strData);
        //        StringBuilder Data1 = new StringBuilder(strData);
        //        Result = readxmlandgivestringREGISTRATION(strData);
        //        if (Result.Length > 5)
        //        {
        //            Result = Result.Replace("&", "&amp;");
        //        }
        //        CommanUtil.SaveServicerequest(Data1, "BPMTallyWS", "REGISTER", Result);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.sendMail("BPMTally.REGISTER", ex.Message);
        //    }
        //    XDocument xmldoc = XDocument.Parse(Result);
        //    return xmldoc.Root;
        //}




        //public string readxmlandgivestringREGISTRATION(ref string str)
        //{
        //    string result = string.Empty;
        //    string msg = string.Empty;
        //    XmlDocument xmlDocRead = new XmlDocument();
        //    xmlDocRead.LoadXml(str);
        //    string xmldoctype = string.Empty;
        //    string xmlecode = string.Empty;
        //    string xmlfldname = string.Empty;
        //    string xmlRegvalue = string.Empty;
        //    string xmlRetfield = string.Empty;
        //    string xmlRetTagField = string.Empty;           
        //    int isActive = 0;
        //    int eid = 0;
        //    string dname = string.Empty;


        //    if (xmlDocRead.ChildNodes.Count >= 1)
        //    {
        //        string SelNodesTxt = xmlDocRead.DocumentElement.Name;
        //        int Cnt = 0;
        //        XmlNodeList nodes = xmlDocRead.SelectNodes(SelNodesTxt);
        //        foreach (XmlNode node in nodes)
        //        {
        //            Cnt += 1;
        //            string globalVar = string.Empty;
        //            string ChildVar = string.Empty;

        //            string apikey = string.Empty;
        //            string Key = "";
        //            string DocType = "";
        //            string UID = 0;
        //            for (int c = 0; c <= node.ChildNodes.Count - 1; c++)
        //            {
        //                if (Strings.UCase(node.ChildNodes.Item(c).Name) == "BODY")
        //                {
        //                    for (int C1 = 0; C1 <= node.Item("BODY").ChildNodes.Count - 1; C1++)
        //                    {
        //                        if (node.Item("BODY").ChildNodes.Item(C1).Name == "DATA")
        //                        {
        //                            for (int c2 = 0; c2 <= node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Count - 1; c2++)
        //                            {
        //                                if (node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).Name == "VALIDATION")
        //                                {
        //                                    for (int P = 0; P <= node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).ChildNodes.Count - 1; P++)
        //                                    {
        //                                        if (Strings.UCase(node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).ChildNodes.Item(P).Name) == "FORMNAME")
        //                                        {
        //                                            xmldoctype = node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).ChildNodes.Item(P).InnerText.ToString();
        //                                        }
        //                                        else if (Strings.UCase(node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).ChildNodes.Item(P).Name) == "REGVALUE")
        //                                        {
        //                                            xmlRegvalue = node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).ChildNodes.Item(P).InnerText.ToString();
        //                                        }
        //                                        else if (Strings.UCase(node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).ChildNodes.Item(P).Name) == "ENTITY")
        //                                        {
        //                                            xmlecode = node.Item("BODY").ChildNodes.Item(C1).ChildNodes.Item(c2).ChildNodes.Item(P).InnerText.ToString();
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //        }

        //        if (!string.IsNullOrEmpty(xmldoctype) & !string.IsNullOrEmpty(xmlecode) & !string.IsNullOrEmpty(xmlRegvalue))
        //        {
        //            //Dim DB As New Dbconnection()
        //            conStr = DB.DYnamicConnection(xmlecode);
        //            SqlConnection con = new SqlConnection(conStr);
        //            SqlDataAdapter da = new SqlDataAdapter("", con);
        //            DataSet ds = new DataSet();
        //            //getting EID 
        //            da.SelectCommand.CommandText = "Select eid from mmm_mst_entity where code='" + xmlecode.ToString() + "'";
        //            if (con.State != ConnectionState.Open)
        //            {
        //                con.Open();
        //            }
        //            eid = Conversion.Val(da.SelectCommand.ExecuteScalar());

        //            //getting Tally Registration FIeld from FORM Master
        //            da.SelectCommand.CommandText = "select TallyRegField,xmltallyreturnTagfield,xmltallyreturnfield from mmm_mst_forms where eid=" + Conversion.Val(eid) + " and formname ='" + xmldoctype.ToString() + "'";
        //            da.Fill(ds, "vla");
        //            if (ds.Tables("vla").Rows.Count > 0)
        //            {
        //                xmlfldname = ds.Tables("vla").Rows(0).Item("TallyRegField").ToString();
        //                xmlRetfield = ds.Tables("vla").Rows(0).Item("xmltallyreturnfield").ToString();
        //                xmlRetTagField = ds.Tables("vla").Rows(0).Item("xmltallyreturnTagfield").ToString();
        //            }



        //            string StrQuery = "SELECT tid,[" + xmlRetfield.ToString() + "] from  v" + eid + xmldoctype.Trim.Replace(" ", "_") + " where  v" + eid + xmldoctype.Trim.Replace(" ", "_") + ".[" + xmlfldname.ToString() + "] = '" + xmlRegvalue.ToString() + "'";
        //            da.SelectCommand.CommandText = StrQuery;

        //            da.Fill(ds, "res");
        //            if (ds.Tables("res").Rows.Count > 0)
        //            {
        //                result = ds.Tables("res").Rows(0).Item("tid").ToString();
        //                dname = ds.Tables("res").Rows(0).Item(xmlRetfield.ToString()).ToString();
        //            }


        //            StrQuery = "SELECT case TallyIsActive when 1 then 1 else 0 end  from  v" + eid + xmldoctype.Trim.Replace(" ", "_") + " where  v" + eid + xmldoctype.Trim.Replace(" ", "_") + ".[" + xmlfldname.ToString() + "] = '" + xmlRegvalue.ToString() + "'";
        //            da.SelectCommand.CommandText = StrQuery;

        //            isActive = Convert.ToInt32(da.SelectCommand.ExecuteScalar().ToString());
        //        }
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<ENVELOPE>");
        //    sb.Append("<HEADER>");
        //    sb.Append("<TALLYREQUEST>");
        //    sb.Append("REGISTRATION");
        //    sb.Append("</TALLYREQUEST>");
        //    sb.Append("</HEADER>");
        //    sb.Append("<BODY>");

        //    sb.Append("<DATA>");
        //    sb.Append("<VALIDATION>");
        //    sb.Append("<FORMNAME>");
        //    sb.Append(xmldoctype);
        //    sb.Append("</FORMNAME>");
        //    sb.Append("<ENTITY>");
        //    sb.Append(xmlecode);
        //    sb.Append("</ENTITY>");
        //    sb.Append("<REGVALUE>");
        //    sb.Append(xmlRegvalue);
        //    sb.Append("</REGVALUE>");
        //    sb.Append("<BPMTID>");
        //    if (Strings.Trim(isActive) == 1)
        //    {
        //        sb.Append("ALREADY REGISTERED");
        //        FunctiontoReport("", eid, xmldoctype, "REGISTER", result, result, "ERROR", "", "", 0,
        //        "");
        //    }
        //    else
        //    {
        //        if (!string.IsNullOrEmpty(result) & result != "0")
        //        {
        //            sb.Append(result);
        //            FunctiontoReport("", eid, xmldoctype, "REGISTER", result, result, "SUCCESS", "", "", 1,
        //            "", NconStr: conStr);
        //        }
        //        else
        //        {
        //            sb.Append("NOT FOUND");
        //            FunctiontoReport("", eid, xmldoctype, "REGISTER", "", "NOT FOUND", "ERROR", "", "", 0,
        //            "", NconStr: conStr);
        //        }
        //    }

        //    sb.Append("</BPMTID>");
        //    sb.Append("<" + xmlRetTagField + ">");
        //    sb.Append(dname);
        //    sb.Append("</" + xmlRetTagField + ">");
        //    sb.Append("</VALIDATION>");
        //    sb.Append("</DATA>");
        //    sb.Append("</BODY>");
        //    sb.Append("</ENVELOPE>");


        //    return sb.ToString();

        //}
    }
}
