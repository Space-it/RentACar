$(document).ready(function() {





  $('.toggle_nav').click(function(e) {
    $(this).toggleClass('active');
    $('.navigation ul').toggleClass('active');

    e.preventDefault();
  });

  $('.arrow').click(function(e) {
   $('.dropdown ul').toggle();
 });





  $('.city').click(function() {
    $('.choose_city').toggle();
    $('.choose_city ul li').click(function() {
      var choose = $(this).text();
      $('.city').val(choose);
      $('.choose_city').hide();
    });
  });
 $(function(){
  $(document).click(function(event) {
    if ($(event.target).closest(".city").length) return;
    $(".choose_city").hide();
    event.stopPropagation();
  });
});

( function( factory ) {
  if ( typeof define === "function" && define.amd ) {

    // AMD. Register as an anonymous module.
    define( [ "../widgets/datepicker" ], factory );
  } else {

    // Browser globals
    factory( jQuery.datepicker );
  }
}( function( datepicker ) {

datepicker.regional.ru = {
  closeText: "Закрыть",
  prevText: "&#x3C;Пред",
  nextText: "След&#x3E;",
  currentText: "Сегодня",
  monthNames: [ "Январь","Февраль","Март","Апрель","Май","Июнь",
  "Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь" ],
  monthNamesShort: [ "Янв","Фев","Мар","Апр","Май","Июн",
  "Июл","Авг","Сен","Окт","Ноя","Дек" ],
  dayNames: [ "воскресенье","понедельник","вторник","среда","четверг","пятница","суббота" ],
  dayNamesShort: [ "вск","пнд","втр","срд","чтв","птн","сбт" ],
  dayNamesMin: [ "Вс","Пн","Вт","Ср","Чт","Пт","Сб" ],
  weekHeader: "Нед",
  dateFormat: "dd.mm.yy",
  firstDay: 1,
  isRTL: false,
  showMonthAfterYear: false,
  yearSuffix: "" };
datepicker.setDefaults( datepicker.regional.ru );

return datepicker.regional.ru;

} ) );




$( "#end_datepicker2" ).datepicker({
    dateFormat: "dd/mm/yy",
 
    


  }
  );
 
 



  $( "#begin_datepicker" ).datepicker({
  dateFormat: "dd/mm/yy",
    minDate: 0,
    hideIfNoPrevNext: true,
    onSelect: function(date){            
      var date1 = $('#begin_datepicker').datepicker('getDate');           
      var date = new Date( Date.parse( date1 ) );        
      var newDate = date.toDateString(); 
      newDate = new Date( Date.parse( newDate ) );                      
      $('#end_datepicker2').datepicker("option","minDate",newDate);            
    }
  });

$('.begin_time').click(function() {
  $('.choose_time').toggle();
  $('.choose_time ul li').click(function() {
    var choose = $(this).text();
    $('.begin_time').val(choose);
    $('.choose_time').hide();
  });
});

$(function(){
  $(document).click(function(event) {
    if ($(event.target).closest(".begin_time").length) return;
    $(".choose_time").hide();
    event.stopPropagation();
  });
});



$('.end_time').click(function() {
  $('.choose_time2').toggle();
  $('.choose_time2 ul li').click(function() {
    var choose = $(this).text();
    $('.end_time').val(choose);
    $('.choose_time2').hide();
  });
});

$(function(){
  $(document).click(function(event) {
    if ($(event.target).closest(".end_time").length) return;
    $(".choose_time2").hide();
    event.stopPropagation();
  });
});


$('.avto').on('change',function() {
  $('.show_avto').hide();



  $('.show_avto').show(100);





});




});
























  $( "#begin_datepicker" ).datepicker({
    dateFormat: "dd/mm/yy",
           
    }
  });

