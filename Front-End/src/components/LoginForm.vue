<template>
  <section class="py-10 md:py-1">
    <div class="container max-w-screen-xl mx-auto px-4">
      <h1 class="font-medium text-gray-400 text-3xl md:text-10xl mb-5">Login to Sports Stats</h1>
      
        <div class="bg-gray-50 px-8 py-10 rounded-md">
          <form @submit.prevent="login">
            <div class="mb-4">
              <label for="username" class="block mb-2 text-2xl font-medium text-black-900 dark:text-black">Username</label>
              <input v-model="username" type="text" id="username" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Username" required />
            </div>
            <div class="mb-4">
                <label for="password" class="block mb-2 text-2xl font-medium text-black-900 dark:text-black">Password</label>
                <input v-model="password" type="password" id="password" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Password" required />
            </div>
            <div  class="flex justify-between">
              <button type="submit" class="px-7 py-3 md:px-9 md:py-4 font-medium md:font-semibold bg-gray-700 text-gray-50 text-sm rounded-md hover:bg-gray-50 hover:text-gray-700 transition ease-linear duration-500">Login</button>
              <button @click="redirectToRegister" class="px-7 py-3 md:px-9 md:py-4 font-medium md:font-semibold bg-gray-700 text-gray-50 text-sm rounded-md hover:bg-gray-50 hover:text-gray-700 transition ease-linear duration-500">Register</button>
            </div>
          </form>
        </div>

    </div>
  </section>
</template>

<script>
import { ref} from 'vue';

export default {
  // Define the loginSuccess event

  setup(_, { emit }) { // Destructure emit from context
    const username = ref('');
    const password = ref('');

    const login = () => {
      // Perform login logic here
      console.log('Logging in...');
      // Emit the loginSuccess event upon successful login
      emit('loginSuccess');
    };

    const redirectToRegister = () => {
      // Redirect to the registration page
      console.log('Redirecting to registration...');
    };

    return { username, password, login, redirectToRegister };
  },
};
</script>
