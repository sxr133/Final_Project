import { createRouter, createWebHistory } from 'vue-router';
import NHLTeamPlayers from './components/nhl/NHLTeamPlayers.vue';
import HomePage from './components/HomePage.vue';

// Define routes
const routes = [
  {
    path: '/',
    name: 'division',
    component: HomePage,
    props: true // This ensures that route params are passed as props to the component
  
  },
  {
    path: '/team-roster/:teamId',
    name: 'team-roster',
    component: NHLTeamPlayers,
    props: true // This allows the route parameter to be passed as a prop to the component
  },
];

// Create router instance
const router = createRouter({
  history: createWebHistory(),  // Using HTML5 history mode
  routes,
});

export default router;