var Formid = document.getElementById('FormId').value;;
$.ajax({
    type: "POST",
    url: "/FieldValidation/ValidationByFormId/?formid=" + Formid,
    datatype: "JSON",
    success: function (data) {
        debugger;
        var data = $.parseJSON(JSON.stringify(data));
        var textAppand = "";
        for (var j = 0; j < data.Response.length; j++) {

            var FormId = data.Response[j].FormId;
            var FieldId = data.Response[j].FieldId;
            var OpratorId = data.Response[j].Operator;
            var Value = data.Response[j].Value;
            var ErrorMsg = data.Response[j].ErrorMsg;
            var DocumentType = data.Response[j].DocNature;
            var ValidationType = data.Response[j].ValidationType;
            textAppand += " <input type='hidden'  class='form-control input-circle'validationtype='" + ValidationType + "' ValidateValue='" + Value + "'    id='M" + FieldId + "' name='" + FieldId + "' value='" + ErrorMsg + "'/>"
            $("#contentdiv").html(textAppand);

        }

    }
});

function checkname(formid, fieldid) {
    var name = document.getElementById(fieldid).value;
    if (name) {
        $.ajax({
            type: "POST",
            url: "/FormMaster/UniqueFieldCheck/?FormId=" + formid + "&FieldId=" + fieldid + "&Value= " + name,
            datatype: "JSON",
            contentType: "application/json;charset=utf-8",
            traditional: true,
            async: false,
            success: function (data) {

                var Response = data.Response;
                if (Response == "OK") {
                    debugger;
                    $('#errmsg').html("Data is allready Exist");
                    return false;

                }
                else {

                    return true;
                }
            }
        });
    }
    else {
        $('#name_status').html("");
        return false;
    }
}
