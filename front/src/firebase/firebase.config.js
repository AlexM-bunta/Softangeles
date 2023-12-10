import {initializeApp} from 'firebase/app'
import 'firebase/auth';
import 'firebase/firestore';
import {getFirestore} from "../../.vite/deps/firebase_firestore.js";

const firebaseConfig = {
    apiKey: "AIzaSyD8K_1d3OUpoZ_WtAv_AbZOLQxE89nvX98",
    authDomain: "hackathon-c5856.firebaseapp.com",
    projectId: "hackathon-c5856",
    storageBucket: "hackathon-c5856.appspot.com",
    messagingSenderId: "513198281561",
    appId: "1:513198281561:web:8474863a16a4b6d1073248"
};

export const app = initializeApp(firebaseConfig);
export const db = getFirestore(app)