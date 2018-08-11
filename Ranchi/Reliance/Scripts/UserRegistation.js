$(document).ready(function () {
    var formid =12;
    var CompanyId = 1;
    debugger;
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
                if (data.Response[j].Field_type == 'Text Box') {
                    if (Dataway == 'date') {
                        $(content).append
                       (

                           "<div class='FormCounter'>"
                       + "<span class='form-group'>" + UFieldName + ":</span>"
                       + " <input type='text' required class='form-control input-circle datepicker' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                       + "</div>"

                            );
                        $(".datepicker").datepicker();

                    }

                    else if (Dataway == 'TextArea') {

                        $(content).append
                        (
                        "<div class='FormCounter'>"
                         + "<span class='form-group'>" + UFieldName + ":</span>"
                         + "<textarea name='" + Display_name + "' rows='4' class='form-control input-circle'  placeholder='" + place + "' id='" + Display_name + "'>"
                         + "</textarea>"
                         + "</div>"

                       );

                    }
                    else {
                        $(content).append
                            (
                             "<div class='FormCounter'>"
                            + "<span class='form-group'>" + UFieldName + ":</span>"
                            + " <input type='" + Dataway + "' required class='form-control input-circle' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                            + "</div>"
                           );
                    }
                    if (ChildForm == 'ChildForm') {
                        var childtextlables = '';
                        var childtextInput = '';
                        childtextlables += "<th> " + UFieldName + "</td>"
                        childtextInput += "<td><input type='" + Dataway + "' required class='form-control input-circle' placeholder='" + place + "' id=''  name='" + Display_name + "'value=''/></td>"
                        $("#header_field").append(childtextlables);
                        $("#body_fields").append(childtextInput);
                    }
                }

                else if (data.Response[j].Field_type == 'RadioCheck') {

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
                }
                else if (data.Response[j].Field_type == 'AutoComplete') {
                    $(content).append
                        (
                        "<div class='FormCounter'>"
                        + "<span class='form-group'>" + UFieldName + ":</span>"
                        + " <input type='" + Dataway + "' required class='form-control input-circle autocomplet' placeholder='" + place + "'  id='txtAutoComplete'  name='" + Display_name + "'value=''/>"
                        + "</div>"
                       );

                    if (ChildForm == 'ChildForm') {
                        var childautolable = '';
                        var childautoInput = '';
                        childautolable += "<th> " + Display_name + "</th> "
                        childautoInput += "<td><input type='" + Dataway + "' required class='form-control input-circle' placeholder='" + place + "'  name='" + Display_name + "'value=''/></td>"
                        $("#header_field").append(childautolable);
                        $("#body_fields").append(childautoInput);
                    }
                }

                else if (data.Response[j].Field_type == 'Lookup') {
                    var LookUpAppand = '';
                    LookUpAppand += "<div class='FormCounter'>"
                    LookUpAppand += "<span class='form-group'>" + UFieldName + ":</span>"
                    LookUpAppand += " <input type='" + DataType + "'  required readonly='readonly' class='form-control input-circle LookUpID-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                    LookUpAppand += "</div>";
                    $("#LookUp").append(LookUpAppand);

                    if (ChildForm == 'ChildForm') {
                        var ChildLookUpAppandlable = '';
                        var LookUpAppand = '';
                        ChildLookUpAppandlable += "<th> " + UFieldName + "</th>"
                        LookUpAppand += "<td> <input type='" + DataType + "'  required readonly='readonly' class='form-control input-circle LookUpID-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/></td>";
                        $("#header_field").append(ChildLookUpAppandlable);
                        $("#body_fields").append(LookUpAppand);
                    }
                }
                else if (data.Response[j].Field_type == 'FilterDDL') {
                    if (IsDDLFilter == 1) {
                        var IsDDLFilterAppand = '';
                        var IsDDLFilterS = '';
                        IsDDLFilterAppand += "<div class='FormCounter'>"
                        IsDDLFilterAppand += "<span class='form-group'>" + UFieldName + ":</span>"
                        IsDDLFilterAppand += "<select   onchange='GetDDlFilter(" + DisplayName + ")' required class=' form-control input-circle  ISDDLFIlterss' DDlFilter='" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "' value=''>"

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
                        htmlappend += "<div class='FormCounter'><span class='form-group'>" + UFieldName + ":</span>" + "<div class='form-group'>"
                        if (IsLookUp == 1) {

                            htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }

                        else if (IsDDLFilter == 1) {
                            htmlappend += "<select onchange='GetDDlFilter(" + DisplayName + ")' class='form-control' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        else {

                            htmlappend += "<select  class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        htmlappend += "</div></div>"
                        $('#dropdow').append(htmlappend);


                        if (ChildForm == 'ChildForm') {
                            var htmlappend = '';
                            var dropddownlable = ''
                            dropddownlable += "<th> " + Display_name + "</th>"
                            if (IsLookUp == 1) {
                                htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control input-circle' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            else {
                                htmlappend += "<select  class='form-control  input-circle' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control  dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            $('#header_field').append(dropddownlable);
                            $('#body_fields').append(htmlappend);
                        }
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
                        if (IsLookUp == 1) {
                            htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        else if (IsDDLFilter == 1) {
                            htmlappend += "<select onchange='GetDDlFilter(" + DisplayName + ")' class='form-control' DDlFilter='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        else {
                            htmlappend += "<select  class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        htmlappend += "</div></div>"
                        $('#dropdow').append(htmlappend);


                        if (ChildForm == 'ChildForm') {
                            var htmlappend = '';
                            var dropddownlable = ''
                            dropddownlable += "<th> " + Display_name + "</th>"
                            if (IsLookUp == 1) {
                                htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control input-circle' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            else {
                                htmlappend += "<select  class='form-control  input-circle' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control  dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                            }
                            $('#header_field').append(dropddownlable);
                            $('#body_fields').append(htmlappend);
                        }




                    }

                    //$('#body_fields').append(htmlappend);
                }

                else if (data.Response[j].Field_type == 'CheckBoxList') {

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
                                htmlCheckBoxList = "<div >"
                                htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                                htmlCheckBox += " <span><input type='checkbox' name=" + Display_name + " value=" + data.Responses[i].Key + " /><label>" + data.Responses[i].Values + "</label></span>"
                                htmlCheckBoxList += "</div>";
                                //htmlCheckBoxList += "<option class=' " + data.Responses[i].FormName + "' value='" + data.Responses[i].Key + "'>" + data.Responses[i].Values + "</option>";
                            }

                        },
                    });
                    $('#htmlCheckBox').append(htmlCheckBoxList);
                    $('#htmlCheckBoxslist').append(htmlCheckBox);
                }
            }
            document.getElementById('formNameId').innerText = FormName;
            document.getElementById('formNameTable').innerHTML = FormName;
            document.getElementById('formName').value = FormName;
            var n = 2;
            $("[class*='columnStyle'] div").children('.FormCounter').addClass('col-md-' + 12 / n + '');
            // $("#content").html(str);ss
        },

    });

});

