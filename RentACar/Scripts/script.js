$(document).ready(function() {
    $('.toggle_nav').click(function(e) {
        $(this).toggleClass('active');
        $('.navigation ul').toggleClass('active');
 
        e.preventDefault();
    });

    $('.begin_time').click(function() {
    
    $( "#begin_datepicker" ).datepicker({
    
    minDate: 0,
    hideIfNoPrevNext: true

});
    var currentDate = $( "#begin_datepicker" ).datepicker( "getDate" );
    });
  
    alert(currentDate);
    $( "#end_datepicker2" ).datepicker(
        {

        minDate: 0,
        hideIfNoPrevNext: true

});
      
  
     $('.begin_time').click(function() {
       
        $('.choose_time').toggle();
        $('.choose_time ul li').click(function() {
            var choose = $(this).text();
            $('.begin_time').val(choose);
          $('.choose_time').hide();
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
         $('.city').click(function() {
        $('.choose_city').toggle();
        $('.choose_city ul li').click(function() {
            var choose = $(this).text();
            $('.city').val(choose);
          $('.choose_city').hide();
    });
    });



});