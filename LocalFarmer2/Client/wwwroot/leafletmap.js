//export function load_map(latitude, longitude) {
//    let map = L.map('map').setView([latitude, longitude], 12);
//    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
//}

//Plan - zrobiæ mapê dla wszystkich aktywnych gospodarstw + jak wchodze w szczeoly to widzê mape wszystkich ale jest wyœrodkowane na dane gosporastwo
// A jak wchodze w ogolny to pyta o lokalizacje i pokazuje dookola, jak nie udostêpni to na Warszawe i elo

export function load_map(raw) {
    console.log(JSON.parse(String(raw)));
    let map = L.map('map').setView({ lon: 16.177133, lat: 54.196165 }, 14);
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);
    var geojson_layer = L.geoJSON().addTo(map);
    var geojson_data = JSON.parse(String(raw));
    for (var geojson_item of geojson_data) {
        geojson_layer.addData(geojson_item);
        var marker = new L.marker(
            [geojson_item.geometry.coordinates[1],
            geojson_item.geometry.coordinates[0]],
            { opacity: 0.01 }
        );
        marker.bindTooltip(geojson_item.properties.name,
            {
                permanent: true,
                className: "my-label",
                offset: [0, 0]
            }
        );
        marker.addTo(map);
    }

    return "";
}