$(document).ready(function () {
    var formid = document.getElementById('FormId').value;
    var CompanyId = document.getElementById('CompanyId').value;
    $.ajax({
        type: "POST",
        url: "/Dynamic/MultiFields/?formid=" + formid + "&CompanyId=" + CompanyId,
        datatype: "JSON",
        contentType: "application/json;charset=utf-8",
        traditional: true,
        success: function (data) {

            var data = $.parseJSON(JSON.stringify(data));
            debugger;

            var FormName = '';

            for (var j = 0; j < data.Response.length; j++) {
                var Display_name = data.Response[j].Display_name;
                var dropid = data.Response[j].FormId;
                var place = data.Response[j].Field_description;
                var DisplayName = data.Response[j].Display_name;
                var DataType = data.Response[j].Field_type;
                var FormName = data.Response[j].FormName;
                var DocumentName = data.Response[j].DocumentName
                var DocumentField = data.Response[j].DocumentField
                var FieldId = data.Response[j].FieldId;
                var IsLookUp = data.Response[j].IsLookUp;
                var Dataway = data.Response[j].DataTypes;
                var UFieldName = data.Response[j].UFieldName;
                var IsDDLFilter = data.Response[j].IsDDLFilter;
                var FormulaField = data.Response[j].FormulaField;
                var FormWorkFlow = data.Response[j].FormWorkFlow;
                switch (data.Response[j].Field_type) {
                    case 'Text Box':
                        switch (Dataway) {
                            case 'date':
                                $(content).append
                               (
                                 " <div class='FormCounter'>"
                               + "<span class='form-group'>" + UFieldName + ":</span>"
                               + " <input type='text' required class='form-control input-circle datepicker' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                               + "</div>"
                                );
                                $(".datepicker").datepicker({ format: 'dd-mm-yyyy' });
                                break;
                            case 'TextArea':
                                $(content).append
                                (
                                "<div class='FormCounter'>"
                                 + "<span class='form-group'>" + UFieldName + ":</span>"
                                 + "<textarea name='" + Display_name + "' rows='4' class='form-control input-circle'  placeholder='" + place + "' id='" + Display_name + "'>"
                                 + "</textarea>"
                                 + "</div>"

                               );
                                break;
                            default:
                                $(content).append
                                    (
                                     "<div class='FormCounter'>"
                                    + "<span class='form-group'>" + UFieldName + ":</span>"
                                    + " <input type='" + Dataway + "' required class='form-control input-circle' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                                    + "</div>"
                                   );
                        }
                        break;
                    case 'formulafield':
                        var formulaappend = "";
                        formulaappend += "<input type='" + DataType + "'  required readonly='readonly' class='form-control input-circle FormulaField-" + FieldId + "'  placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                        formulaappend += "<input type='button' id='calculate' value='" + FieldId + "' class='btn btn-circle green'>"
                        var formula = "";
                        formula += FormulaField;
                        $("#formuladata").val(formula);
                        $("#formulField").html(formulaappend);
                        break;
                    case 'AutoComplete':
                        var autoComplet = '';
                        autoComplet = "<div class='FormCounter'>"
                        autoComplet += "<span class='form-group'>" + UFieldName + ":</span>"
                        autoComplet += " <input type='" + Dataway + "' id='txtName'   required class='form-control input-circle autocomplet='" + FieldId + " placeholder='" + place + "'    name='" + Display_name + "'value=''/>"
                        autoComplet += "<div id='display'  value=[]/>"
                        autoComplet += "</div>"
                        $("#autoComplet").html(autoComplet);
                        break;
                    case 'RadioCheck':
                        var htmlCheckBoxList = '';
                        var htmlCheckBox = '';
                        htmlCheckBoxList += "<label class='col-md-3 control-label'>" + UFieldName + "</label>"
                        $.ajax({
                            type: "POST",
                            url: "/FormMaster/DropDownData/?FormId=" + dropid + "&FieldId=" + FieldId,
                            datatype: "JSON",
                            contentType: "application/json;charset=utf-8",
                            traditional: true,
                            async: false,
                            success: function (data) {
                                var data = $.parseJSON(JSON.stringify(data));
                                //htmlvalue += '<option value="0">Select</option>';
                                for (var i = 0; i < data.Responses.length; i++) {
                                    htmlCheckBoxList = "<div >"
                                    htmlCheckBoxList += "<label class='col-md-3 control-label'>" + UFieldName + "</label>"
                                    htmlCheckBox += " <span>  <input type='radio' name=" + Display_name + " value=" + data.Responses[i].Key + " /><label>" + data.Responses[i].Values + "</label></span>"
                                    htmlCheckBoxList += "</div>";
                                    //htmlCheckBoxList += "<option class=' " + data.Responses[i].FormName + "' value='" + data.Responses[i].Key + "'>" + data.Responses[i].Values + "</option>";
                                }

                            },
                        });
                        $('#htmlRadioLable').append(htmlCheckBoxList);
                        $('#htmlCheckRadioList').append(htmlCheckBox);
                        break;
                    case 'Lookup':
                        var LookUpAppand = '';
                        LookUpAppand += "<div class='FormCounter'>"
                        LookUpAppand += "<span class='form-group'>" + UFieldName + ":</span>"
                        LookUpAppand += " <input type='" + DataType + "'  required readonly='readonly' class='form-control input-circle LookUpID-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                        LookUpAppand += "</div>";
                        $("#LookUp").append(LookUpAppand);
                        break;
                    case 'FilterDDL':
                        if (IsDDLFilter == 1) {
                            var IsDDLFilterAppand = '';
                            var IsDDLFilterS = '';
                            IsDDLFilterAppand += "<div class='FormCounter'>"
                            IsDDLFilterAppand += "<span class='form-group'>" + UFieldName + ":</span>"
                            IsDDLFilterAppand += "<select   onchange=GetDDlFilter('" + DisplayName + "') required class=' form-control1 input-circle  ISDDLFIlterss' DDlFilter='" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "' value=''>"

                            IsDDLFilterAppand += "</select>"

                            //IsDDLFilterAppand += " <input type='" + DataType + "'  required readonly='readonly' class='form-control input-circle LookUpID-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                            IsDDLFilterAppand += "</div>";
                        }
                        else {

                            var IsDDLFilterAppand = '';
                            var IsDDLFilterS = '';
                            IsDDLFilterAppand += "<div class='FormCounter'>"
                            IsDDLFilterAppand += "<span class='form-group'>" + UFieldName + ":</span>"
                            IsDDLFilterAppand += "<select   required class='form-control input-circle  ISDDLFIlterss  ISDDLFIlter-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''>"
                            IsDDLFilterAppand += "</select>"
                            IsDDLFilterAppand += "</div>";

                        }
                        //  IsDDLFilterS += "<select onchange='GetDDlFilter(" + DisplayName + ")' class='form-control' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        $("#IsDDLFilter").append(IsDDLFilterAppand);
                        break;
                    case 'Drop Down':
                        if (data.Response[j].IsRoleAssignment == 1) {
                            var UserId = document.getElementById("UserId").value;
                            var RoleId = document.getElementById("RoleId").value;
                            var Form = document.getElementById("FormId").value;
                            var htmlvalue = '';
                            $.ajax({
                                type: "POST",
                                url: "/FormMaster/DropDownDataIsRoleAssignMent/?FormId=" + dropid + "&FieldId=" + FieldId + "&UserId=" + UserId + "&RoleId=" + RoleId + "&Form=" + Form,
                                datatype: "JSON",
                                contentType: "application/json;charset=utf-8",
                                traditional: true,
                                async: false,
                                success: function (data) {
                                    var data = $.parseJSON(JSON.stringify(data));
                                    htmlvalue += '<option value="0">Select</option>';
                                    for (var i = 0; i < data.Responses.length; i++) {
                                        htmlvalue += "<option class=' " + data.Responses[i].FormName + "' value='" + data.Responses[i].Key + "'>" + data.Responses[i].Values + "</option>";
                                    }
                                },
                            });
                            var htmlappend = '';
                            htmlappend += "<div class='FormCounter'><span class='form-group'>" + UFieldName + ":</span>" + "<div class='form-group'>"
                            if (IsLookUp == 1) {

                                htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }

                            else if (IsDDLFilter == 1) {
                                htmlappend += "<select onchange=GetDDlFilter('" + DisplayName + "') class='form-control1' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            else {

                                htmlappend += "<select  class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            htmlappend += "</div></div>"
                            $('#dropdow').append(htmlappend);
                        }
                        else {
                            var htmlvalue = '';
                            $.ajax({
                                type: "POST",
                                url: "/FormMaster/DropDownData/?FormId=" + dropid + "&FieldId=" + FieldId,

                                datatype: "JSON",
                                contentType: "application/json;charset=utf-8",
                                traditional: true,
                                async: false,
                                success: function (data) {
                                    var data = $.parseJSON(JSON.stringify(data));
                                    htmlvalue += '<option value="0">Select</option>';
                                    for (var i = 0; i < data.Responses.length; i++) {
                                        htmlvalue += "<option class=' " + data.Responses[i].FormName + "' value='" + data.Responses[i].Key + "'>" + data.Responses[i].Values + "</option>";
                                    }
                                },
                            });
                            var htmlappend = '';
                            htmlappend += "<div class='FormCounter'><span class='form-group'>" + UFieldName + ":</span>" + "<div class='form-group'>"
                            if (IsLookUp == IsDDLFilter && (IsLookUp != '0' && IsDDLFilter != '0')) {
                                htmlappend += "<select color='1' data-attr='" + FieldId + "' data-value='"+DisplayName+"' class='form-control testClass' look='" + FieldId + "' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                           else if (IsLookUp == 1) {
                                htmlappend += "<select onchange=GetLooKUP('" + DisplayName + "') class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            else if (IsDDLFilter == 1) {
                                htmlappend += "<select onchange=GetDDlFilter('" + DisplayName + "') class='form-control' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            else {
                                htmlappend += "<select  class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            htmlappend += "</div></div>"
                            $('#dropdow').append(htmlappend);
                        }
                        //$('#body_fields').append(htmlappend);
                        break;
                    case 'CheckBoxList':
                        var htmlCheckBoxList = '';
                        var htmlCheckBox = '';
                        htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                        $.ajax({
                            type: "POST",
                            url: "/FormMaster/DropDownData/?FormId=" + dropid + "&FieldId=" + FieldId,
                            datatype: "JSON",
                            contentType: "application/json;charset=utf-8",
                            traditional: true,
                            async: false,
                            success: function (data) {

                                var data = $.parseJSON(JSON.stringify(data));
                                //htmlvalue += '<option value="0">Select</option>';
                                for (var i = 0; i < data.Responses.length; i++) {
                                    var Key = data.Responses[i].Key;
                                    htmlCheckBoxList = "<div >"
                                    htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                                    htmlCheckBox += " <span><input type='checkbox' class=CheckBoxData" + Key + " name=" + Display_name + " value=" + Key + " /><label>" + data.Responses[i].Values + "</label></span>"
                                    htmlCheckBoxList += "</div>";
                                    var ids = '';
                                    var count = $('input.CheckBoxData' + Key + ':checked').length;
                                    if (count == 1) {
                                        $('.CheckBoxData' + Key + ':checked').each(function () {
                                            Key += $(this).val() + ',';

                                        });
                                    }
                                    //htmlCheckBoxList += "<option class=' " + data.Responses[i].FormName + "' value='" + data.Responses[i].Key + "'>" + data.Responses[i].Values + "</option>";
                                }

                            },
                        });
                        $('#htmlCheckBox').append(htmlCheckBoxList);
                        $('#htmlCheckBoxslist').append(htmlCheckBox);
                        break;

                }
                document.getElementById('formNameId').innerText = FormName;
                document.getElementById('formNameTable').innerHTML = FormName;
                document.getElementById('formName').value = FormName;
                document.getElementById('FormWorkFlow_1').value = FormWorkFlow;

                var n = 2;
                $("[class*='columnStyle'] div").children('.FormCounter').addClass('col-md-' + 12 / n + '');
                // $("#content").html(str);ss
            }
        },
    });
});
