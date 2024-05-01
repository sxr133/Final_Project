<template>
  <div>
    <!-- Conditional rendering of NHL table -->
   
    <div v-if="showNHLTable" class="relative overflow-x-auto shadow-md sm:rounded-lg">
      <!-- Dropdown for selecting conference -->
      <div class="flex justify-center my-4">
        <select v-model="selectedConference" @change="fetchConferenceStandings" class="block w-1/2 p-2 text-gray-700 bg-white border border-gray-300 rounded-md focus:border-blue-500 focus:outline-none focus:ring">
          <option value="Select" disabled selected>Select a Conference</option>
          <option value="Western Conference">Western Conference</option>
          <option value="Eastern Conference">Eastern Conference</option>
        </select>
      </div>
      
      <table v-if="selectedConference != 'Select'" class="mt-4 border-collapse border border-gray-500">
            <!-- Table content -->
            <colgroup>
              <col style="width: 60%;">
              <col style="width: 8%;">
              <col style="width: 8%;">
              <col style="width: 8%;">
              <col style="width: 8%;">
              <col style="width: 8%;">
            </colgroup>
            <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-100">
              <tr>
                <th scope="col" class="px-6 py-3">Team</th>
                <th scope="col" class="px-6 py-3">Wins</th>
                <th scope="col" class="px-6 py-3">Losses</th>
                <th scope="col" class="px-6 py-3">OT Wins</th>
                <th scope="col" class="px-6 py-3">OT Losses</th>
                <th scope="col" class="px-6 py-3">Points</th>
              </tr>
            </thead>
        <tbody>


              <tr v-for="(team, index) in nhlTeams" :key="index" class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 px-6 py-4 text-gray-400">
                <td class="px-6 py-4 text-gray-400">{{ team.displayName }}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{team.wins}}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{team.losses}}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{team.overtimeWins}}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{team.overtimeLosses}}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{team.points}}</td>
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
      showNHLTable: Boolean,
    },
    data(){
      return{
        selectedTeamId: '',
        selectedConference: 'Select', // Default selection
        nhlTeams: [],
        isLoading: false, // Added to track when the API call is happening
      };
    },
    methods: {
      async fetchConferenceStandings() {
        this.isLoading = true; // Set loading of API to true when the call starts
        const endpoint = `https://localhost:7102/api/NHLStandings`;

        try {
          const response = await axios.get(endpoint, {
            headers: {
              conference: this.selectedConference // Sending the selected conference as a header
            }
          });
          
          this.nhlTeams = []; // Clear previous data
          
          // Check if response.data.standings and its 'entries' array exist
          if (response.data && response.data.standings && response.data.standings.entries) {
            const entries = response.data.standings.entries;

            // Loop through each entry to get team details
            entries.forEach(entry => {
              if (entry.team && entry.stats) {
                // const displayName = entry.team.displayName;
                // const displayName = entry.team.displayName;

                // console.log(displayName); // Debugging output
                // this.nhlTeams.push(displayName); // Push the displayName into nhlTeams array
                const teamData = {
                  displayName: entry.team.displayName
                };

                // Find the object that contains wins in the stats array
                const winsStat = entry.stats.find(stat => stat.name === 'wins');

                // Add wins to the teamData object, only if it's found
                if (winsStat) {
                  teamData.wins = winsStat.value;
                }

                // Find the object that contains losses in the stats array
                const lossesStat = entry.stats.find(stat => stat.name === 'losses');

                // Add wins to the teamData object, only if it's found
                if (lossesStat) {
                  teamData.losses = lossesStat.value;
                }

                // Find the object that contains overtime wins in the stats array
                const otWinsStat = entry.stats.find(stat => stat.name === 'overtimeWins');

                // Add wins to the teamData object, only if it's found
                if (otWinsStat) {
                  teamData.overtimeWins = otWinsStat.value;
                }

                // Find the object that contains overtime losses in the stats array
                const otLossesStat = entry.stats.find(stat => stat.name === 'overtimeLosses');

                // Add wins to the teamData object, only if it's found
                if (otLossesStat) {
                  teamData.overtimeLosses = otLossesStat.value;
                }

                // Find the object that contains points in the stats array
                const pointsStat = entry.stats.find(stat => stat.name === 'points');

                // Add wins to the teamData object, only if it's found
                if (pointsStat) {
                  teamData.points = pointsStat.value;
                }

                console.log(teamData); // Debugging output
                this.nhlTeams.push(teamData); // Push the teamData into nhlTeams array
              }
            });
          }
        } catch (error) {
          console.error('Error fetching NHL conference standings:', error);
        } finally {
            this.isLoading = false; // Reset loading state whether the call succeeds or fails
        }
      }
    },
  }
</script>