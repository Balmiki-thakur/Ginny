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
    public class FieldPropertyController
    {   

        static int TidIndex = 0;
        static int PFormIdIndex = 0;
        static int PFIeldIdIndex = 0;
        static int MANDATORYIndex = 0;
        static int ACTIVEIndex = 0;
        static int EDITABLEIndex = 0;
        static int WORKFLOWIndex = 0;
        static int DUNIQUEIndex = 0;
        static int SHOWONAMENDMENTIndex = 0;
        static int SEARCHIndex = 0;
        static int EDITONAMENDMENTIndex = 0;
        static int IMIENoIndex = 0;
        static int PHONENoIndex = 0;
        static int INLINEEDITINGIndex = 0;
        static int SHOWONDOCDETAILIndex = 0;
        static int InvisibleIndex = 0;
        static int SPLITTABLEIndex = 0;
        static int SHOWONSPLITIndex = 0;
        static int ISSUPERVISORIndex = 0;
        static int EnableEditIndex = 0;
        static int PriorityDeciderIndex = 0;
        static int CRMReminderIndex = 0;
        static int ShowOnDeshboardIndex = 0;
        static int ShowOnCRMIndex = 0;
        static int EDITOnCRMIndex = 0;
        static int IsTotalIndex = 0;
        static int AllowEditOnEditIndex = 0;
        static int ExternalLookupForMobileIndex = 0;
        static int ShowInRoleAssignmentIndex = 0;
        static int IsCardNoIndex = 0;
        static int ReportNameIndex = 0;
        static int PlaceofStayIndex = 0;
        static int PopupNotificationFieldonMobileIndex = 0;
        static int ActionFormFieldsIndex = 0;
        static bool isInisilization = false;
        private static bool InisilizationIndex(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                if (!isInisilization)
                {
                    PFormIdIndex = reader.GetOrdinal("FormId");
                    PFIeldIdIndex = reader.GetOrdinal("FIeldId");
                    MANDATORYIndex = reader.GetOrdinal("MANDATORY");
                    ACTIVEIndex = reader.GetOrdinal("ACTIVE");
                    EDITABLEIndex = reader.GetOrdinal("EDITABLE");
                    WORKFLOWIndex = reader.GetOrdinal("WORKFLOW");
                    DUNIQUEIndex = reader.GetOrdinal("DUNIQUE");
                    SHOWONAMENDMENTIndex = reader.GetOrdinal("SHOWONAMENDMENT");
                    SEARCHIndex = reader.GetOrdinal("SEARCH");
                    EDITONAMENDMENTIndex = reader.GetOrdinal("EDITONAMENDMENT");
                    IMIENoIndex = reader.GetOrdinal("IMIENo");
                    PHONENoIndex = reader.GetOrdinal("PHONENo");
                    INLINEEDITINGIndex = reader.GetOrdinal("INLINEEDITING");
                    SHOWONDOCDETAILIndex = reader.GetOrdinal("SHOWONDOCDETAIL");
                    InvisibleIndex = reader.GetOrdinal("Invisible");
                    SPLITTABLEIndex = reader.GetOrdinal("SPLITTABLE");
                    SHOWONSPLITIndex = reader.GetOrdinal("SHOWONSPLIT");
                    ISSUPERVISORIndex = reader.GetOrdinal("ISSUPERVISOR");
                    EnableEditIndex = reader.GetOrdinal("EnableEdit");
                    PriorityDeciderIndex = reader.GetOrdinal("PriorityDecider");
                    CRMReminderIndex = reader.GetOrdinal("CRMReminder");
                    ShowOnDeshboardIndex = reader.GetOrdinal("ShowOnDeshboard");
                    ShowOnCRMIndex = reader.GetOrdinal("ShowOnCRM");
                    EDITOnCRMIndex = reader.GetOrdinal("EDITOnCRM");
                    IsTotalIndex = reader.GetOrdinal("IsTotal");
                    AllowEditOnEditIndex = reader.GetOrdinal("AllowEditOnEdit");
                    ExternalLookupForMobileIndex = reader.GetOrdinal("ExternalLookupForMobile");
                    ShowInRoleAssignmentIndex = reader.GetOrdinal("ShowInRoleAssignment");
                    IsCardNoIndex = reader.GetOrdinal("IsCardNo");
                    ReportNameIndex = reader.GetOrdinal("ReportName");
                    PlaceofStayIndex = reader.GetOrdinal("PlaceofStay");
                    PopupNotificationFieldonMobileIndex = reader.GetOrdinal("PopupNotificationFieldonMobile");
                    ActionFormFieldsIndex = reader.GetOrdinal("ActionFormFields");


                    isInisilization = true;

                }
                return true;
            }
            return false;
        }
        private static FieldPropertyDo ReadData(SqlDataReader reader)
        {
            FieldPropertyDo formsRoleDo = new FieldPropertyDo();
            if (InisilizationIndex(reader))
            {
                if (!reader.IsDBNull(PFormIdIndex))
                {
                    formsRoleDo.FormId = reader.GetInt32(PFormIdIndex);
                }
                if (!reader.IsDBNull(PFIeldIdIndex))
                {
                    formsRoleDo.FieldId = reader.GetInt32(PFIeldIdIndex);
                }
                if (!reader.IsDBNull(MANDATORYIndex))
                {
                    formsRoleDo.MANDATORY = reader.GetBoolean(MANDATORYIndex);
                }
                if (!reader.IsDBNull(ACTIVEIndex))
                {
                    formsRoleDo.ACTIVE = reader.GetBoolean(ACTIVEIndex);
                }
                if (!reader.IsDBNull(EDITABLEIndex))
                {
                    formsRoleDo.EDITABLE = reader.GetBoolean(EDITABLEIndex);
                }
                if (!reader.IsDBNull(WORKFLOWIndex))
                {
                    formsRoleDo.WORKFLOW = reader.GetBoolean(WORKFLOWIndex);
                }
                if (!reader.IsDBNull(DUNIQUEIndex))
                {
                    formsRoleDo.UNIQUE = reader.GetBoolean(DUNIQUEIndex);
                }
                if (!reader.IsDBNull(SHOWONAMENDMENTIndex))
                {
                    formsRoleDo.SHOWONAMENDMENT = reader.GetBoolean(SHOWONAMENDMENTIndex);
                }
                if (!reader.IsDBNull(SEARCHIndex))
                {
                    formsRoleDo.SEARCH = reader.GetBoolean(SEARCHIndex);
                }
                if (!reader.IsDBNull(EDITONAMENDMENTIndex))
                {
                    formsRoleDo.EDITONAMENDMENT = reader.GetBoolean(EDITONAMENDMENTIndex);
                }
                if (!reader.IsDBNull(IMIENoIndex))
                {
                    formsRoleDo.IMIENo = reader.GetBoolean(IMIENoIndex);
                } if (!reader.IsDBNull(PHONENoIndex))
                {
                    formsRoleDo.PHONENo = reader.GetBoolean(PHONENoIndex);
                }
                if (!reader.IsDBNull(INLINEEDITINGIndex))
                {
                    formsRoleDo.INLINEEDITING = reader.GetBoolean(INLINEEDITINGIndex);
                }
                if (!reader.IsDBNull(SHOWONDOCDETAILIndex))
                {
                    formsRoleDo.SHOWONDOCDETAIL = reader.GetBoolean(SHOWONDOCDETAILIndex);
                }
                if (!reader.IsDBNull(InvisibleIndex))
                {
                    formsRoleDo.Invisible = reader.GetBoolean(InvisibleIndex);
                }
                if (!reader.IsDBNull(SPLITTABLEIndex))
                {
                    formsRoleDo.SPLITTABLE = reader.GetBoolean(SPLITTABLEIndex);
                }
                if (!reader.IsDBNull(SHOWONSPLITIndex))
                {
                    formsRoleDo.SHOWONSPLIT = reader.GetBoolean(SHOWONSPLITIndex);
                }
                if (!reader.IsDBNull(ISSUPERVISORIndex))
                {
                    formsRoleDo.ISSUPERVISOR = reader.GetBoolean(ISSUPERVISORIndex);
                }
                if (!reader.IsDBNull(EnableEditIndex))
                {
                    formsRoleDo.EnableEdit = reader.GetBoolean(EnableEditIndex);
                }
                if (!reader.IsDBNull(PriorityDeciderIndex))
                {
                    formsRoleDo.PriorityDecider = reader.GetBoolean(PriorityDeciderIndex);
                }
                if (!reader.IsDBNull(CRMReminderIndex))
                {
                    formsRoleDo.CRMReminder = reader.GetBoolean(CRMReminderIndex);
                }
                if (!reader.IsDBNull(ShowOnDeshboardIndex))
                {
                    formsRoleDo.ShowOnDeshboard = reader.GetBoolean(ShowOnDeshboardIndex);
                }
                if (!reader.IsDBNull(ShowOnCRMIndex))
                {
                    formsRoleDo.ShowOnCRM = reader.GetBoolean(ShowOnCRMIndex);
                }
                if (!reader.IsDBNull(EDITOnCRMIndex))
                {
                    formsRoleDo.EDITOnCRM = reader.GetBoolean(EDITOnCRMIndex);
                }
                if (!reader.IsDBNull(IsTotalIndex))
                {
                    formsRoleDo.IsTotal = reader.GetBoolean(IsTotalIndex);
                }
                if (!reader.IsDBNull(AllowEditOnEditIndex))
                {
                    formsRoleDo.AllowEditOnEdit = reader.GetBoolean(AllowEditOnEditIndex);
                }
                if (!reader.IsDBNull(ExternalLookupForMobileIndex))
                {
                    formsRoleDo.ExternalLookupForMobile = reader.GetBoolean(ExternalLookupForMobileIndex);
                }
                if (!reader.IsDBNull(ShowInRoleAssignmentIndex))
                {
                    formsRoleDo.ShowInRoleAssignment = reader.GetBoolean(ShowInRoleAssignmentIndex);
                }
                if (!reader.IsDBNull(IsCardNoIndex))
                {
                    formsRoleDo.IsCardNo = reader.GetBoolean(IsCardNoIndex);
                }
                if (!reader.IsDBNull(ReportNameIndex))
                {
                    formsRoleDo.ReportName = reader.GetBoolean(ReportNameIndex);
                }
                if (!reader.IsDBNull(PlaceofStayIndex))
                {
                    formsRoleDo.PlaceofStay = reader.GetBoolean(PlaceofStayIndex);
                }
                if (!reader.IsDBNull(PopupNotificationFieldonMobileIndex))
                {
                    formsRoleDo.PopupNotificationFieldonMobile = reader.GetBoolean(PopupNotificationFieldonMobileIndex);
                }

                if (!reader.IsDBNull(ActionFormFieldsIndex))
                {
                    formsRoleDo.ActionFormField = reader.GetBoolean(ActionFormFieldsIndex);
                }
            }
            return formsRoleDo;
        }

        public  void AddFormField(FieldPropertyDo fieldPropertyDo)
        { 
             SqlParameter[] para = new SqlParameter[33];
             para[0] = new SqlParameter("@FIeldId", fieldPropertyDo.FieldId);
             para[1] = new SqlParameter("@MANDATORY", fieldPropertyDo.MANDATORY);
             para[2] = new SqlParameter("@ACTIVE", fieldPropertyDo.ACTIVE);
             para[3] = new SqlParameter("@EDITABLE", fieldPropertyDo.EDITABLE);
             para[4] = new SqlParameter("@WORKFLOW", fieldPropertyDo.WORKFLOW);
             para[5] = new SqlParameter("@DUNIQUE", fieldPropertyDo.UNIQUE);
             para[6] = new SqlParameter("@SHOWONAMENDMENT", fieldPropertyDo.SHOWONAMENDMENT);
             para[7] = new SqlParameter("@IMIENo", fieldPropertyDo.IMIENo);
             para[8] = new SqlParameter("@PHONENo", fieldPropertyDo.PHONENo);
             para[9] = new SqlParameter("@INLINEEDITING", fieldPropertyDo.INLINEEDITING);
             para[10] = new SqlParameter("@SHOWONDOCDETAIL", fieldPropertyDo.SHOWONDOCDETAIL);
             para[11] = new SqlParameter("@Invisible", fieldPropertyDo.Invisible);
             para[12] = new SqlParameter("@SPLITTABLE", fieldPropertyDo.SPLITTABLE);
             para[13] = new SqlParameter("@SHOWONSPLIT", fieldPropertyDo.SHOWONSPLIT);
             para[14] = new SqlParameter("@ISSUPERVISOR", fieldPropertyDo.ISSUPERVISOR);
             para[15] = new SqlParameter("@EnableEdit", fieldPropertyDo.EnableEdit);
             para[16] = new SqlParameter("@PriorityDecider", fieldPropertyDo.PriorityDecider);
             para[17] = new SqlParameter("@CRMReminder", fieldPropertyDo.CRMReminder);
             para[18] = new SqlParameter("@ShowOnDeshboard", fieldPropertyDo.ShowOnDeshboard);
             para[19] = new SqlParameter("@ShowOnCRM", fieldPropertyDo.ShowOnCRM);
             para[20] = new SqlParameter("@EDITOnCRM", fieldPropertyDo.EDITOnCRM);
             para[21] = new SqlParameter("@IsTotal", fieldPropertyDo.IsTotal);
             para[22] = new SqlParameter("@AllowEditOnEdit", fieldPropertyDo.AllowEditOnEdit);
             para[23] = new SqlParameter("@ExternalLookupForMobile", fieldPropertyDo.ExternalLookupForMobile);
             para[24] = new SqlParameter("@ShowInRoleAssignment", fieldPropertyDo.ShowInRoleAssignment);
             para[25] = new SqlParameter("@IsCardNo", fieldPropertyDo.IsCardNo);
             para[26] = new SqlParameter("@ReportName", fieldPropertyDo.ReportName);
             para[27] = new SqlParameter("@PlaceofStay", fieldPropertyDo.PlaceofStay);
             para[28] = new SqlParameter("@PopupNotificationFieldonMobile", fieldPropertyDo.PopupNotificationFieldonMobile);
             para[29]= new SqlParameter ("@SEARCH", fieldPropertyDo.SEARCH);
             para[30]= new SqlParameter ("@EDITONAMENDMENT", fieldPropertyDo.EDITONAMENDMENT);
             para[31] = new SqlParameter("@formid", fieldPropertyDo.FormId);
             para[32] = new SqlParameter("@ActionFormFields", fieldPropertyDo.FormId);
             SqlDb sqlDb = new SqlDb();
             sqlDb.ExecuteNonQuerySP(StoreProcesureName.AddFieldProperty, para);
        }

     

        public  FIeldPropertyList FieldByFormIdworkflow(string formId)
        {
            FIeldPropertyList formRoleList = new FIeldPropertyList();
            SqlParameter[] para = new SqlParameter[1];
            para[0] = new SqlParameter("@formId", Convert.ToInt32(formId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.workflowFieldbyFormId, para))
            {
                FieldPropertyDo formsFields = new FieldPropertyDo();
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
