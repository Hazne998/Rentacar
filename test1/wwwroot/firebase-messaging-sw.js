// Import and configure the Firebase SDK
// These scripts are made available when the app is served or deployed on Firebase Hosting
// If you do not serve/host your project using Firebase Hosting see https://firebase.google.com/docs/web/setup
importScripts('https://www.gstatic.com/firebasejs/8.2.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/8.2.1/firebase-messaging.js');





console.log('===========================================');
console.log('FIREBASE SERVICE WORKER CARREGADO'); // debug info
console.log('===========================================');

firebase.initializeApp({
    apiKey: "AIzaSyBkM2BcsgFUcfB5ovdGlJX-pb-pYox7WzY",
    authDomain: "push-notification-8c16a.firebaseapp.com",
    projectId: "push-notification-8c16a",
    storageBucket: "push-notification-8c16a.appspot.com",
    messagingSenderId: "782523097859",
    appId: "1:782523097859:web:f408b85ed139a8de1c3f36",
    measurementId: "G-M8JPL33C73"
});

class CustomPushEvent extends Event {
    constructor(data) {
        super('push')

        Object.assign(this, data)
        this.custom = true
    }
}

/*
 * Overrides push notification data, to avoid having 'notification' key and firebase blocking
 * the message handler from being called
 */
self.addEventListener('push', (e) => {
    // Skip if event is our own custom event
    if (e.custom) return;

    // Kep old event data to override
    let oldData = e.data

    // Create a new event to dispatch, pull values from notification key and put it in data key, 
    // and then remove notification key
    let newEvent = new CustomPushEvent({
        data: {
            ehheh: oldData.json(),
            json() {
                let newData = oldData.json()
                newData.data = {
                    ...newData.data,
                    ...newData.notification
                }
                delete newData.notification
                return newData
            },
        },
        waitUntil: e.waitUntil.bind(e),
    })

    // Stop event propagation
    e.stopImmediatePropagation()

    // Dispatch the new wrapped event
    dispatchEvent(newEvent)
})
const messaging = firebase.messaging();
messaging.onBackgroundMessage(function (payload) {
    const notificationTitle = payload.data.title;
    const notificationOptions = {
        body: payload.data.body,
        icon: payload.data.icon
    };

    return self.registration.showNotification(notificationTitle,
        notificationOptions);
});

self.addEventListener('notificationclick', function (event) {
    self.clients.openWindow('https://github.com/Suketu-Patel')
    //close notification after click
    event.notification.close()
})