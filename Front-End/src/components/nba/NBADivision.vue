<template>
  <div>
    <div v-if="showDivisionOptionTable" class="relative overflow-x-auto shadow-md sm:rounded-lg">
      <!-- Dropdown for selecting conference -->
      <div class="flex justify-center my-4">
        <select v-model="selectedDivision" @change="fetchDivisionStandings" class="block w-1/2 p-2 text-gray-700 bg-white border border-gray-300 rounded-md focus:border-blue-500 focus:outline-none focus:ring">
          <option value="Select" disabled selected>Select a Division</option>
          <option value="Western Conference">Western Conference</option>
          <option value="Eastern Conference">Eastern Conference</option>
        </select>
      </div>
    </div>

    <!-- Render division tables dynamically -->
    <div v-if="selectedDivision" class="justify-center">
      <template v-if="divisions[selectedDivision]">
        <template v-for="(division, divisionName) in divisions[selectedDivision]" :key="divisionName">
          <table v-if="division.length > 0" class="mt-4 border-collapse border border-gray-500">
            
            <colgroup>
              <col style="width: 60%;">
              <col style="width: 5%;">
              <col style="width: 5%;">
              <col style="width: 5%;">
              <col style="width: 5%;">
              <col style="width: 5%;">
              <col style="width: 15%;">
            </colgroup>
            <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-100">
              <tr>
                <th colspan="7" class="text-center py-4 text-xl font-semibold">{{ divisionName }}</th>
              </tr>
              <tr>
                <th scope="col" class="px-6 py-3">Team</th>
                <th scope="col" class="px-6 py-3">Wins</th>
                <th scope="col" class="px-6 py-3">Losses</th>
                <th scope="col" class="px-6 py-3">OT Wins</th>
                <th scope="col" class="px-6 py-3">OT Losses</th>
                <th scope="col" class="px-6 py-3">Points</th>
                <th scope="col" class="px-6 py-3">Team</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(team, index) in division" :key="index" class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 px-6 py-4 text-gray-400">
                <td class="flex flex-col items-center justify-center px-6 py-4 text-gray-400">
                  <img class="block w-16 h-16 mb-2" :src="team.teamLogo" :alt="team.displayName + ' logo'">
                  <span class="block text-center">{{ team.displayName }}</span>
                </td>
                <td class="px-6 py-4 text-gray-400 text-center">{{ team.wins }}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{ team.losses }}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeWins }}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeLosses }}</td>
                <td class="px-6 py-4 text-gray-400 text-center">{{ team.points }}</td>
                <td class="px-6 py-4 text-gray-400 text-center"><router-link :to="'/team-roster/' + team.id" @click="$emit('teamSelected', { teamId: team.id })">View Team Roster</router-link></td>
              </tr>
            </tbody>
          </table>
        </template>
      </template>
      <template v-else>
        <div class="text-center py-4 text-gray-700">No data available for the selected division.</div>
      </template>
    </div>
  </div>
</template>



<script>
  import axios from 'axios';
  export default {
    props: {
      showDivisionOptionTable: Boolean,
    },
    data(){
      return{
        selectedDivision: 'Select', // Default selection
        divisions: {
          'Western Conference': {
            'Northwest Division': [],
            'Pacific Division': [],
            'Southwest Division': []
          },
          'Eastern Conference': {
            'Atlantic Division': [],
            'Central Division': [],
            'Southeast Division': []
          }
        }
      };
    },
    methods: {
      async fetchDivisionStandings() {
    this.isLoading = true; // Set loading of API to true when the call starts
    const endpoint = `https://localhost:7102/api/NBADivision`;
    console.log("i get here inside the fetch");
    try {
        console.log("i get here inside the try");
        const response = await axios.get(endpoint);

        // Check if response.data.response exists
        if (response.data && response.data.children) {
            const conferences = response.data.children;
            console.log("response.data contains ", response.data);

            // Initialize divisions object
            const divisions = {
                'Western Conference': {
                    'Northwest Division': [],
                    'Pacific Division': [],
                    'Southwest Division': []
                },
                'Eastern Conference': {
                    'Atlantic Division': [],
                    'Central Division': [],
                    'Southeast Division': []
                }
            };

            // Function to initialize divisions arrays
            const initializeDivisions = () => {
                for (const conference in divisions) {
                    for (const division in divisions[conference]) {
                        divisions[conference][division] = [];
                    }
                }
            };

            // Function to extract team data and populate divisions
            const populateDivisions = (conference, conferenceName) => {
              conference.forEach(division => {
                  const divisionName = division.name + ' Division';
                  // Ensure division.standings exists and has entries before mapping
                  if (division.standings && division.standings.entries) {
                      divisions[conferenceName][divisionName] = division.standings.entries.map(entry => ({
                         // Access the first logo URL if available, or handle multiple logos as needed
                          teamLogo: entry.team.logos.length > 0 ? entry.team.logos[0].href : '',
                          displayName: entry.team.displayName,
                          wins: entry.stats.find(stat => stat.name === 'wins')?.value || 0,
                          losses: entry.stats.find(stat => stat.name === 'losses')?.value || 0,
                          gamesBehind: entry.stats.find(stat => stat.name === 'gamesBehind')?.value || 0,
                          conference: conferenceName,
                          division: divisionName
                      }));
                  }
              });
            };

            // Initialize divisions arrays
            initializeDivisions();

            console.log('Conferences:', conferences);

            // Populate divisions for each conference
            console.log('Filtered West Conference:', conferences.filter(conf => conf.abbreviation === 'West'));
            console.log('Filtered East Conference:', conferences.filter(conf => conf.abbreviation === 'East'));

            // Populate divisions for each conference
            populateDivisions(conferences.find(conf => conf.abbreviation === 'West')?.children, 'Western Conference');
            populateDivisions(conferences.find(conf => conf.abbreviation === 'East')?.children, 'Eastern Conference');

            // Sort the teams within each division by wins
            for (const conference in divisions) {
                for (const division in divisions[conference]) {
                    divisions[conference][division].sort((a, b) => b.wins - a.wins);
                }
            }

            // Assign the divisions object to this.divisions
            this.divisions = divisions;

            // Now divisions object contains the structured data
            console.log(this.divisions);
        }
    } catch (error) {
        console.error('Error fetching division standings:', error);
    } finally {
        this.isLoading = false; // Set loading state to false after API call completes
    }
},
},
  };
</script>