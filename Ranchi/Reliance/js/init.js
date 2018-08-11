(function($){
  $(function(){

    // $('.button-collapse').sideNav();



     // -----------user drop   -------------	
    $(".userCon").mouseover(function(){
 		 $(".userDrop").addClass("open");
		 $(".flipContainer").addClass("flipper");
	});
    $(".userDrop").mouseleave(function(){
  		$(this).removeClass("open");
  		$(".flipContainer").removeClass("flipper");
	});
 // ---------user drop ends ---------- 



 // -----------menu drop   -------------

 var mL = $('.navigation').children().length;//counts menu

 for(var i=0; i<mL; i++){
  $('.navigation').children().eq(i).addClass('navItem'+i);//adds class to menu
  $('.navigation li:has(ul)').eq(i).addClass('subNavCon'+i);
 }
  var sML = $("[class*='subNavCon']").length;//counts submenu

 for(var j=0; j<sML; j++){
 	var sMCount = $(".subNavCon"+j+" ul").first().children().length;// counts subMenu
 	sMCount +='@'+j; //splits the count
 	var res = sMCount.split("@"); //splits the count
 	if (res[0] > 8) { //conditiions

 		$(".subNavCon"+res[1]).children('.subNav').addClass('mega');
 	}
 	if (res[0] > 8 && res[0] <= 15) {
 		$(".subNavCon"+res[1]).children('.subNav').addClass('Menu1');
 	} 
 	if (res[0] > 15) {
 		$(".subNavCon"+res[1]).children('.subNav').addClass('Menu2');
 	} 
  }

  // -----------menu drop  ends -------------

   // -----------map   -------------
   var mapHei = $(window).height() - 66;
   $('.map').attr('height',mapHei);
   $('.ofh').css('height',$(window).height());//fluid container height
   // -----------map  ends -------------



   // serach filters------------------------------

var filterGen=["Vehical Type","Colors","Site Type","Site"]
var filterHtml="";
var filterCount=filterGen.length;
for(var k=0; k<filterCount; k++){

  filterHtml +='<li class="input-field m-0 arrow cont"><input  type="text" class="validate m-0 white-text filter'+k+'" onfocus="this.value = \'\';" value=""><label for="filter" class="white-text cust" >Select '+filterGen[k]+'</label><span class="valCon'+k+' white"></span></li>'

}
$('.filterCon').html(filterHtml);
// for(var n=0; n<filterCount; n++){

//     var childArr = "childArr"+n;
//     for(var o=0; o<childArr.length; o++){
//         childArr[n] = ['A','B','C'];

//     }

 
  
// $('.valCon'+n).html(childArr);
// }

$('#filter').focusin(function(){
    $('#filter').siblings('.valCon').children('span').fadeIn();
});
  
// for(var m=0; m<filterGen.length;m++){
//       var arr=["kunal","vijay"];
//         var sk ='';
//         for(var l=0;l<arr.length;l++){
//             sk +="<span data-label="+arr[l]+"></span>";
//         }
//     $('.valCon'+m).html(sk); 
// }

 
 // serach filters ends-------------------------
 // legend Sel-------------------------
 $('.chartLeg').click(function(){
  $('.chartCon').toggleClass('transX100');
});
 $('.button-collapse.arrow').click(function(){
  $('.button-collapse.arrow').toggleClass('close-sec');
  $('.chartCon').toggleClass('transX0');
  $('.resultColap').toggleClass('transX100');
  $('.button-collapse').toggleClass('col-md-offset-11')
  $('.button-collapse').toggleClass('col-md-offset-8')
});
$('.resultSecCon').children('.results').click(function(){
  $(this).toggleClass('select-circle');
});
 // legend Sel ends-------------------------


  }); // end of document ready
})(jQuery); // end of jQuery name space