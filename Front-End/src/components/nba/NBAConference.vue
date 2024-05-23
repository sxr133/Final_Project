<template>
  <div>
    <!-- Conditional rendering of NHL table -->
    <div v-if="showNBATable" class="relative overflow-x-auto shadow-md sm:rounded-lg">
      <!-- Dropdown for selecting conference -->
      <div class="flex justify-center my-4">
        <select v-model="selectedConference" @change="fetchConferenceStandings" class="block w-1/2 p-2 text-gray-700 bg-white border border-gray-300 rounded-md focus:border-blue-500 focus:outline-none focus:ring">
          <option value="Select" disabled selected>Select a Conference</option>
          <option value="Western Conference">Western Conference</option>
          <option value="Eastern Conference">Eastern Conference</option>
        </select>
      </div>

      <h1>NBA Conference Table to display</h1>
      <table v-if="selectedConference != 'Select'" class="mt-4 border-collapse border border-gray-500">
        <!-- Table content -->
        <colgroup>
          <col style="width: 60%;">
          <col style="width: 10%;">
          <col style="width: 10%;">
          <col style="width: 10%;">
          <col style="width: 10%;">
        </colgroup>
        <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-100">
          <tr>
            <th scope="col" class="px-6 py-3">Team</th>
            <th scope="col" class="px-6 py-3">Wins</th>
            <th scope="col" class="px-6 py-3">Losses</th>
            <th scope="col" class="px-6 py-3">PCT</th>
            <th scope="col" class="px-6 py-3">Games Behind</th>
          </tr>
        </thead>

        <tbody>
          <!-- Render either Eastern or Western conference teams based on selection -->
          <tr v-for="(team, index) in selectedConference === 'Eastern Conference' ? eastConference : westConference" :key="index" class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 px-6 py-4 text-gray-400">
            <td class="flex flex-col items-center justify-center px-6 py-4 text-gray-400">
              <img class="block w-16 h-16 mb-2" :src="team.teamLogo" :alt="team.displayName + ' logo'">
              <span class="block text-center">{{ team.displayName }}</span>
            </td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.wins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.losses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ ((team.wins / (team.wins + team.losses)) * 100).toFixed(1) }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">
              {{
                index < eastConference.length ? 
                (selectedConference === 'Eastern Conference' ? 
                Math.max(0, team.wins - eastConference[0].wins) : 
                Math.max(0, team.wins - westConference[0].wins)
                ) : '-'
              }}
            </td> 
          </tr>
        </tbody>
      </table>        <!-- Table content -->
    </div>
  </div>
</template>

<script>
  import axios from 'axios';
  export default {
    props: {
      showNBATable: Boolean,
    },
    data(){
      return{
        selectedTeamId: '',
        selectedConference: 'Select', // Default selection
        eastConference: [],
        westConference: [],
        season: '2023',
        isLoading: false, // Added to track when the API call is happening
      };
    },
    methods: {
      async fetchConferenceStandings() {
        this.isLoading = true; // Set loading of API to true when the call starts
        const endpoint = `https://localhost:7102/api/NBAConference`;
        console.log("i get here inside the fetch");
        try {
    console.log("i get here inside the try");
    const response = await axios.get(endpoint);
    this.eastConference = []; // Clear previous data
    this.westConference = []; // Clear previous data

    // Check if response.data.response exists
    if (response.data && response.data.children) {
        const conference = response.data.children;

        // Function to extract team data
        const extractTeamData = (conference, conferenceName) => {
            return conference.flatMap(team => {
                return team.standings.entries.map(entry => ({
                    // Access the first logo URL if available, or handle multiple logos as needed
                    teamLogo: entry.team.logos.length > 0 ? entry.team.logos[0].href : '',
                    displayName: entry.team.displayName,
                    wins: entry.stats.find(stat => stat.name === 'wins')?.value || 0,
                    losses: entry.stats.find(stat => stat.name === 'losses')?.value || 0,
                    gamesBehind: entry.stats.find(stat => stat.name === 'gamesBehind')?.value || 0,
                    conference: conferenceName,
                }));
            });
        };

        // Extract east conference teams
        this.eastConference = extractTeamData(conference.filter(team => team.abbreviation === 'East'), 'eastConference');

        // Extract west conference teams
        this.westConference = extractTeamData(conference.filter(team => team.abbreviation === 'West'), 'westConference');

        // Sort eastConference array by wins
        this.eastConference.sort((a, b) => b.wins - a.wins);
        // Sort westConference array by wins
        this.westConference.sort((a, b) => b.wins - a.wins);
    }
} catch (error) {
    console.error('Error fetching NBA conference standings:', error);
} finally {
    this.isLoading = false; // Reset loading state whether the call succeeds or fails
}
      }
    },
  }
</script>