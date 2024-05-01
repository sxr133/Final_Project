<template>
  <div class="bg-zinc-300 h-screen">
    <template v-if="loggedIn">
      <!-- Display the HomePage if logged in -->
      <home-page />
    </template>
    <template v-else>
      <!-- Display the LoginForm if not logged in -->
      <login-form @loginSuccess="loggedIn = true" />
    </template>
  </div>
</template>

<script>
import LoginForm from './components/LoginForm.vue';
import HomePage from './components/HomePage.vue';
import { ref } from 'vue';

export default {
  components: {
    LoginForm,
    HomePage,
  },
  setup() {
    // Reactive variable to track login status
    const loggedIn = ref(false);

    return { loggedIn };
  }
};
</script>
