export function downloadFile(mimeType, base64String, fileName) {
    var fileDataUrl = "data:" + mimeType + ";base64," + base64String;
    fetch(fileDataUrl)
        .then(response => response.blob())
        .then(blob => {

            var link = window.document.createElement("a");
            link.href = window.URL.createObjectURL(blob, { type: mimeType });
            link.download = fileName;

            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        });

}

export function setScroll() {
    var divMessageContainer = document.getElementById('mud-paper-chat-message');
    if (divMessageContainer != null) {
        divMessageContainer.scrollTop = divMessageContainer.scrollHeight;
    }
}

export function scrollOnBottomMessages() {
    var container = document.getElementById("mud-paper-chat-message");
    if (container) {
        container.scrollTop = container.scrollHeight;
    }

    var inputMessage = document.getElementById("txtMessageInput");
    inputMessage.focus();
}

document.getElementById("txtMessageInput")
    .addEventListener("keyup", function(event) {
        event.preventDefault();
        if (event.keyCode === 13) {
            document.getElementById("txtMessageButton").click();
        }
    });
