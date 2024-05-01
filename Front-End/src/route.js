import { createRouter, createWebHistory } from 'vue-router';
import NHLTeamPlayers from './components/nhl/NHLTeamPlayers.vue';
import NHLDivision from './components/nhl/NHLDivision.vue';

// Define routes
const routes = [
  {
    path: '/',
    redirect: '/nhl-teams' // Assuming this is your main route
  },
  {
    path: '/nhl-teams',
    name: 'NHLDivision',
    component: NHLDivision
  },
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