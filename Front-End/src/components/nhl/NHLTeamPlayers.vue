<template>
 <div class="flex justify-center bg-zinc-300 h-fit">
    <div v-if="teamPlayers.length > 0" class="overflow-x-auto shadow-md sm:rounded-lg">
      <!-- Search input -->
      <input type="text" v-model="searchQuery" placeholder="Search..." class="text-gray-400 uppercase dark:bg-gray-800 my-5 px-4 py-2 border border-gray-300 rounded-md focus:outline-none focus:border-blue-500 placeholder-opacity-100">

      <div>
        <button class="back-button" @click="goToDivisionPage">Go to Division Page</button>
      </div>

      <table class="mt-4 border-collapse border border-gray-500 w-full md:max-w-screen-xl">
          <colgroup>
            <col style="width: 15%;">
            <col style="width: 30%;">
            <col style="width: 15%;">
            <col style="width: 5%;">
            <col style="width: 5%;">
            <col style="width: 15%;">
          </colgroup>
          <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-100">
            <tr>
              <th colspan="8" class="text-center py-4 text-xl font-semibold border border-gray-300 rounded-md">{{ teamName }}</th>
            </tr> 
            <tr>
              <th scope="col" class="px-6 py-3">
                <span @click="sortByColumn('position')" class="cursor-pointer">
                  Position
                  <span v-if="sortBy === 'position' || sortBy === null" class="ml-1">
                    <span v-if="sortDirection === 'asc'">▲</span>
                    <span v-else-if="sortDirection === 'desc'">▼</span>
                  </span> 
                </span>   
              </th>
              <th scope="col" class="px-6 py-3">
                <span @click="sortByColumn('name')" class="cursor-pointer">
                  Name
                  <span v-if="sortBy === 'name' || sortBy === null" class="ml-1">
                    <span v-if="sortDirection === 'asc'">▲</span>
                    <span v-else-if="sortDirection === 'desc'">▼</span>
                  </span>                
                </span>
              </th>
              <th scope="col" class="px-6 py-3">Weight</th>
              <th scope="col" class="px-6 py-3">Height</th>
              <th scope="col" class="px-6 py-3">Age</th>
              <th scope="col" class="px-6 py-3">Date of Birth</th>
              <th scope="col" class="px-6 py-3">Debut Year</th>
              <th scope="col" class="px-6 py-3">Player OverAll Stats</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(player, index) in filteredPlayers" :key="index" 
              :class="{ 'bg-white dark:bg-gray-900': index % 2 === 0, 'bg-gray-50 dark:bg-gray-800': index % 2 !== 0 }"
              class="border-b dark:border-gray-700 px-6 py-4 text-gray-400">
              <td class="px-6 py-4 text-gray-400 text-center">{{ player.position }}</td>
              <td class="flex flex-col items-center justify-center px-6 py-4 text-gray-400">
                <img class="block w-16 h-16 mb-2" :src="player.headshot" :alt="player.fullName + ' headshot'">
                <span class="block text-center">{{ player.fullName }}</span>
              </td>
              <td class="px-6 py-4 text-gray-400 text-center">{{ player.displayWeight }}</td>
              <td class="px-6 py-4 text-gray-400 text-center">{{ player.displayHeight }}</td>
              <td class="px-6 py-4 text-gray-400 text-center">{{ player.age }}</td>
              <td class="px-6 py-4 text-gray-400 text-center">{{ formatDate(player.dateOfBirth) }}</td>
              <td class="px-6 py-4 text-gray-400 text-center">{{ player.debutYear }}</td>
              <td class="px-6 py-4 text-gray-400 text-center">{{ player.debutYear }}</td>
            
            </tr>  
                     

          </tbody>
        </table>
      </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
  props: {
    teamId: {
      type: Number,
      required: true,
    }

  },

  data() {
    return {
      selectedDivision: '',
      sortBy: null, // Initialize sortBy to null',
      sortDirection: 'asc',
      teamPlayers: [],
      searchQuery: '', // Add searchQuery property
      showDetails: "false",
      hoveredRowIndex: null, // Track the index of the currently hovered row
      selectedPlayer: null, // Track the player corresponding to the hovered row
      showInfoBox: false, // Control visibility of InfoBox
    };
  },
  mounted() 
  {
    console.log('NHLTeamPlayers component mounted');
    const { teamId } = this;
    
     // Example: Fetch data using teamId and division
     this.fetchTeamPlayers(teamId);
    // Now you can use teamId and division directly in this component
  },
  computed: {
    filteredPlayers() {
      if (!this.teamPlayers) return [];
        return this.teamPlayers.filter(player => {
        // Check if player's properties are defined and contain the search query
          return (
            (player.position && player.position.toLowerCase().includes(this.searchQuery.toLowerCase())) ||
            (player.fullName && player.fullName.toLowerCase().includes(this.searchQuery.toLowerCase())) ||
            // Add more conditions for other properties as needed
            false
          );
        });
    },
  },
  methods: {
    goToDivisionPage() {
      console.log("Going to Division Page");
      this.$emit('goToDivisionPage');
    },
    formatDate(dateString) {
      // Parse the date string
      const date = new Date(dateString);
  
      // Extract year, month, and day
      const year = date.getFullYear();
      let month = (date.getMonth() + 1).toString().padStart(2, '0'); // Months are 0-indexed
      let day = date.getDate().toString().padStart(2, '0');
  
      // Format the date as yyyy-mm-dd
      return `${year}-${month}-${day}`;
    },
    sortByColumn(column) {
      this.sortBy = column;
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc'; // Toggle sorting direction

      // Sort the teamPlayers array based on the selected column and sorting direction
      this.teamPlayers.sort((a, b) => {
        if (this.sortDirection === 'asc') {
          return a[column].localeCompare(b[column]);
        } else {
          return b[column].localeCompare(a[column]);
        }
      });
    },
    async fetchTeamPlayers(teamId) {
      console.log("Fetching team players...");
      if (!teamId) {
        return;
      }
      const endpoint = `https://localhost:7102/api/NHLTeamPlayers`;
        try {
          const response = await axios.get(endpoint, {
            headers: {
              teamId: teamId // Sending the selected conference as a header
            }
          });

      this.teamName = response.data.team.displayName;
      
      this.teamPlayers = response.data.team.athletes.map(athlete => ({
        headshot: athlete.headshot && athlete.headshot.href ? athlete.headshot.href : '/images/no-img.png',
        headshot_alt: athlete.headshot && athlete.headshot.alt ? athlete.headshot.alt : 'No Image Available',
        position: athlete.position ? athlete.position.name : 'Unknown Position',
        fullName: athlete.fullName,
        displayName: athlete.displayName,
        displayWeight: athlete.displayWeight,
        displayHeight: athlete.displayHeight,
        age: athlete.age,
        dateOfBirth: athlete.dateOfBirth,
        debutYear: athlete.debutYear
      }));
      console.log("Team players:", this.teamPlayers); // Log the teamPlayers array
      } catch (error) {
        console.error('Failed to fetch team players:', error);
      }
    },
 
  },

 
}
</script>

<style>
  .back-button {
    display: inline-block;
    margin-top: 20px;
    padding: 10px 20px;
    background-color: #ccc;
    color: #000;
    text-decoration: none;
    border-radius: 5px;
    cursor: pointer;
  }
 
</style>