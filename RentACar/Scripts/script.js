$(document).ready(function() {

  $('.toggle_nav').click(function(e) {
    $(this).toggleClass('active');
    $('.navigation ul').toggleClass('active');

    e.preventDefault();
  });

  $('.arrow').click(function(e) {
   $('.dropdown ul').toggle();
 });


  $('.navigation>ul li a').each(function () {
      var location = window.location.href;
      var link = this.href;
      if (location == link) {
          $(this).addClass('current-item');
      }
  });


  $('.city').click(function() {
    $('.choose_city').toggle();
    $('.choose_city ul li').click(function() {
      var choose = $(this).text();
      $('.city').val(choose);
      $('.choose_city').hide();
    });
  });
 



  $( "#end_datepicker2" ).datepicker();
 



  $( "#begin_datepicker" ).datepicker({
 
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


$('.avto').on('change', function () {

    $('.show_avto').hide();
    var id = $('.avto').val();
    $.ajax({
        type: "POST",
        url: "../EN/ShowCarInfo",
        data: id,
        contentType: "text/plain; charset=utf-8",
        datatype: "text",
        success:
            function(data) {
                $('#result').html(data);
            }
    });

  $('.show_avto').show(100);

});
});