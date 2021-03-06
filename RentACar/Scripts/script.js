﻿$(document).ready(function() {

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
        chosen_city = $(this).text();
        $('.city').val(chosen_city);
      $('.choose_city').hide();
    });
  });



  $("#begin_datepicker" ).datepicker({
 
    minDate: 0,
    hideIfNoPrevNext: true,
    onSelect: function(date){            
        date1 = $('#begin_datepicker').datepicker('getDate');
        calcSum();
      var date = new Date( Date.parse( date1 ) );        
      var newDate = date.toDateString(); 
      newDate = new Date( Date.parse( newDate ) );                      
      $('#end_datepicker2').datepicker("option", "minDate", newDate);
      
    }
  });

  $("#end_datepicker2").datepicker({
      onSelect: function (date) {
          date2 = $('#end_datepicker2').datepicker('getDate');
          calcSum();
      }
  });


$('.begin_time').click(function() {
  $('.choose_time').toggle();
  $('.choose_time ul li').click(function() {
      var choose = $(this).text();
      time1 = $(this).text();
      calcSum();
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
      time2 = $(this).text();
      calcSum();
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

$('.choose_city>ul li').click(function () {
    calcSum();
});

function calcSum() {
    $('.show_avto').hide();
    var id = $('.avto').val();
    // Проверка на нулевой автомобиль
    if (id !== undefined && id != null && id != 9999) {
        $.ajax({
            type: "POST",
            url: "../EN/ShowCarInfo",
            data: id,
            contentType: "text/plain; charset=utf-8",
            datatype: "text",
            success:
                function (data) {
                    $('#result').html(data);
                    var price = $('#price').val();

                    if (chosen_city != undefined && chosen_city != null && date1 !== undefined && date2 !== undefined && date1 !== null && date2 !== null && time1 !== undefined && time1 !== undefined && time2 !== null && time2 !== null) {
                        var newDate = (((((date2 - date1) / 60) / 60) / 24) / 1000);
                        var tempArray = time1.split(':');

                        var startTime = tempArray[0];
                        tempArray = null;
                        tempArray = time2.split(':');
                        var endTime = tempArray[0];
                        if (endTime > startTime)
                        { newDate = newDate + 1; }
                        var avg;
                          
                        if (newDate >= 2 && newDate <= 5) {
                            avg = newDate * (Math.round(price * 0.88));
                        }
                        else if (newDate >= 6 && newDate < 30) {
                            avg = newDate * (Math.round(price * 0.73));
                        }
                        else if (newDate >= 30) {
                            avg = newDate * (Math.round(price * 0.52));
                        }
                        else {
                            avg = newDate * price;
                        }
                        var additional = "";
                        if (chosen_city == "Zaporizhia International Airport") {
                            var additional = 15;
                            $('#avg').html(avg + "$ + " + additional + "$ (Airport shipping charge)" );
                        }
                        else {
                            $('#avg').html(avg + "$");
                        }
                    } else {
                        $('#avg').html("");
                    }
                    $('.show_avto').show(100);

                }
        });
    }
}


$('.avto').on('change', function () {
    calcSum();
});

});