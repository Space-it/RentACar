$(document).ready(function () {



    $('.navigation>ul li a').each(function () {
        var location = window.location.href;
        var link = this.href;
        if (location == link) {
            $(this).addClass('current-item');
        }
    });

    $('.toggle_nav').click(function (e) {
        $(this).toggleClass('active');
        $('.navigation ul').toggleClass('active');

        e.preventDefault();
    });

    $('.arrow').click(function (e) {
        $('.dropdown ul').toggle();
    });



    $('.city').click(function () {
        $('.choose_city').toggle();
        $('.choose_city ul li').click(function () {
            chosen_city = $(this).text();
            $('.city').val(chosen_city);
            $('.choose_city').hide();
        });
    });

    $(function () {
        $(document).click(function (event) {
            if ($(event.target).closest(".city").length) return;
            $(".choose_city").hide();
            event.stopPropagation();
        });
    });

    (function (factory) {
        if (typeof define === "function" && define.amd) {

            // AMD. Register as an anonymous module.
            define(["../widgets/datepicker"], factory);
        } else {

            // Browser globals
            factory(jQuery.datepicker);
        }
    }(function (datepicker) {

        datepicker.regional.ru = {
            closeText: "Закрыть",
            prevText: "&#x3C;Пред",
            nextText: "След&#x3E;",
            currentText: "Сегодня",
            monthNames: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
            monthNamesShort: ["Янв", "Фев", "Мар", "Апр", "Май", "Июн",
            "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек"],
            dayNames: ["воскресенье", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота"],
            dayNamesShort: ["вск", "пнд", "втр", "срд", "чтв", "птн", "сбт"],
            dayNamesMin: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"],
            weekHeader: "Нед",
            dateFormat: "dd.mm.yy",
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ""
        };
        datepicker.setDefaults(datepicker.regional.ru);

        return datepicker.regional.ru;

    }));

    $("#end_datepicker2").datepicker({
        dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            date2 = $('#end_datepicker2').datepicker('getDate');
            calcSum();
        }



    });





    $("#begin_datepicker").datepicker({
        dateFormat: "dd/mm/yy",
        minDate: 0,
        hideIfNoPrevNext: true,
        onSelect: function (date) {
            date1 = $('#begin_datepicker').datepicker('getDate');
            calcSum();
            var date = new Date(Date.parse(date1));
            var newDate = date.toDateString();
            newDate = new Date(Date.parse(newDate));
            $('#end_datepicker2').datepicker("option", "minDate", newDate);
            calcSum();
        }
    });

    $('.begin_time').click(function () {
        $('.choose_time').toggle();
        $('.choose_time ul li').click(function () {
            var choose = $(this).text();
            time1 = $(this).text();
            calcSum();
            $('.begin_time').val(choose);
            $('.choose_time').hide();
        });
    });

    $(function () {
        $(document).click(function (event) {
            if ($(event.target).closest(".begin_time").length) return;
            $(".choose_time").hide();
            event.stopPropagation();
        });
    });

    $('.end_time').click(function () {
        $('.choose_time2').toggle();
        $('.choose_time2 ul li').click(function () {
            var choose = $(this).text();
            time2 = $(this).text();
            calcSum();
            $('.end_time').val(choose);
            $('.choose_time2').hide();
        });
    });

    $(function () {
        $(document).click(function (event) {
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
                url: "../Home/ShowCarInfo",
                data: id,
                contentType: "text/plain; charset=utf-8",
                datatype: "text",
                success:
                    function (data) {
                        $('#result').html(data);
                        var price = $('#price').val();
                        if (chosen_city!=undefined && chosen_city!=null&& date1 !== undefined && date2 !== undefined && date1 !== null && date2 !== null && time1 !== undefined && time1 !== undefined && time2 !== null && time2 !== null) {
                            var newDate = (((((date2 - date1) / 60) / 60) / 24) / 1000);
                            var tempArray = time1.split(':');
                            var startTime = tempArray[0];
                            tempArray = null;
                            tempArray = time2.split(':');
                            var endTime = tempArray[0];
                            if (endTime > startTime) {
                                newDate = newDate + 1;
                            }
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
                            var additional ="";
                            if (chosen_city == "Аэропорт Запорожья") {
                                var additional = 15;
                                $('#avg').html(avg +"$ + "+ additional + "$ (оплата за доставку авто в Аэропорт)");
                            }
                            else
                            {
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


