<template>
 <section class="py-10 md:py-10 bg-zinc-300 h-fit">
    <div class="container max-w-screen-xl mx-auto px-4">
      
        <div class="flex justify-center items-center border-8 rounded-md border-gray-500 bg-slate-200">
          <div class="flex space-x-8 cursor-pointer mx-5 my-5">
            <img src="/images/NHL-Logo.png" alt="NHL Logo" class="border-4 border-gray-500 rounded-xl" @click="showTable('nhl')">
            <img src="/images/MLB-Logo.png" alt="MLB Logo" class="border-4 border-gray-500 rounded-xl" @click="showTable('mlb')">
            <img src="/images/NBA-Logo.png" alt="NBA Logo" class="border-4 border-gray-500 rounded-xl" @click="showTable('nba')">
          </div>
        </div>

        <div v-if="showDropDown && !showNHLTeamPlayers" class="flex justify-center my-4">
          <select v-model="selectedStats" @change="showStats(selectedStats)" class="block w-1/2 p-2 text-gray-700 bg-white border border-gray-300 rounded-md focus:border-blue-500 focus:outline-none focus:ring">
            <option value="Select" disabled selected>Select an option</option>
            <option value="Conferences">Conferences</option>
            <option value="Divisions">Divisions</option>
          </select>
        </div>

        <!-- NHL Conference Component -->
        <NHLConference 
          :showNHLTable="showNHLTable"
          
        />
        <div v-if="!showNHLTeamPlayers">
          <!-- NHL Division Component -->
          <NHLDivision 
            :showDivisionOptionTable = "showDivisionOptionTable"
            @teamSelected = "showTeamPlayers" 
          />
        </div>

        <!-- NHL Team Players Component -->
        <NHLTeamPlayers v-if="showNHLTeamPlayers" 
          :teamId="selectedTeamId" 
          :emitEventOnMount="true"
          @nhlTeamPlayersMounted="handleNHLTeamPlayersMounted"
        />

    </div>
  </section>
</template>

<script>
  import NHLConference from './nhl/NHLConference.vue';
  import NHLDivision from './nhl/NHLDivision.vue';
  import NHLTeamPlayers from './nhl/NHLTeamPlayers.vue';

  export default {
    components:{
      NHLConference,
      NHLDivision,
      NHLTeamPlayers

    },
    data() {
      return {
        showDropDown: false,
        selectedStats: "Select", 
        showNHLTable: false,
        showDivisionOptionTable: false,
        showNHLTeamPlayers: false,
        selectedTeamId: null,
        selectedDivision: null,

        currentLeague: null,
        showMLBTable: false,
        showMLBALTable: false,
        showMLBNLTable: false,
        showMLBWesternDivisionTitle: false,
        showMLBEasternDivisionTitle: false,

        showNBATable: false,
        showNBAWesternTable: false,
        showNBAEasternTable: false,
        showNBAWesternDivisionTitle: false,
        showNBAEasternDivisionTitle: false,
        
      };
    },
    methods: {
      handleNHLTeamPlayersMounted() {
        console.log("Hello");
      this.showDropDown = true;
      this.showNHLTeamPlayers = false;
    },
     showStats(option) {

        this.showNHLTable = false;
        this.showDivisionOptionTable = false;

        if (option === 'Conferences') {
          // Logic for showing conference stats
          this.showNHLTable = !this.showNHLTable;
          this.showDivisionOptionTable = false;
        } else if (option === 'Divisions') {
          // Logic for showing division stats
          this.showDivisionOptionTable = !this.showDivisionOptionTable;
          this.showNHLTable = false;
        }
      },
      showTable(league) {
        
        if (league === 'nhl') {
          this.currentLeague = 'nhl';
          this.showDropDown = true;
          
          this.showMLBTable = false;
          this.showNBATable = false;
          this.showNHLTeamPlayers = false;
          this.selectedStats = "Select";
          this.showDivisionOptionTable = false;
        } else if (league === 'mlb') {
          this.currentLeague = 'mlb';
          this.showMLBTable = !this.showMLBTable;
          this.showNHLTable = false;
          this.showNHLWesternDivisionTitle = false;
          this.showNHLEasternDivisionTitle = false;
          this.showNHLWesternTable = false;
          this.showNHLEasternTable = false;
          this.showNBATable = false;
          this.showNBAWesternDivisionTitle = false;
          this.showNBAEasternDivisionTitle = false;
          this.showNBAWesternTable = false;
          this.showNBAEasternTable = false;
        } else if (league === 'nba') {
          this.currentLeague = 'nba';
          this.showNBATable = !this.showNBATable;
          this.showNBAWesternDivisionTitle = false;
          this.showNBAEasternDivisionTitle = false;
          this.showNBAWesternTable = false;
          this.showNBAEasternTable = false;
          this.showNHLTable = false;
          this.showMLBTable = false;
          this.showMLBWesternDivisionTitle = false;
          this.showMLBEasternDivisionTitle = false;
          this.showMLBALTable = false;
          this.showMLBNLTable = false;
          this.showNHLWesternDivisionTitle = false;
          this.showNHLEasternDivisionTitle = false;
          this.showNHLWesternTable = false;
          this.showNHLEasternTable = false;
        }
      },
      showNHLDivision(conference) {
        if (conference === 'western') {
          this.showNHLWesternDivisionTitle = true;
          this.showNHLEasternDivisionTitle = false;
          this.showNHLWesternTable = !this.showNHLWesternTable;
          this.showNHLEasternTable = false;
        } else if (conference === 'eastern') {
          this.showNHLEasternTable = !this.showNHLEasternTable;
          this.showNHLWesternDivisionTitle = false;
          this.showNHLEasternDivisionTitle = true;
          this.showNHLWesternTable = false;
        }
      },
      showMLBDivision(conference) {
        if (conference === 'al') {
          this.showMLBWesternDivisionTitle = true;
          this.showMLBEasternDivisionTitle = false;
          this.showMLBALTable = !this.showMLBALTable;
          this.showMLBNLTable = false;
        } else if (conference === 'nl') {
          this.showMLBEasternDivisionTitle = true;
          this.showMLBWesternDivisionTitle = false;
          this.showMLBNLTable = !this.showMLBNLTable;
          this.showMLBALTable = false;
        }
      },
      showNBADivision(conference) {
        if (conference === 'western') {
          this.showNBAWesternDivisionTitle = true;
          this.showNBAEasternDivisionTitle = false;
          this.showNBAWesternTable = !this.showNBAWesternTable;
          this.showNBAEasternTable = false;
        } else if (conference === 'eastern') {
          this.showNBAEasternTable = !this.showNBAEasternTable;
          this.showNBAWesternDivisionTitle = false;
          this.showNBAEasternDivisionTitle = true;
          this.showNBAWesternTable = false;
        }
      },
       // Update this method to set showNHLTeamPlayers to true and selectedTeamId to the selected team's ID
      showTeamPlayers(teamId) {
        this.showNHLTeamPlayers = true;
        this.selectedTeamId = teamId;

      }
    }
  };
</script>

<style>
  .logo {
    width: 500px; 
    cursor: pointer;
    border: solid;
  }
</style>