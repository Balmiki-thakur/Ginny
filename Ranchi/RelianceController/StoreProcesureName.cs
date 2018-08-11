using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelianceController
{
    internal partial class StoreProcesureName
    {
         #region Login Items
        internal const string AdminLogin = "SearchMember";
        internal const string RoleByRoleId = "RoleByRoleId";
        internal const string AdminLoginUseId = "Usp_UserIDbyUserName";
        #endregion
         #region Menu Items
        internal const string MenubyMenuId = "MenubyMenuId";
        internal const string AllMenus = "AllMenu";
        internal const string AllMenuData = "AllMenusData";
        internal const string AllMenuDatas = "AllMenusDatas";
        internal const string  RootMenu = "[All RootMenu]";
        internal const string AllSubMenu = "[All_SubMenu]";
        internal const string SubMenuMaster = "[Add_SubMenuMaster]";
        internal const string AddMenu = "Add_MenuMaster";
        internal const string SaveMenuRole = "SaveMenuRole";
        internal const string EditMenuId = "EditMenusDatas";
        internal const string MenusRolebyMenuId = "[MenusRolebyMenuId]";
        internal const string ManuFormRender = "[ManuFormRender]";
        #endregion
         #region Country Items
        internal const string AllCountry = "AllCountry";
        internal const string AddCountry = "Add_Country";
        #endregion
         #region User
        internal const string UserIdbyPassword = "UserLogin";
        internal const string UserEmailCheck = "UserEmailCheck";
        internal const string AddRegistation = "Add_UserRegistation";
        internal const string Update_UserRegistation = "Update_UserRegistation";
        internal const string RoleLogin = "RoleLogin";
        internal const string AllUser = "AllUser";
        internal const string RolebyUser = "RolebyUser";
        internal const string RoleAssignCheck = "RoleAssignCheck";


        #endregion
         #region Role
          internal const string AddRole = "Add_RoleMaster";
          internal const string AllRoleData = "[AllRoleData]";
        
        #endregion
         #region Role

          internal const string AddFormRole = "[CreateForm]";
          internal const string AllFields = "[AllFormFields]";
          internal const string Addfields = "[AddFields]";
          internal const string AddFormFields = "AddFormFields";
          internal const string AllForms = "[AllForm]";
          internal const string AllWorkFlowForm = "[AllWorkFlowForm]";
          internal const string EditForm = "EditForm";
          internal const string FieldbyFormId = "FieldbyFormId";
          internal const string ReportFieldbyFormId = "ReportFieldbyFormId";
          internal const string AllformDynamicData = "AllformDynamicData";
          internal const string AllLookUpForm = "[AllLookUpForm]";
          internal const string AllLookUpField = "[AllLookUpField]";

          internal const string AproveActionField = "AproveActionField";
          #endregion
         #region DropDown 
          internal const string DropDownSP = "DropDownSP";
          internal const string DropDownbindSP = "DropDownbindSP";
          internal const string DropDownbindSPwithIsRole = "DropDownbindSPwithIsRole";
          internal const string DropDownFunctionSp = "DropDownFunctionSp";
        #endregion
         #region LookUp
          internal const string LookUpSP = "[LooKUpSP]";

          internal const string checkParentDropDown = "[checkParentDropDown]";
          internal const string LooKUpSPFunction = "[LooKUpSPFunction]";
         

          internal const string checkParentLookUp = "[checkParentLookUp]";
         

         internal const string CheckData = "CheckData";
         internal const string MasterLookupdata = "[MasterLookupdata]";
         internal const string DDlFilterData = "DDlFilterData";
         internal const string MasterDDLFilter = "[MasterDDLFilter]";

         internal const string AutoComplete = "[AutoComplete]";
          #endregion
         #region field Validation
         internal const string FieldValidation = "[Add_FieldValidation]";
         internal const string validationbyFormId = "validationbyFormId";
          #endregion
         #region DropDown
         internal const string VehicleTrakingReport = "VehicleTraking_Report";
         internal const string MilageGraphRecord = "MilageGraph";
         internal const string LatestGPsRecord = "LatestGPs_Record";
         internal const string MilageGPsRecord = "MilageGPsRecord";
         internal const string GridMilageGPsRecord = "GridMilageGPsRecord";
         #endregion
         #region InsertData
         internal const string InsertData = "[InsertData]";
        #endregion
         #region WorkFlowStatus
         internal const string Add_WorkFlowStatuss = "[Add_WorkFlowStatuss]";
         internal const string WorkFlowStatubyFormId = "[WorkFlowStatubyFormId]";
         internal const string WorkFlowStatuby = "WorkFlowStatuby";
         internal const string workflowFieldbyFormId = "workflowFieldbyFormId";
         internal const string DynamicWorkFlowByFormid = "[DynamicWorkFlowByFormid]";
         #endregion
         #region FormFields
         internal const string EditField = "EditField";
         internal const string FormFieldsType = "FormFieldsType";
         internal const string formFieldUnicCheck = "[formFieldUnicCheck1]";
        #endregion
         #region NeedToAct
         internal const string AddMasterDocumet = "AddMasterDocumet";
         internal const string AddMasterMovement = "AddMasterMovement";
         internal const string NeedToAct = "NeedToAct";
         internal const string MyRequest = "MyRequest";
         internal const string NeedtoActApprove = "NeedtoActApprove";
         internal const string NeedtoActReject = "NeedtoActReject";
         internal const string NeedToActGridDetail = "NeedToActGridDetail";
         #endregion
         #region 
         internal const string InsertMasterData = "InsertMasterData";
         #endregion
         #region MasterMoment
         internal const string MomentdocumentCount = "MomentdocumentCount";   
         #endregion
         #region Grid
         internal const string AddGridData = "[AddGridData]";
         internal const string joinFieldbyFormId = "joinFieldbyFormId";
        #endregion
         #region IsRoleAssingment
         internal const string AddRoleAssignMent = "[AddRoleAssignMent]";
         internal const string AllFormRoleAssinment = "[AllFormRoleAssinment]";
        #endregion
         #region IsFormProperty
         internal const string AddFieldProperty = "AddFieldProperty";
         internal const string DemoDataTable = "DemoDataTable";
         #endregion
         #region RuleEngin
         internal const string InsertRuleEngin = "InsertRuleEngin";
         internal const string RuleEnginformId = "RuleEnginformId";
         internal const string RuleConditionFieldCheck = "RuleConditionFieldCheck";
        #endregion

        #region GPS
        internal const string InsertGps = "InsertGps";
        #endregion
    }
}
