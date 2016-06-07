var map;
var poly;
var infoWindow = null;
var GatesArray = [];
var jsonpath = [];
var newPath = false;

// Initialize the app
function initialize() {
    var mapOptions = {
        zoom: 3,
        center: new google.maps.LatLng(6.0, 0.0),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    var polyOptions = {
        strokeColor: '#000000',
        strokeOpacity: 1.0,
        strokeWeight: 2
    };
    poly = new google.maps.Polyline(polyOptions);
    poly.setMap(map);

    google.maps.event.addListener(map, 'click', function(event) {
        if (newPath == true) {
            placeMarker(event.latLng);
        }
    });
}


// Add the gates from BGL
function addGate(latitude, longitude, name) {
    var myLatlng = new google.maps.LatLng(latitude, longitude);
    var image = 'images/airport_1.png';
    var gate = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: name,
        icon: image,
        labelContent: name
    });



    google.maps.event.addListener(gate, 'dblclick', function() {
        newPath = true;
        var pbPath = poly.getPath();
        pbPath.push(myLatlng);
        jsonpath.Position.push({
            latitude: myLatlng.latitude(),
            longitude: myLatlng.longitude(),
            seq: WaypointCounter++
        });

        createJson();
        markerArray.push(gate);
    });

    google.maps.event.addListener(gate, 'click', function() {
        if (InfoWindow) {
            InfoWindow.close();
        }
        InfoWindow = new google.maps.InfoWindow({
            content: name
        });
        InfoWindow.open(map, gate);
        document.all.gatename.innerHTML = name;
        map.panTo(gate.getPosition());
        map.setZoom(18);
    });

    GatesArray.push(gate);
}



google.maps.event.addDomListener(window, 'load', initialize);