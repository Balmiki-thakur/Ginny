using Reliance.Modals;
using RelianceController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace Reliance.Controllers
{
    public class DynamicController:Controller
    {
        //
        // GET: /Dynamic/
        #region AA
        #region view page
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TextboxControl() 
        {
            return View();
        }
        public ActionResult Setting() 
        {
            return View();
        }
        public ActionResult Demo1()
        {
            return View();
        }
        public ActionResult DocumentType()
        {
            return View();
        }
        #endregion
        #region not used
       
        [HttpPost]
        public ActionResult Index(string ddl)
        {


            //GoogleMapEntities googleMapEntities = new GoogleMapEntities();

            return View();
        }
        public ActionResult Clientsidecreation()
        {
            var usr = new UserForm();
            usr.Name = "Shivank";
            return View(usr);
        }
        #endregion
        #endregion
        [HttpPost]
        public JsonResult MultiFields(string formid, string CompanyId)
        {        
            if (formid!= null && CompanyId!=null) 
            {
                CreateFormField createFormField = new CreateFormField();
                FormRoleList formrole = createFormField.FieldByFormId(formid, CompanyId);         
                return Json(new { Response = formrole }, JsonRequestBehavior.AllowGet);
            }
            return  Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LookUpBind(string LookupId, string CompanyId)
        {

            if (LookupId != null)
            {
                CreateFormField createFormField = new CreateFormField();
                FormRoleList formrole = createFormField.FieldByFormId(LookupId, CompanyId);
                return Json(new { Response = formrole }, JsonRequestBehavior.AllowGet);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Fields()
        {
            FormFieldController formFieldController = new FormFieldController();
            FormRoleList formrole = formFieldController.AllFormFields();
            return Json(new { Response = formrole }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AllFormList(string CompanyId)
        {
            RelianceController.CreateFormMaster createFormMaster=new RelianceController.CreateFormMaster();
            CreateTableDoList createTableDoList = createFormMaster.AllCreateForm(CompanyId);
            return Json(new { Response = createTableDoList }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AllFormLookUp(string formId)
        {
            CreateFormField createFormField = new CreateFormField();
            FormRoleList formLooKUp = createFormField.AllFormLookUp(formId);
            return Json(new { Response = formLooKUp }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DocumentFieldLookUp(string FieldId)
        {
             CreateFormField createFormField = new CreateFormField();
             FormRoleList formLooKUp = createFormField.AllFieldLookUp(FieldId);
            return Json(new { Response = formLooKUp }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult TextBoxControl(string formName, FormCollection form)
        {
          
            TextBoxList textList = new TextBoxList();
            foreach (String key in form.AllKeys)
            {             
                TextBoxViewModel textBoxList1 = new TextBoxViewModel();
                textBoxList1.FieldId = key;
                textBoxList1.Value = form[key];
              
                textList.Add(textBoxList1);               
            }
            RelianceController.FormFieldController formFieldController = new FormFieldController();
            formFieldController.InsertMetada(formName, "", textList);
           // TextList.Add(textBoxList1);
            return View();
           // return Json(new { OnSuccess = "success" }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ReportFields(string formid)
        {

            if (formid != null)
            {
               
               var DI=  formid.Remove(formid.ToString().LastIndexOf(','), 1);

               CreateFormField createFormField = new CreateFormField();
               FormRoleList formrole = createFormField.AllFieldByFormId(DI);

                return Json(new { Response = formrole }, JsonRequestBehavior.AllowGet);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AllWorkFlowForm(string CompanyId)
        {
            RelianceController.CreateFormMaster createFormMaster=new RelianceController.CreateFormMaster();
            CreateTableDoList createTableDoList = createFormMaster.AllworkFlowForm(CompanyId);
            return Json(new { Response = createTableDoList }, JsonRequestBehavior.AllowGet);
        }         
    }

}
