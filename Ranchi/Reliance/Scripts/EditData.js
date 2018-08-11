function Editdata(id) {
    $(".removeEdit div").children('div').empty();
    var formIdName = document.getElementById('FormId').value;
    $.ajax({
        type: "POST",
        url: "/FormMaster/FieldEdit/?formid=" + formIdName + "&Id=" + id,
        datatype: "JSON",
        success: function (data) {

            var data = $.parseJSON(JSON.stringify(data));
            var FormName = '';
            var ChildForm = 'ChildForm';
            for (var j = 0; j < data.Response.length; j++) {
                var Display_name = data.Response[j].FieldName;
                var dropid = data.Response[j].FormId;
                var place = data.Response[j].Field_description;
                var DisplayName = data.Response[j].FieldName;
                var DataType = data.Response[j].DataType;
                var FormName = data.Response[j].FormName;
                var DocumentName = data.Response[j].DocumentType
                var DocumentField = data.Response[j].DocumentField
                var FieldId = data.Response[j].FieldId;
                var IsLookUp = data.Response[j].IsLooKup;
                var FieldValue = data.Response[j].FieldValue;
                if (data.Response[j].FieldType == 'Text Box')
                {
                    var textAppand = '';
                    textAppand += "<div class='FormCounter'>"
                    textAppand += "<span class='form-group'>" + DisplayName + ":</span>"
                    textAppand += " <input type='" + DataType + "' required class='form-control input-circle' placeholder='' id='" + Display_name + "' name='" + Display_name + "' value='" + FieldValue + "'/>"
                    textAppand += "</div>"

                    $("#contentEdit").append(textAppand);
                }

                else if (data.Response[j].Field_type == 'RadioCheck')
                {
                    alert(data.Response[j].Field_type);
                    var htmlCheckBoxList = "";
                    var htmlCheckBox = "";
                    htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                    $.ajax({
                        type: "POST",
                        url: "/FormMaster/DropDownData/?FormId=" + dropid + "&FieldId=" + FieldId,
                        datatype: "JSON",
                        contentType: "application/json;charset=utf-8",
                        traditional: true,
                        async: false,
                        success: function (data)
                       {
                            var data = $.parseJSON(JSON.stringify(data));
                            for (var i = 0; i < data.Responses.length; i++) {
                                htmlCheckBoxList = "<div >"
                                htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                                htmlCheckBox += " <span>  <input type='radio' name=" + Display_name + " value=" + data.Responses[i].Key + " /><label>" + data.Responses[i].Values + "</label></span>"
                                htmlCheckBoxList += "</div>";
                            }

                        },
                    });
                    $('#htmlRadioLableEdit').append(htmlCheckBoxList);
                    $('#htmlCheckRadioListEdit').append(htmlCheckBox);
                    
                } 
              else  if (data.Response[j].FieldType == 'AutoComplete') {
                    $(contentEd).append
                        (
                         "<div class='FormCounter'>"
                        + "<span class='form-group'>" + DisplayName + ":</span>"
                        + " <input type='" + Dataway + "' required class='form-control input-circle' placeholder='" + place + "' id='txtAutoComplete'  name='" + Display_name + " value='" + FieldValue + "'/>"
                        + "</div>"
                       );

                    if (ChildForm == 'ChildForm') {
                        var childautolable = '';
                        var childautoInput = '';
                        childautolable += "<th> " + Display_name + "</th> "
                        childautoInput += "<td><input type='" + Dataway + "' required class='form-control input-circle' placeholder='" + place + "' id='txtAutoComplete'  name='" + Display_name + " value='" + FieldValue + "'/></td>"
                        $("#header_field").append(childautolable);
                        $("#body_fields").append(childautoInput);
                    }
                }

                else if (data.Response[j].FieldType == 'Lookup') {
                    var LookUpAppand = '';
                    LookUpAppand += "<div class='FormCounter'>"
                    LookUpAppand += "<span class='form-group'>" + DisplayName + ":</span>"
                    LookUpAppand += " <input type='" + DataType + "'  required readonly='readonly' class='form-control input-circle LookUpID-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/>"
                    LookUpAppand += "</div>";
                    $("#LookUpEdit").append(LookUpAppand);

                    if (ChildForm == 'ChildForm') {
                        var ChildLookUpAppandlable = '';
                        var LookUpAppand = '';
                        ChildLookUpAppandlable += "<th> " + Display_name + "</th>"
                        LookUpAppand += "<td> <input type='" + DataType + "'  required readonly='readonly' class='form-control input-circle LookUpID-" + FieldId + "' placeholder='" + place + "' id='" + Display_name + "' name='" + Display_name + "'value=''/></td>";
                        $("#header_field").append(ChildLookUpAppandlable);
                        $("#body_fields").append(LookUpAppand);
                    }
                }

        else if (data.Response[j].FieldType == 'Drop Down') {
           
            if (data.Response[j].IsRoleAssignment == 1)
               {
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
                        htmlappend += "<div class='FormCounter'><span class='form-group'>" + DisplayName + ":</span>" + "<div class='form-group'>"
                        if (IsLookUp == 1) {

                            htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required=''  class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        else {
                            htmlappend += "<select  class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' selected='selected' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        htmlappend += "</div></div>"
                        $('#dropdowEdit').append(htmlappend);


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
                        htmlappend += "<div class='FormCounter'><span class='form-group'>" + DisplayName + ":</span>" + "<div class='form-group'>"
                        if (IsLookUp == 1) {

                            htmlappend += "<select onchange='GetLooKUP(" + DisplayName + ")' class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        else {
                            htmlappend += "<select  class='form-control' look='" + FieldId + "' id='" + DisplayName + "' name='" + DisplayName + "' required='' class='form-control input-lg dspn' placeholder=' " + place + "'>" + htmlvalue + "</select>"
                        }
                        htmlappend += "</div></div>"
                        $('#dropdowEdit').append(htmlappend);


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
                   

           }
                else if (data.Response[j].FieldType == 'CheckBoxList') {

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

                                htmlCheckBoxList = "<div>"
                                htmlCheckBoxList += "<label class='col-md-3 control-label'>" + Display_name + "</label>"
                                htmlCheckBox += "<div'> <span><input type='checkbox' name=" + Display_name + " Value=" + data.Responses[i].Values + "/><label>" + data.Responses[i].Values + "</label></span>"
                                htmlCheckBoxList += "</div>";
                                //htmlCheckBoxList += "<option class=' " + data.Responses[i].FormName + "' value='" + data.Responses[i].Key + "'>" + data.Responses[i].Values + "</option>";
                            }

                        },
                    });
                    $('#htmlCheckBoxEdit').append(htmlCheckBoxList);
                    $('#htmlCheckBoxslistEdit').append(htmlCheckBox);
                    //<div class='col-md-4 gadha'> <span><input type='checkbox'><label>Option 1</label></span>"
                    //htmlCheckBoxList += "<span><input type='checkbox'><label>Option 2</label></span><span><input type='checkbox'><label>Option 3</label></span>"
                    //htmlCheckBoxList += "</div>";        
                }
            }

            document.getElementById('formNameId').innerText = FormName;
            document.getElementById('formNameId1').innerText = FormName;
            document.getElementById('formNameId11').value = FormName;
            document.getElementById('formNameTable').innerHTML = FormName;
            document.getElementById('formName').value = FormName;
            document.getElementById('id').value = id;           
            var n = 2;
            $('[class*="columnStyle"]').find('.FormCounter').addClass('col-md-' + 12 / n + '');
                        
            // $("#content").html(str);ss
        },

    });
}