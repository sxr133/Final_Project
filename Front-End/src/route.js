import { createRouter, createWebHistory } from 'vue-router';
import NHLTeamPlayers from './components/nhl/NHLTeamPlayers.vue';
import SignupForm from './components/SignupForm.vue';
import LoginForm from './components/LoginForm.vue';
import HomePage from './components/HomePage.vue';




// Define routes
const routes = [
  {
    path: '/',
    name: 'LoginForm',
    component: LoginForm,
    props: true // This ensures that route params are passed as props to the component
  },
  {
    path: '/division',
    name: 'division',
    component: HomePage,
    props: true
  },
  {
    path: '/home',
    name: 'homePage',
    component: HomePage,
    props: true // This ensures that route params are passed as props to the component
  },
  {
    path: '/team-roster/:teamId',
    name: 'team-roster',
    component: NHLTeamPlayers,
    props: route => ({ teamId: parseInt(route.params.teamId) }),
    beforeEnter: (to, from, next) => {
      console.log('Navigating to team-roster route');
      next(); 
    }
  },
  {
    path: '/signup',
    name: 'SignupForm',
    component: SignupForm,
    props: false
  }
];

// Create router instance
const router = createRouter({
  history: createWebHistory(),  // Using HTML5 history mode
  routes,
});

export default router;