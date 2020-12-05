var centerMap = SMap.Coords.fromWGS84(17.6620104, 49.2245013);
var mapa = new SMap(JAK.gel("map"), centerMap, 14);
mapa.addDefaultLayer(SMap.DEF_BASE).enable();
mapa.addDefaultControls();

var layer = new SMap.Layer.Marker();
// var poiList = hardcodedPoiList();
var markers = [];

poiList.forEach(function (poi) {
    var card = getCard(poi);
    var marker = getMarker(poi);
    var coords = getCoordinates(poi);
    var poiMarker = new SMap.Marker(coords, null, {url:marker});
    poiMarker.decorate(SMap.Marker.Feature.Card, card);
    markers.push(poiMarker);
});

layer.addMarker(markers);
mapa.addLayer(layer).enable();

function getMarker(poi) {
    var types = poi.acceptingTypeOfWaste;
    var type = types.length == 1 ? types[0] : 'group';
    var marker = JAK.mel("div");
    var pinImage = JAK.mel("img", {src: "/img/marker-" + type + ".svg"});
    marker.appendChild(pinImage);
    return marker;
}


function getCoordinates(poi) {
    var poiLocation = poi.latLng;
    var x = poiLocation.lng;
    var y = poiLocation.lat;
    return SMap.Coords.fromWGS84(x, y);
}

function getCard(poi) {
    var card = new SMap.Card(200);
    card.getHeader().className = "";
    card.getBody().className = "";
    card.getFooter().className = "";
    card.getHeader().innerHTML = "<strong style=\"font-size:0.8rem\">" + poi.name + "</strong>";
    card.getBody().innerHTML = "<em style=\"font-size:0.8rem\">" + poi.latLng + "</em>";
    return card;
}
