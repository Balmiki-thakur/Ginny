﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reliance.Modals
{
   public class FormsFields
    {
            private long formId ;
            private long fieldId = 0;
            private string formName = "";
            private string ufieldName = "";
            private string display_name = "";
            private string field_type = "";
            private string selectedfield = "";
            private int order_number = 0;
            private string field_description = "";
            private string createOn = "";
            private string documentName = "";
            private string documentField = "";
            private int documentFieldId = 0;
            private int isLookUp = 0;
            private string datatypes = "";
            private int isRoleAssignment = 0;
            private int isDdlFilter = 0;
            private int isimeino = 0;
            private int eid = 0;
            private int Userid = 0;
           // private int minLenght = 0;
            public int Eid
            {
                get
                {
                    return this.eid;
                }
                set
                {
                    this.eid = value;
                }
            }
             [Required]
            public long FormId
            {
                get
                {
                    return this.formId;
                }
                set
                {
                    this.formId = value;
                }
            }
            public long FieldId
            {
                get
                {
                    return this.fieldId;
                }
                set
                {
                    this.fieldId = value;
                }
            }
            public string FormName
            {
                get
                {
                    return this.formName;
                }
                set
                {
                    this.formName = value;
                }
            }
            public string Display_name
            {
                get
                {
                    return this.display_name;
                }
                set
                {
                    this.display_name = value;
                }
            }
            public string Field_type
            {
                get
                {
                    return this.field_type;
                }
                set
                {
                    this.field_type = value;
                }
            }
            public string UFieldName
            {
                get
                {
                    return this.ufieldName;
                }
                set
                {
                    this.ufieldName = value;
                }
            }                           
            public string SelectedField
            {
                get
                {
                    return this.selectedfield;
                }
                set
                {
                    this.selectedfield = value;
                }
            }
            public string Field_description
            {
                get
                {
                    return this.field_description;
                }
                set
                {
                    this.field_description = value;
                }
            }
            public string DataTypes
            {
                get
                {
                    return this.datatypes;
                }
                set
                {
                    this.datatypes = value;
                }
            }
            public int Order_number
            {
                get
                {
                    return this.order_number;
                }
                set
                {
                    this.order_number = value;
                }
            }
            public string CreateOn
            {
                get
                {
                    return this.createOn;
                }
                set
                {
                    this.createOn = value;
                }
            }
            public string DocumentName
            {
                get
                ;

                set;

            }
            public string DocumentField
            {
                get;
                set;
            }
            public int DocumentFieldId
            {
                get
                {
                    return this.documentFieldId;
                }
                set
                {
                    this.documentFieldId = value;
                }
            }
            public int IsLookUp
            {
                get
                {
                    return this.isLookUp;
                }
                set
                {
                    this.isLookUp = value;
                }
            }
            public int IsDDLFilter
            {
                get
                {
                    return this.isDdlFilter;
                }
                set
                {
                    this.isDdlFilter = value;
                }
            }
            public int IsRoleAssignment
            {
                get
                {
                    return this.isRoleAssignment;
                }
                set
                {
                    this.isRoleAssignment = value;
                }
            }
            public int IsIMEINo
            {
                get
                {
                    return this.isimeino;
                }
                set
                {
                    this.isimeino = value;
                }
            }
            public int MaxLenght
            {
                get;
                set;
            }
            public int MinLenght
            {
                get;
                set;
            }
            public string FormulaField
            {
                get;
                set;
            }
            public int FormWorkFlow
            { get; set; }
        }
   public class FormRoleList : List<FormsFields>
        {
            public FormRoleList()
            { }
        }
    }
