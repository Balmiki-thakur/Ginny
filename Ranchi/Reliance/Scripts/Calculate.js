
$('#numofprods1').blur(function (e)
{
    var txtVal = parseFloat($(this).val());
    $('#orderamount1').val(txtVal);
});
$('#unitprice').blur(function (e)
{
    var txtVal = parseFloat($(this).val()) * parseInt($('#numofprods1').val());
    $('#orderamount1').val(txtVal);
});

$('#discount1').blur(function (e)
{
    var txtVal = (parseFloat($(this).val()) * parseFloat($('#unitprice').val()) * parseFloat($('#numofprods1').val())) / 100;
    $('#orderamount1').val(txtVal);
});