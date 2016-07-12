$(document).ready(function() {
    $('.toggle_nav').click(function(e) {
        $(this).toggleClass('active');
        $('.navigation ul').toggleClass('active');
 
        e.preventDefault();
    });
    $('.arrow').click(function(e) {
       $('.dropdown ul').toggle();
    });

         $('.city_logo').click(function() {
        $('.choose_city').toggle();
        $('.choose_city ul li').click(function() {
            var choose = $(this).text();
            $('.city').val(choose);
          $('.choose_city').hide();
    });
    });
       $('.city').click(function() {
        $(this).val('');
    });
           
          
     $( "#end_datepicker2" ).datepicker({
dateFormat: "dd-mm-yy"
    
       

});
 $( "#begin_datepicker" ).datepicker({
    dateFormat: "dd-mm-yy",
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
       $('.end_time').click(function() {
        $('.choose_time2').toggle();
        $('.choose_time2 ul li').click(function() {
            var choose = $(this).text();
            $('.end_time').val(choose);
          $('.choose_time2').hide();
    });
    });
      $('.avto').click(function() {
        $('.choose_avto').toggle();
        $('.choose_avto ul li').click(function() {
             $('.show_avto').hide();
            var choose = $(this).text();
            $('.avto').val(choose);
          $('.choose_avto').hide();
          $('.show_avto').show(400);
         
    });
    });



});