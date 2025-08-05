// A jak wchodze w ogolny to pyta o lokalizacje i pokazuje dookola, jak nie udostępni to na Warszawe i elo
var zoom = 8;
export function load_map(raw, latitude, longitude) {
    console.log(JSON.parse(String(raw)));
    let map = L.map('map').setView({ lat: latitude, lon: longitude }, zoom);
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

export function setCoordinates(mapId, latitude, longitude) {
    var currentMarker;
    var defaultLatitude = 54.189;
    var defaultLongitude = 16.18;
    let culture = window.getCurrentCulture();

    latitude = latitude || defaultLatitude;
    longitude = longitude || defaultLongitude;

    var mapContainer = document.getElementById(mapId);
    if (mapContainer) {
        var map = L.map(mapId).setView([latitude, longitude], zoom);

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);

        if (latitude !== defaultLatitude || longitude !== defaultLongitude) {
            currentMarker = L.marker([latitude, longitude]).addTo(map);

            if (culture === 'pl-PL') {
                currentMarker.bindPopup("Początkowy marker przy " + [latitude, longitude]).openPopup();
            } else {
                currentMarker.bindPopup("Initial marker at " + [latitude, longitude]).openPopup();
            }
        }

        map.on('click', onMapClick);

        function onMapClick(e) {
            document.getElementById("latitude_input").value = e.latlng.lat;
            document.getElementById("longitude_input").value = e.latlng.lng;

            if (currentMarker) {
                currentMarker.remove();
            }

            currentMarker = L.marker(e.latlng).addTo(map);

            if (culture === 'pl-PL') {
                currentMarker.bindPopup("Nacisnąłeś na mapę w miejscu " + e.latlng).openPopup();
            } else {
                currentMarker.bindPopup("You clicked the map at " + e.latlng).openPopup();
            }
        }
    }
};

export function getValueById(elementId) {
    var element = document.getElementById(elementId);
    return element ? element.value : null;
};

export function removeMap(mapId) {
    var mapContainer = document.getElementById(mapId);
    if (mapContainer) {
        mapContainer._leaflet_id = null;
        mapContainer.innerHTML = '';
    }
}

export function setDisplayMap(mapId, display) {
    var mapContainer = document.getElementById(mapId);
    if (mapContainer) {
        mapContainer.style.display = display;
    }
}

export function disableButton(buttonId, bool) {
    var buttonElement = document.getElementById(buttonId);
    if (buttonElement) {
        buttonElement.disabled = bool;
    }
}

window.getCurrentCulture = () => {
    return localStorage.getItem('BlazorCulture') || 'en-US';
};