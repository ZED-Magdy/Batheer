
//var mapValues = {
//    LatLng: { lat: 28.22, lng: 36.54 },
//    Zoom: 8,
//    marker: {
//        draggable: true,
//    }
//};


var marker = undefined;
var map = undefined;

function initMap() {


    map = new google.maps.Map(document.getElementById("map"), {
        zoom: mapValues.zoom,
        center: new google.maps.LatLng(mapValues.latLng.lat, mapValues.latLng.lng),
    });

    google.maps.event.addListener(map, 'click', function (event) {
        //alert('Lat : ' + event.latLng.lat() + ' Lng : ' + event.latLng.lng())
    });

    marker = new google.maps.Marker({
        position: new google.maps.LatLng(mapValues.latLng.lat, mapValues.latLng.lng),
        draggable: mapValues.marker.draggable,
        map,
        title: "Hello World!",
    });

    google.maps.event.addListener(marker, 'dragend', function () {
        //console.log("lat: " + marker.position.lat())
        //console.log("lng: " + marker.position.lng())

        //mapValues.latLng.lat = marker.position.lat();
        //mapValues.latLng.lng = marker.position.lng();

        updateDto();
    });

    google.maps.event.addListener(map, 'zoom_changed', function () {
        // console.log("getZoom: " + map.getZoom());
        updateDto();
    });
}

//window.initMap = initMap;


function getLocation() {
    
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        alert("Geolocation is not supported by this browser.");
    }
}

function showPosition(position) {
    var lat = position.coords.latitude;
    var lng = position.coords.longitude;
    var position = new google.maps.LatLng(lat, lng);

    marker.setPosition(position);
    map.setCenter(position);
    map.setZoom(21);

    updateDto();
}


function updateDto() {
    mapValues.zoom = map.getZoom();
    mapValues.latLng = marker.position.toJSON();
}

