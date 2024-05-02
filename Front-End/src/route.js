import { createRouter, createWebHistory } from 'vue-router';
import NHLTeamPlayers from './components/nhl/NHLTeamPlayers.vue';

// Define routes
const routes = [
  {
    path: '/team-roster/:teamId',
    name: 'TeamRoster',
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