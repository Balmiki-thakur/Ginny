$(document).ready(function () {
    var formid = document.getElementById('FormId').value;  
    $.ajax({
        type: "POST",
        url: "/RuleEngin/RuleList/?formid=" + formid,
        datatype: "JSON",
        contentType: "application/json;charset=utf-8",
        traditional: true,
        success: function (data) {
            
            var data = $.parseJSON(JSON.stringify(data));
            var FormName = '';
            var ChildForm = 'ChildForm';
            for(var j = 0; j < data.Response.length;j++)
            {             
                var RuleName = data.Response[j].RuleName;
                var ErrorMessage = data.Response[j].ErrorMessage;
                var Formid = data.Response[j].FormName;
                var Fieldid = data.Response[j].FieldName;
                var Rule = data.Response[j].Clientcondition;
                var MainConditon = data.Response[j].MainConditon;
                var Equelfield = data.Response[j].Equelfield;
                var PriceConditionrule = data.Response[j].PriceConditionrule;
                var Fieldvalue = data.Response[j].Fieldvalue;
                var ConditionField= data.Response[j].ConditionField
                $(Rules).append
                    (
                     "<div class='FormCounter'>"                
                    + " <input type='hidden'class='validateRule' ConditionField='" + ConditionField + "' MainConditon='" + MainConditon + "'  Equelfield='" + Equelfield + "' PriceConditionrule='" + PriceConditionrule + "' Fieldvalue='" + Fieldvalue + "' placeholder='" + ErrorMessage + "' id='" + Formid + "' name='" + Fieldid + "'value='" + Rule + "'/>"
                    + "</div>"
                   );
            };
        },
    });
    $(document).on("click", "#btnSave", function () {
        debugger;
        $(".validateRule").each(function ()
        {
            var RuleFieldName = $(this).val();
            var MainConditon = $(this).attr('MainConditon');
            var Equelfield = $(this).attr('Equelfield');
            var PriceConditionrule = $(this).attr('PriceConditionrule');
            var Fieldvalue = $(this).attr('Fieldvalue');
            var ConditionField = $(this).attr('ConditionField');
            var data = document.getElementById(RuleFieldName).value;
            var errorMessage = $(this).attr('placeholder');
            if (MainConditon == "name")
            {
                if (Equelfield == "is_not_empty")
                {
                    if (data == "" || data == "0")
                    {
                        alert(errorMessage)
                        return false;
                    }
                }
            }
            if (MainConditon == "price")
            {
                if (PriceConditionrule == "less")
                {                  
                    if (parseInt(data) > parseInt(Fieldvalue))
                    {
                        alert(errorMessage)
                        return false;
                    }
                }
                else if (PriceConditionrule == "less_or_equal")
                {
                    if (Number(data) >= Number(Fieldvalue))
                    {
                        alert(errorMessage)
                        return false;
                    }
                }
                else if (PriceConditionrule == "greater") 
                {                  
                    if (ConditionField == 0)
                    {
                        if (data < Fieldvalue)
                        {
                            alert(errorMessage)
                            return false;
                        }
                    }
                    else
                    {
                        var Conditionid = document.getElementById("Item").value;                      
                        $.ajax
                      ({
                          type: "POST",
                          url: "/RuleEngin/CheckFieldValue/?CurrentFeildValue=" + data + "&ConditionField=" + ConditionField + "&Conditionid=" + Conditionid + "&RuleFieldName=" + RuleFieldName,
                          success: function (data)
                          {
                              var data = $.parseJSON(JSON.stringify(data));                           
                              if (data.Resp == "0")
                              {                                
                                  alert(errorMessage)
                                  return false;
                              }
                             
                          }
                      });
                    }
                }
                else if (PriceConditionrule == "greater_or_equal")
                {                 
                    if (data > parseInt(Fieldvalue))
                    {
                      alert(errorMessage)
                      return false;
                    }
                }
            }
        });
    });  
});


