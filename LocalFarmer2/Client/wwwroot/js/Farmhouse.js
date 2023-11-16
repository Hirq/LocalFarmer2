function closeAlertAfterDelay() {
    setTimeout(function () {
        var alertElement = document.querySelector('.mud-alert');
        if (alertElement) {
            alertElement.style.display = 'none';
        }
    }, 2500);
}