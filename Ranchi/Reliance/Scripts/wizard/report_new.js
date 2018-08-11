function report_cate1(val,val1){
 var cate=document.getElementById(val).value;
  var subcate=document.getElementById(val1).value;
 //alert(cate+subcate);
        $.ajax({
            type : 'POST',
            url  : 'ajax/report_cate_ajax.php?flag=1&cate='+cate+'&subcate='+subcate,
            beforeSend: function(){
                loading();
            },
            success: function(responseText){
               //alert(responseText);
                unloading();
                $("#sbOne").html(responseText);

            }
        });
        $.ajax({
            type : 'POST',
            url  : 'ajax/report_cate_ajax.php?flag=11&cate='+cate+'&subcate='+subcate,
           
            success: function(responseText){
              // alert(responseText);
              //  unloading();
                $("#tabelsname").val(responseText);

            }
        });
}

    function moveAll(from, to) {
        $('#'+from+' option').remove().appendTo('#'+to); 
    }
    function moveSelected(from, to) {
        
        $('#'+from+' option:selected').remove().appendTo('#'+to); 
    }
    function moveAll1(from, to) {
       //alert("aa");
       $('#'+to+' option').remove();
        $('#'+from+' option').clone().appendTo('#'+to); 
       getselectedfields();
    }
    function moveAll2(from, to) {
       // alert("aa");
            $('#'+to+' option').remove();
        $('#'+from+' option').clone().appendTo('#'+to); 
        getgroupfields();
    }
    function moveSelected_check(id, to)
    {
        var element=document.getElementById(id).value;
        var cate=$('#cateselect').val();
        var subcate=$('#subcateselect').val();
        //alert(element+cate);
        $.ajax({
            type : 'POST',
            url  : 'ajax/report_cate_ajax.php?flag=2&cate='+cate+'&type='+element+'&subcate='+subcate,
           
            success: function(responseText){
              // alert(responseText);
               if(responseText==1)
               {
                    $("#erro_sum").html("");
                    moveSelected(id, to);
               }
               else
               {
                $("#erro_sum").html("Can't perform this action on this element");
               }
               
                //$("#sbOne").html(responseText);

            }
        });
    }

    function report_cate(cate)
    {

        var cate=$('#cateselect').val();
         $('#showdiv').css("display", "block");
        //alert(element+cate);
        $.ajax({
            type : 'POST',
            url  : 'ajax/report_cate_ajax.php?flag=3&cate='+cate,
           
            success: function(responseText){
           
                $("#subcateselect").html(responseText);
              

            }
        });
    }
    function getselectedfields()
    {
          
        
        var arr = []; // create array
        var arr1 = [];

$('#sbTwo').children().each(function() {
    arr.push($(this).text()); // add option text to array
     arr1.push($(this).val()); // add option text to array
});
$('#selectedfielddiv').val(arr.join(','));
$('#selectedfielddiv1').val(arr1.join(','));
//alert(arr.join(', ')); // Nature, Cats, Space
//alert(arr1.join(', ')); 
    }
     function getgroupfields()
    {
          
        var arr = [];
        var array1 = []; // create array
         var array2 = []; 
        // var array3 = []; 

$('#sbfour').children().each(function() {
    arr.push($(this).text()); // add option text to array
});
$('#selectedfieldgroupdiv').val(arr.join(','));
//alert(arr.join(', ')); 
var array1=$('#selectedfieldgroupdiv').val();
//alert(array1);
var array2=$('#selectedfielddiv1').val();
//alert(array2);
if(array1=="")
{
    var array3=array2;
}
else
{
    var array3 = array1 + ',' + array2;

}
// /var array3 = array1.concat(array2);
var array1 = array3.split(',');
var unique = array1.filter(function(elem, index, self) {
    return index == self.indexOf(elem);
})
$('#selectedfieldgroupdiv1').val(unique);
    alert(unique);
//$('#selectedfieldgroupdiv1').val(array3);

    }
function summaried_byfun()
{
   // alert("aa");
//alert($('#summaried_by').val());
if($('#summaried_by').val()=="")
{

}
else
{
         var sac=$('#summaried_by').val()+'('+$("#sbsix :selected").val()+')';
        // alert(sac);
        $("#sbsix :selected").val(sac);
}
        
}

function summariedvalue()
    {
          
        var arr = [];
        var arr1 = [];
        var array1 = []; // create array
         var array2 = []; 
        // var array3 = []; 

$('#sbsix').children().each(function() {
    arr.push($(this).text()); // add option text to array
});
array1=arr.join(','); 
$('#sbsix').children().each(function() {
    arr1.push($(this).val()); // add option text to array
});
array4=arr1.join(','); 

var array2=$('#selectedfieldgroupdiv1').val();
//alert(array2);
if(array1=="")
{
    var array3=array2;
}
else
{
    var array3 = array1 + ',' + array2;

}
//alert(array3);
// /var array3 = array1.concat(array2);
var array11 = array3.split(',');
var unique = array11.filter(function(elem, index, self) {
    return index == self.indexOf(elem);
})
array1=array1.split(',');
array4=array4.split(',');
//alert(array1);
//alert(unique);
//alert(array4);
for(var i=0;i<array1.length;i++)
{
    var index = unique.indexOf(array1[i]);
//alert(index+"next="+array1[i]);
if (index !== -1) {
    unique[i] = array4[i];
}
}
$('#selectedsummried').val(unique);
//alert(unique);
/*$('#selectedfieldgroupdiv1').val(unique);*/
    //alert(unique);
//$('#selectedfieldgroupdiv1').val(array3);

    }

    function finalstepsave()
    {
        var cateselect=$('#cateselect').val();
        var subcateselect=$('#subcateselect').val();
        var sortedby=$('#sortorder').val();
        var tabelsname=$('#tabelsname').val();
        var title=$('#title').val();
        var reportheader=$('#reportheader').val();
        var reportfooter=$('#reportfooter').val();
        var pagefooter=$('#pagefooter').val();
        var Description=$('#Description').val();

        alert('cateselect='+cateselect+'subcateselect='+subcateselect+'sortedby='+sortedby+'title='+title+'');
    }
