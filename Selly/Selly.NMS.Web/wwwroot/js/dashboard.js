enableNotifications();

var hubConnection = new signalR.HubConnectionBuilder().withUrl("/homeHub").build();
hubConnection.on("messageReceived", (message) => {
    var notification = new Notification(message);
});

hubConnection.start().catch(err => console.error(err.toString()));

function enableNotifications() {
    // Let's check if the browser supports notifications
    if (!("Notification" in window)) {
        alert("This browser does not support desktop notification");
    }

    // Otherwise, we need to ask the user for permission
    else if (Notification.permission !== "denied") {
        Notification.requestPermission(function (permission) {
            // If the user accepts, let's create a notification
            document.getElementById("notifDiv").innerHTML = "Notifications enabled";
        });
    }
}