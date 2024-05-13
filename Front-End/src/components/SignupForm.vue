<template>
  <section class="py-10 md:py-1">
    <div class="container mx-auto my-20 px-4">
      <form @submit.prevent="signup" class="border border-slate-700 p-6 rounded-lg w-3/5 mx-auto">
        <h6 class="font-small text-gray-400 text-3xl md:text-10xl mb-5">Full Name</h6>
        <div class="flex mb-4 border border-slate-500 p-6 rounded-lg mx-auto">
          <div class="flex flex-col w-1/2 mr-4">
            <input v-model="userSignup.FirstName" id="firstname" type="text" placeholder="Firstname" required class="w-50">
            <label for="firstname" class="text-gray-500 mb-2">First Name</label>
          </div>
          <div class="flex flex-col w-1/2 mr-4">
            <input v-model="userSignup.LastName" id="lastname" type="text" placeholder="Lastname" required class="w-50">
            <label for="lastname" class="text-gray-500 mb-2">Last Name</label>
          </div>
        </div>

        <h6 class="font-small text-gray-400 text-3xl md:text-10xl mb-5">Address</h6>
        <div class="border border-slate-500 p-6 rounded-lg mx-auto">
          <div class="flex flex-col mb-4">
            <input v-model="userSignup.StreetAddress1" id="address1" type="text" placeholder="Address 1" required class="w-50">
            <label for="address1" class="text-gray-500 mb-2">Street Address<span class="text-red-500">*</span></label>
          </div>
          <div class="flex flex-col mb-4">
            <input v-model="userSignup.StreetAddress2" id="address2" type="text" placeholder="Address 2" class="w-50">
            <label for="address2" class="text-gray-500 mb-2">Street Address Line 2</label>
          </div>
          
          <div class="flex mb-4">
            <div class="flex flex-col w-1/2 mr-4">
                <input v-model="userSignup.City" id="city" type="text" placeholder="City" required>
                <label for="city" class="text-gray-500 mt-2">City <span class="text-red-500">*</span></label>
            </div>
            <div class="flex flex-col w-1/2">
                <input v-model="userSignup.State_Prov" id="state_prov" type="text" placeholder="State / Province" required>
                <label for="state_prov" class="text-gray-500 mt-2">StateProvince</label>
            </div>
          </div>

          <div class="flex mb-4">
            <div class="flex flex-col w-1/2 mr-4">
              <input v-model="userSignup.Zip_Post_Cd" id="postal_zip" type="text" placeholder="PostalCd_Zip" required>
              <label for="postal_zip" class="text-gray-500 mb-2">Zip / Postal Code<span class="text-red-500">*</span></label>
            </div>
            <div class="flex flex-col w-1/2 mr-4">
              <input v-model="userSignup.Country" id="country" type="text" placeholder="Country" required>
              <label for="country" class="text-gray-500 mb-2">Country<span class="text-red-500">*</span></label>
            </div>
          </div>
        </div>
        <div class="border border-slate-500 p-6 rounded-lg mx-auto my-5">
          <div class="flex flex-col mb-4 my-5">
            <input v-model="userSignup.Email" id="email" type="text" placeholder="example@provider.com" required>
            <label for="email" class="text-gray-500 mb-2">Email<span class="text-red-500">*</span></label>
          </div>

            <div class="flex flex-col relative sadfmb-2">
              <input v-model="userSignup.Password" id="password" :type="showPassword ? 'text' : 'password'" placeholder="Password" required>
              <button type="button" class="absolute inset-y--10 right-0 flex items-center px-3 py-1 text-slate-700" @click="togglePasswordVisibility">
                <font-awesome-icon :icon="showPassword ? 'fa-eye-slash' : 'eye'" />
              </button>
              <label for="password" class="text-gray-500">Password<span class="text-red-500">*</span></label>
              
            </div>

        </div>
        <div class="flex justify-between">
          <button  type="submit" class="px-7 py-3 md:px-9 md:py-4 font-medium md:font-semibold bg-gray-700 text-gray-50 text-sm rounded-md hover:bg-gray-50 hover:text-gray-700 transition ease-linear duration-500">Register</button>
          <router-link :to="'/'" class="px-7 py-3 md:px-9 md:py-4 font-medium md:font-semibold bg-gray-700 text-gray-50 text-sm rounded-md hover:bg-gray-50 hover:text-gray-700 transition ease-linear duration-500">Cancel</router-link>
        </div>
      </form>
    </div>
  </section>
</template>

<script>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { library } from '@fortawesome/fontawesome-svg-core';
import { faEyeSlash, faEye } from '@fortawesome/free-solid-svg-icons';
import axios from 'axios'; // Import Axios

library.add(faEyeSlash);
library.add(faEye);

export default {
  components: {
    FontAwesomeIcon
  },
  data() {
    return {
      showPassword: false,
    
      userSignup: {
        FirstName: '',
        LastName: '',
        StreetAddress1: '',
        StreetAddress2: '',
        City: '',
        State_Prov: '',
        Zip_Post_Cd: '',
        Country: '',
        Email: '',
        Password: ''
      }
    }
  },
  methods: {
    togglePasswordVisibility() {
      console.log('togglePasswordVisibility called');
      this.showPassword = !this.showPassword;
    },
    async signup() {
      try {
        const userData = {
          FirstName: this.userSignup.FirstName,
          LastName: this.userSignup.LastName,
          StreetAddress1: this.userSignup.StreetAddress1,
          StreetAddress2: this.userSignup.StreetAddress2,
          City: this.userSignup.City,
          State_Prov: this.userSignup.State_Prov,
          Zip_Post_Cd: this.userSignup.Zip_Post_Cd,
          Country: this.userSignup.Country,
          Email: this.userSignup.Email,
          Password: this.userSignup.Password
        };

        console.log("userData data:", userData); // Log userSignup data
        console.log("Sending signup request...");
        const endpoint = 'https://localhost:7102/Signup'; // Adjust the URL as per your backend setup
        const response = await axios.post(endpoint, userData);

        console.log("Signup response:", response.data); // Log signup response
        this.$router.push({ name: 'loginPage' }); // Redirect to the login page upon successful signup
      } catch (error) {
        console.error('Error:', error);
        // Handle signup failure
      }
    }
  }
};
</script>