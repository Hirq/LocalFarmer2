function closeAlertAfterDelay() {
    setTimeout(function () {
        var alertElement = document.querySelector('.mud-alert');
        if (alertElement) {
            alertElement.style.display = 'none';
        }
    }, 2500);
}

function checkScrolls() {
    // Pobieramy wszystkie elementy z klas¹ noteText
    var elements = document.querySelectorAll('.noteText');

elements.forEach(function (element) {
        // Sprawdzamy, czy element ma aktywny scrollbar
        if (element.scrollHeight > element.clientHeight) {
    // Je¿eli jest aktywny scrollbar, ustaw margin-left na 10px
    element.style.marginLeft = '10px';
        } else {
    // Je¿eli nie ma scrollbara, ustaw margin-left na 0px
    element.style.marginLeft = '0px';
        }
    });
}

// Sprawdzamy na za³adowaniu oraz przy ka¿dej zmianie rozmiaru okna
window.onload = checkScrolls;
window.onresize = checkScrolls;
