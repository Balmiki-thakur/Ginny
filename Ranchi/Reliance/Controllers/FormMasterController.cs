using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Reliance.Controllers
{
  
    public class FormMasterController : Controller
    {      
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DocumentForm()
        {
            return View();
        }
        public ActionResult MasterFormcreate(string LinKType)
        {

            if (LinKType != null)
            {
                MenuRoleDoList menuRoleDoList = new MenuRoleDoList();
                if (Convert.ToString(Session["LOGGED_Company"]) == "1")
                {
                    MenuRoleController menuRoleController =new MenuRoleController();
                    menuRoleDoList = menuRoleController.RenderFormRole(LinKType, Convert.ToString(Session["LOGGED_ROLE"]));
                    ViewData["MenuROle"] = menuRoleDoList;
                }
                else 
                {
                    ViewData["MenuROle"] = menuRoleDoList;
                }
                ViewBag.Id = LinKType;
                TempData["Dataid"] = LinKType; 

            }   
            return View();
        }
        public ActionResult MasterFormcreates(string formName, string FormWorkFlow_1, FormCollection form)
        {
            var appSettings = form.AllKeys.Where(k => k.StartsWith("AppSettings.")).ToDictionary(k => k, k => form[k]);
            Dictionary<string, object> forma = new Dictionary<string, object>(); form.CopyTo(forma);

                TextBoxList textList = new TextBoxList();
               
                    foreach (String key in form.AllKeys)
                    {
                        if (key != "FormWorkFlow_1")
                        {
                            TextBoxViewModel textBoxList1 = new TextBoxViewModel();
                            textBoxList1.FieldId = key;
                            textBoxList1.Value = form[key];
                            textList.Add(textBoxList1);                                                
                        }                  
                    }
                     RelianceController.FormFieldController formFieldController =new RelianceController.FormFieldController();
                     TextBoxViewModel textBoxList = formFieldController.InsertMetada(formName, "", textList);            
                    MasterDocumentDo masterDocumentDo = new MasterDocumentDo();
                    masterDocumentDo.Formid = Convert.ToInt32(TempData["Dataid"]);
                    if (FormWorkFlow_1 != "0")
                    {                       
                        masterDocumentDo.docid = textBoxList.IdentityId;
                        masterDocumentDo.Formid = Convert.ToInt32(TempData["Dataid"]);
                        masterDocumentDo.UserId = Convert.ToInt32(Session["LOGGED_UserId"]);
                        masterDocumentDo.RoleId = Convert.ToInt32(Session["LOGGED_ROLE"]);
                        masterDocumentDo.FormName = formName;
                        MasterDocumentController masterDocumentController = new MasterDocumentController();
                        masterDocumentController.AddMasterDocument(masterDocumentDo);
                    }
                    return RedirectToAction("MasterFormcreate", "FormMaster", new { LinKType = masterDocumentDo.Formid});
                      
        }
        public ActionResult UpdateFields(string formName, string id,FormCollection form)
        {
          
            TextBoxList textList = new TextBoxList();
            foreach (String key in form.AllKeys)
            {
                TextBoxViewModel textBoxList1 = new TextBoxViewModel();                
                textBoxList1.FieldId = key;
                textBoxList1.Value = form[key];
                if (key == "id")
                {
                   // textList.Add(textBoxList1);
                }
                else
                {
                    textList.Add(textBoxList1);
                }   
            }
            RelianceController.FormFieldController formFieldController = new RelianceController.FormFieldController();
            formFieldController.UpdateMasterField(formName, id, "", textList);
            return RedirectToAction("MasterFormcreate", "FormMaster", new { LinKType = Convert.ToInt32(TempData["Dataid"]) });
        }     
        [HttpPost]
        public JsonResult AddFormField(FormsFields formsroledo)
        {
            RelianceController.FormFieldController formFieldController = new RelianceController.FormFieldController();
            formFieldController.AddFormField(formsroledo);
           
            return Json(new { Response = formsroledo.Display_name }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult FormCreate(CreateFormTableDo createFormTableDo)
        {
            RelianceController.CreateFormMaster  createFormMaster=new  RelianceController.CreateFormMaster();
                         createFormMaster.Addform(createFormTableDo);
            return Json(new { Response = "OnSuccess" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DropDownValue(string formName,string ColloumName)
        {
            RelianceController.FormFieldController formFieldController= new RelianceController.FormFieldController();
            DropDownValueDoList dropdownvalue = formFieldController.DropDownbind(formName, ColloumName);
            return Json(new { Responses= dropdownvalue}, JsonRequestBehavior.AllowGet);
       }
        [HttpPost]
        public JsonResult DropDownData(string FormId, string FieldId)
        {
            FormFieldController formFieldController = new FormFieldController();
            DropDownValueDoList dropdownvalue = formFieldController.DropDownvaluebind(FormId, FieldId);
            return Json(new { Responses = dropdownvalue }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DropDownFunctionValue(string colloumType,string fieldName,string fieldtype, string ColloumName,string formName)
        {
            RelianceController.FormFieldController formFieldController = new RelianceController.FormFieldController();
            DropDownValueDoList dropdownvalue = formFieldController.DropDownFunctionbind(colloumType, formName, fieldtype, fieldName, ColloumName);
            return Json(new { Responses = dropdownvalue }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LooKUpdataBind(string currentFieldId, string Id)
        {
            RelianceController.FormFieldController formFieldController = new RelianceController.FormFieldController();
            ListLooKup listLooKup = formFieldController.LookUpDataValue(currentFieldId, Id);
            return Json(new { Responses = listLooKup }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DDLFilterUpdataBind(string currentFieldId, string Id)
         {    
             RelianceController.FormFieldController formFieldController = new RelianceController.FormFieldController();
             DropDownValueDoList dropDownValueDoList = formFieldController.DDlFilterDataValue(currentFieldId, Id);
             return Json(new { Responses = dropDownValueDoList }, JsonRequestBehavior.AllowGet);
         }
        [HttpPost]
        public JsonResult AutoCompleteCountry(string Prefix, string Formid, string FieldId)
         {
             List<string> CityName = new List<string>();
             FormFieldController formFieldController = new FormFieldController();
             CityName = formFieldController.GetAutoComplet(Prefix, Formid, FieldId);
             return Json(CityName, JsonRequestBehavior.AllowGet);
         }
        public JsonResult FieldEdit(string formid,string Id)
         {     
             RelianceController.FormFieldController formFieldController = new RelianceController.FormFieldController();
             EditDynamicDataList EditDynamicDataList = formFieldController.EditDynamicData(formid, Id);
             return Json(new { Response = EditDynamicDataList }, JsonRequestBehavior.AllowGet);
            // var data = FormFieldController.GetCategory();     
         }
        [HttpPost]
        public JsonResult DropDownDataIsRoleAssignMent(string FormId, string FieldId, string UserId, string RoleId, string Form)
        {
               IsRoleAssignmentController isRoleAssignmentController =new IsRoleAssignmentController();
               IsROleAssignmentDo lsROleAssignmentDo = isRoleAssignmentController.IsROleAssignment(FormId, FieldId, UserId, RoleId, Form);
             if (lsROleAssignmentDo.DocumentDataid == "")
             {
                 FormFieldController formFieldController = new FormFieldController();
                 DropDownValueDoList dropdownvalue = formFieldController.DropDownvaluebind(FormId, FieldId); 
                 return Json(new { Responses = dropdownvalue }, JsonRequestBehavior.AllowGet);
             }
             else 
             
             {
                 if (lsROleAssignmentDo.IsEdit == 1 && lsROleAssignmentDo.IsCreate == 1 & lsROleAssignmentDo.Userid == Convert.ToInt32(Session["LOGGED_UserId"]))
                 {   
                     FormFieldController formFieldController =new FormFieldController();
                     DropDownValueDoList dropdownvalue = formFieldController.DropDownvaluewithRole(FormId, FieldId, lsROleAssignmentDo.DocumentDataid);
                     return Json(new { Responses = dropdownvalue }, JsonRequestBehavior.AllowGet);
                 }
                 if (lsROleAssignmentDo.IsCreate == 1 & lsROleAssignmentDo.Userid == Convert.ToInt32(Session["LOGGED_UserId"]))
                 {
                     FormFieldController formFieldController = new FormFieldController();
                     DropDownValueDoList dropdownvalue = formFieldController.DropDownvaluewithRole(FormId, FieldId, lsROleAssignmentDo.DocumentDataid);
                     return Json(new { Responses = dropdownvalue }, JsonRequestBehavior.AllowGet);
                 }
                 if (lsROleAssignmentDo.IsEdit == 1 & lsROleAssignmentDo.Userid == Convert.ToInt32(Session["LOGGED_UserId"]))
                 {
                     FormFieldController formFieldController = new FormFieldController();
                     DropDownValueDoList dropdownvalue = formFieldController.DropDownvaluewithRole(FormId, FieldId, lsROleAssignmentDo.DocumentDataid);
                     return Json(new { Responses = dropdownvalue }, JsonRequestBehavior.AllowGet);
                 }
                
                 else 
                 {
                     FormFieldController formFieldController = new FormFieldController();

                     DropDownValueDoList dropdownvalue = formFieldController.DropDownvaluebind(FormId, FieldId);
                     return Json(new { Responses = dropdownvalue }, JsonRequestBehavior.AllowGet);
                 }
             }
            
         }
        public ActionResult EditUserMainMaster()
         {
             return View();
         }
        public ActionResult FormMainMaster()
         {
             return View();
         }
        public JsonResult FormEdit(string eid, string formid)
         {
             RelianceController.CreateFormMaster createFormMaster = new RelianceController.CreateFormMaster();
             CreateTableDoList EditDynamicDataList = createFormMaster.EditForm(eid, formid);
             return Json(new { Response = EditDynamicDataList }, JsonRequestBehavior.AllowGet);
             // var data = FormFieldController.GetCategory();     
         }
        public JsonResult UniqueFieldCheck(string Formid, string fieldid,string Value)
         {
             RelianceController.CreateFormMaster createFormMaster = new RelianceController.CreateFormMaster();
             var value = createFormMaster.IsValueExist(Formid, fieldid, Value);
             if (value == true)
             {
                 return Json(new { Response = "OK" }, JsonRequestBehavior.AllowGet);
             }
             else 
             {
                 return Json(new { Response = "" }, JsonRequestBehavior.AllowGet);
             
             }
         }
    }
}
