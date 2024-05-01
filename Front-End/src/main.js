import { createApp } from 'vue'
import App from './App.vue'
import router from './route.js';
import '/public/styles/tailwind.css'
import NHLDivision from './components/nhl/NHLDivision.vue';
import NHLTeamPlayers from './components/nhl/NHLTeamPlayers.vue';

const app = createApp(App);
app.component('NHLDivision', NHLDivision);
app.component('NHLTeamPlayers', NHLTeamPlayers);
app.use(router);
app.mount('#app');
