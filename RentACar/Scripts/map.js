$(document).ready(function () {
    var map;
    var center;
    var marker = new google.maps.Marker;
    var animation = google.maps.Animation;
    var info_window = new google.maps.InfoWindow;
    var gp = new google.maps.LatLng(44.058431, -79.423335);

    var content = '<h2 class="map">Geek Power Web Design</h2>' +
					'<p>' +
						'1228 Gorham Street' +
						'<br />' +
						'Unit #25' +
						'<br />' +
						'Newmarket, ON L3Y 8Z1' +
					'</p>';

    var map_options =
	{
	    zoom: 13,
	    mapTypeId: google.maps.MapTypeId.ROADMAP,
	    center: gp,
	    scrollwheel: false
	}

    map = new google.maps.Map(document.getElementById('map-canvas'), map_options);

    marker.setPosition(gp);
    marker.setAnimation(animation.DROP);
    marker.setMap(map);

    info_window.setContent(content);
    info_window.open(map, marker);

    function calculate_center() {
        center = map.getCenter();
    }

    google.maps.event.addDomListener(map, 'idle', function () {
        calculate_center();
    });

    google.maps.event.addDomListener(window, 'resize', function () {
        map.setCenter(center);
    });
});