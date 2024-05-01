<template>
  <div>
    <div v-if="showDivisionOptionTable" class="relative overflow-x-auto shadow-md sm:rounded-lg">
      <!-- Dropdown for selecting conference -->
      <div class="flex justify-center my-4">
        <select v-model="selectedDivision" @change="fetchDivisionStandings" class="block w-1/2 p-2 text-gray-700 bg-white border border-gray-300 rounded-md focus:border-blue-500 focus:outline-none focus:ring">
          <option value="Select" disabled selected>Select a Division</option>
          <option value="Western Conference">Western Division</option>
          <option value="Eastern Conference">Eastern Division</option>
        </select>
      </div>
    </div>
    <div v-if="selectedDivision === 'Western Conference'" class="justify-center">
      
      <table v-if="westernCentralTeams.length > 0" class="mt-4 border-collapse border border-gray-500" >
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
            <th colspan="7" class="text-center py-4 text-xl font-semibold">Central Division</th>
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
          <tr v-for="(team, index) in westernCentralTeams" :key="index" class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 px-6 py-4 text-gray-400">
            <td class="px-6 py-4 text-gray-400">{{ team.displayName }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.wins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.losses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeWins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeLosses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.points }}</td>
                                                            
            <td class="px-6 py-4 text-gray-400 text-center"><router-link :to="'/team-roster/' + team.id" @click="$emit('teamSelected', team.id)">View Team Roster</router-link></td>
          </tr>
        </tbody>
      </table>
      <table v-if="westernPacificTeams.length > 0" class="mt-4 border-collapse border border-gray-500">
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
            <th colspan="7" class="text-center py-4 text-xl font-semibold">Pacific Division</th>
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
          <tr v-for="(team, index) in westernPacificTeams" :key="index" class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 px-6 py-4 text-gray-400">
            <td class="px-6 py-4 text-gray-400">{{ team.displayName }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.wins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.losses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeWins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeLosses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.points }}</td>
            <td class="px-6 py-4 text-gray-400 text-center"><router-link :to="'/team-roster/' + team.id" @click="$emit('teamSelected', team.id)">View Team Roster</router-link></td>
          </tr>
          </tbody>
      </table>
    </div>
    <div v-else-if="selectedDivision === 'Eastern Conference'" class="justify-center">
      <table v-if="easternAtlanticTeams.length > 0" class="mt-4 border-collapse border border-gray-500">
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
            <th colspan="7" class="text-center py-4 text-xl font-semibold">Atlantic Division</th>
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
          <tr v-for="(team, index) in easternAtlanticTeams" :key="index" class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 px-6 py-4 text-gray-400">
            <td class="px-6 py-4 text-gray-400">{{ team.displayName }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.wins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.losses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeWins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeLosses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.points }}</td>
            <td class="px-6 py-4 text-gray-400 text-center"><router-link :to="'/team-roster/' + team.id" @click="$emit('teamSelected', team.id)">View Team Roster</router-link></td>
          </tr>
        </tbody>
      </table>
      <table v-if="easternMetropolitanTeams.length > 0" class="mt-4 border-collapse border border-gray-500">
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
            <th colspan="7" class="text-center py-4 text-xl font-semibold">Metropolitan Division</th>
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
          <tr v-for="(team, index) in easternMetropolitanTeams" :key="index" class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 px-6 py-4 text-gray-400">
            <td class="px-6 py-4 text-gray-400">{{ team.displayName }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.wins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.losses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeWins }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.overtimeLosses }}</td>
            <td class="px-6 py-4 text-gray-400 text-center">{{ team.points }}</td>
            <td class="px-6 py-4 text-gray-400 text-center"><router-link :to="'/team-roster/' + team.id" @click="$emit('teamSelected', team.id)">View Team Roster</router-link></td>
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

      showDivisionOptionTable: Boolean,

    },
    computed: {
      westernCentralTeams() {
        return this.divisions['Western Conference']['Central Division'];
      },
      westernPacificTeams() {
        return this.divisions['Western Conference']['Pacific Division'];
      },
      easternAtlanticTeams() {
        return this.divisions['Eastern Conference']['Atlantic Division'];
      },
      easternMetropolitanTeams() {
        return this.divisions['Eastern Conference']['Metropolitan Division'];
      }
    },
    data(){
      return{
        selectedDivision: 'Select', // Default selection
        divisions: {
        'Western Conference': {
          'Central Division': [],
          'Pacific Division': []
        },
        'Eastern Conference': {
          'Atlantic Division': [],
          'Metropolitan Division': []
        }
      }
        
      };
    },
    
    methods: {
      showNHLDivision(conference) {
        this.$emit('showNHLDivision', conference);
      },
      async fetchDivisionStandings() {
        this.isLoading = true;
        const endpoint = `https://localhost:7102/api/NHLDivisionStandings`;
        try {
          const response = await axios.get(endpoint, {
            headers: {
              conference: this.selectedDivision // Sending the selected conference as a header
            }
          });
          
          // Clear previous data
          Object.keys(this.divisions[this.selectedDivision]).forEach(key => {
            this.divisions[this.selectedDivision][key] = [];
          });
          console.log("response data" + response.data);
          if (response.data && response.data.children) {
            response.data.children.forEach(division => {
              this.processDivisionData(division);
            });
          }
          console.log("Divisions updated:", this.divisions);
        } catch (error) {
          console.error('Error fetching NHL division standings:', error);
        } finally {
          this.isLoading = false;
        }
      },

      processDivisionData(division) {
        if (!division.standings || !division.standings.entries) {
          return;
        }

        const divisionName = division.name;
        const divisionTeams = division.standings.entries.map(entry => this.processTeamData(entry));
        // Initialize the division array if it doesn't exist
        if (!this.divisions[this.selectedDivision][divisionName]) {
          this.divisions[this.selectedDivision][divisionName] = [];
        }

        this.divisions[this.selectedDivision][divisionName].push(...divisionTeams);
      },

      processTeamData(entry) {
        if (!entry.team || !entry.stats) {
          return {};
        }

        const teamData = {
          id: entry.team.id, 
          displayName: entry.team.displayName
        };
        const statsMap = new Map(entry.stats.map(stat => [stat.name, stat.value]));
        teamData.wins = statsMap.get('wins') || 0;
        teamData.losses = statsMap.get('losses') || 0;
        teamData.overtimeWins = statsMap.get('overtimeWins') || 0;
        teamData.overtimeLosses = statsMap.get('overtimeLosses') || 0;
        teamData.points = statsMap.get('points') || 0;

        return teamData;
      },
    },
  };
</script>