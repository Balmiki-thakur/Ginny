
$('#documentactions').on('change', function () {
     var fieldData = "";
    var formId = document.getElementById("documentactions").value;
    $.ajax
    ({
        type: "POST",
        url: "/WorkFlowStatus/WorkFlowStatusbyformid/?formid=" + formId,
        success: function (data) {
            fieldData = '<option value="0">Select</option>'
            for (var j = 0; j < data.Response.length; j++) {
                fieldData += "<option value='" + data.Response[j].StatusName + "'>" + data.Response[j].StatusName + "</option>";
            }
            $("#documentactionsstatus").html(fieldData);
        },
    });
});