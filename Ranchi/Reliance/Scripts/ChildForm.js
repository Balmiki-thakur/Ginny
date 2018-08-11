$(document).ready(function () {
    var formid = 20010//document.getElementById('FormId').value;
    var CompanyId = 1//document.getElementById('CompanyId').value;
    $.ajax({
        type: "POST",
        url: "/Dynamic/MultiFields/?formid=" + formid + "&CompanyId=" + CompanyId,
        datatype: "JSON",
        contentType: "application/json;charset=utf-8",
        traditional: true,
        success: function (data) {
            var data = $.parseJSON(JSON.stringify(data));
            var FormName = '';
            var ChildForm = 'ChildForm';

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
                var ChildTextTh='';
               ChildTextTh += "<th>" + UFieldName + "</th>";
                $("#headerth").append(ChildTextTh);
                if (data.Response[j].Field_type == 'Text Box') {
                    switch (Dataway) {
                        case 'date':

                            //$(".ChildTextBoxTh").append("<th>" + UFieldName + "</th>")

                            $(".ChildTexboxBody").append
                           (
                             "<td> <input type='text' required class='form-control input-circle datepicker' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/></td>"
                            );
                            $(".datepicker").datepicker({ format: 'dd-mm-yyyy' });
                            break;
                        case 'TextArea':
                           // $(".ChildTextBoxTh").append("<th>" + UFieldName + "</th>")
                            $(".ChildTexboxBody").append
                            (
                             + "<td><textarea name='" + Display_name + "' rows='4' class='form-control input-circle'  placeholder='" + place + "' id='" + Display_name + "'>"
                             + "</textarea></td>"

                           );
                            break;
                        default:
                         //   $(".ChildTextBoxTh").append("<th>" + UFieldName + "</th>")
                            $(".ChildTexboxBody").append
                                (
                                "<td> <input type='" + Dataway + "' required class='form-control input-circle' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/></td>"
                               );
                    }
                }

                else if (data.Response[j].Field_type == 'RadioCheck') {
                    var ChildRadioButtonTh = '';
                    var ChildRadioButtonTd = '';
                    ChildRadioButtonTh += "<th>" + UFieldName + "</th>"
                    $.ajax({
                        type: "POST",
                        url: "/FormMaster/DropDownData/?FormId=" + dropid + "&FieldId=" + FieldId,
                        datatype: "JSON",
                        contentType: "application/json;charset=utf-8",
                        traditional: true,
                        async: false,
                        success: function (data) {
                            var data = $.parseJSON(JSON.stringify(data));
                            for (var i = 0; i < data.Responses.length; i++) {
                                ChildRadioButtonTd = "<td ><span><input type='radio' name=" + Display_name + " value=" + data.Responses[i].Key + " /><label>" + data.Responses[i].Values + "</label></span></td>"
                            }
                        },
                    });
                    $('.RadioCheckchildLable').append(ChildRadioButtonTh);
                    $('.RadioCheckClild').append(ChildRadioButtonTd);
                }
                else if (data.Response[j].Field_type == 'AutoComplete') {
                    var ChildAutoCompletTh = ''
                    var ChildAutoCompletTd = ''
                  
                    ChildAutoCompletTd = " <td><input type='" + Dataway + "' required class='form-control input-circle autocomplet' placeholder='" + place + "'  id='txtAutoComplete'  name='" + Display_name + "'value=''/></td>"
                  
                    $(".ChildAutoCompletTd").html(ChildAutoCompletTd);
                }

                else if (data.Response[j].Field_type == 'Lookup') {
                    var ChildLookUpAppandTh = '';
                    var ChildLookUpAppandTd = '';
                   // ChildLookUpAppandTh += "<th>" + UFieldName + "</th>"
                    ChildLookUpAppandTd += " <td><input type='" + DataType + "'  required readonly='readonly' class='form-control  LookUpID-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/></td>"

                  //  $(".ChildLookUpAppandTh").append(ChildLookUpAppandTh);
                    $(".ChildLookUpAppandTd").append(ChildLookUpAppandTd);


                }
                else if (data.Response[j].Field_type == 'FilterDDL') {
                    if (IsDDLFilter == 1) {
                        var ChildIsDDLFilterth = '';
                        var ChildIsDDLFiltertd = '';
                      //  ChildIsDDLFilterth = "<th><label class='control-label'>" + UFieldName + "</label></th>"
                        ChildIsDDLFiltertd = "<td><select   onchange='GetDDlFilter(" + DisplayName + ")' required class=' form-control   ISDDLFIlterss' DDlFilter='" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "' value=''></select></td>"

                    }
                    else {
                        ChildIsDDLFiltertd += "<td><select   required class='form-control   ISDDLFIlterss  ISDDLFIlter-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''></select></td>"
                    }
                  //  $(".ChildIsDDLFilterth").append(ChildIsDDLFilterth);
                    $(".ChildIsDDLFiltertd").append(ChildIsDDLFiltertd);

                }
                else if (data.Response[j].Field_type == 'Drop Down') {
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
                        htmlappend += "<td'>"
                        if (IsLookUp == 1) {
                            htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        else if (IsDDLFilter == 1) {
                            htmlappend += "<select onchange='GetDDlFilter(" + DisplayName + ")' class='form-control' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        else {
                            htmlappend += "<select  class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        htmlappend += "</td>"

                        $('.dropdowchild').append(htmlappend);
                    }
                    else {
                        var htmlvalue = '';
                        var htmlappendChild = '';
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
                      //  htmlappendChild += "<th>" + UFieldName + ":</th>"
                        var htmlappend = '';
                        if (IsLookUp == 1) {
                            htmlappend += "<td><select onchange='GetLooKUP(" + DisplayName + ")' class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select></td>"
                        }
                        else if (IsDDLFilter == 1) {
                            htmlappend += "<td><select onchange='GetDDlFilter(" + DisplayName + ")' class='form-control' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select></td>"
                        }
                        else {
                            htmlappend += "<td><select  class='form-control filterForSelect' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        htmlappend += "</td>"
                      //  $(".htmlappendChild").html(htmlappendChild);
                        $('.dropdowchild').append(htmlappend);
                    }

                    //$('#body_fields').append(htmlappend);
                }

                //else if (data.Response[j].Field_type == 'CheckBoxList')
                //{

                //    var htmlCheckBoxList = '';
                //    var htmlCheckBox = '';
                //    htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                //    $.ajax({
                //        type: "POST",
                //        url: "/FormMaster/DropDownData/?FormId=" + dropid + "&FieldId=" + FieldId,
                //        datatype: "JSON",
                //        contentType: "application/json;charset=utf-8",
                //        traditional: true,
                //        async: false,
                //        success: function (data) {

                //            var data = $.parseJSON(JSON.stringify(data));
                //            //htmlvalue += '<option value="0">Select</option>';
                //            for (var i = 0; i < data.Responses.length; i++) {
                //                htmlCheckBoxList = "<td >"
                //                htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                //                htmlCheckBox += " <span><input type='checkbox' name=" + Display_name + " value=" + data.Responses[i].Key + " /><label>" + data.Responses[i].Values + "</label></span>"
                //                htmlCheckBoxList += "</div>";
                //                //htmlCheckBoxList += "<option class=' " + data.Responses[i].FormName + "' value='" + data.Responses[i].Key + "'>" + data.Responses[i].Values + "</option>";
                //            }

                //        },
                //    });
                //    $('#htmlCheckBox').append(htmlCheckBoxList);
                //    $('#htmlCheckBoxslist').append(htmlCheckBox);
                //}
                debugger;
              
            }
          
            // document.getElementById('formNameId').innerText = FormName;
            //document.getElementById('formNameTable').innerHTML = FormName;
            //   document.getElementById('formName').value = FormName;
            var n = 2;
            $("[class*='columnStyle'] div").children('.FormCounter').addClass('col-md-' + 12 / n + '');
            // $("#content").html(str);ss
        },
    });

});