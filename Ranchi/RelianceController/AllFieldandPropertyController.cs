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
   public class AllFieldandPropertyController
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
                    isimeinoIndex = reader.GetOrdinal("IsIMIE");
                    maxlenghtIndex = reader.GetOrdinal("MaxLenght");
                    minLenghtIndex = reader.GetOrdinal("MinLenght");
                    EidIndex = reader.GetOrdinal("EId");                  
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
        private static AllFieldAndPropertyDo ReadData(SqlDataReader reader)
        {
            AllFieldAndPropertyDo formsRoleDo = new AllFieldAndPropertyDo();
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
                    formsRoleDo.PIMIENo = reader.GetBoolean(IMIENoIndex);
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
                    formsRoleDo.ActionFormFields = reader.GetBoolean(ActionFormFieldsIndex);
                }
            }
            return formsRoleDo;
        }

        #endregion
        public  AllFieldProPertyList FieldByFormId(string formId, string CompanyId)
        {   
              AllFieldProPertyList formRoleList = new AllFieldProPertyList();
              if (CompanyId == "") { return formRoleList; }
          
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@formId", Convert.ToInt32(formId));
            para[1] = new SqlParameter("@Eid",  Convert.ToInt32(CompanyId));
            SqlDb sqlDb = new SqlDb();
            using (SqlDataReader reader = sqlDb.GetDataReaderSP(StoreProcesureName.FieldbyFormId, para))
            {
                AllFieldAndPropertyDo formsFields = new AllFieldAndPropertyDo();
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
