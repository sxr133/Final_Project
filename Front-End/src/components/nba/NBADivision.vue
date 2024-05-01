<template>
  <div>
    <!-- Conditional rendering of NHL table -->
    <h1 v-if="showNBAWesternDivisionTitle" class="font-medium text-gray-400 text-3xl md:text-10xl my-10">Western Division</h1>
        <div class="relative overflow-x-auto shadow-md sm:rounded-lg">
          <table v-if="showNBAWesternTable" class="mt-4 border-collapse border border-gray-500">
            <!-- Table content -->
            <colgroup>
              <col style="width: 33%;">
              <col style="width: 2px;">
              <col style="width: 33%;">
              <col style="width: 2px;">
              <col style="width: 33%;">
            </colgroup>
            <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-100">
              <tr>
                <th scope="col" class="px-6 py-3" @click="showNBADivision('nw')">Norhtwest</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showNBADivision('pac')">Pacific</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showNBADivision('sw')">Southwest</th>
              </tr>
            </thead>
            <tbody>
              <!-- Table body content -->
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Oklahoma City Thunder</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Los Angeles Clippers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Dallas Mavericks</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Denver Nuggets</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Phoenix Suns</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">New Orleans Pelicans</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Minnesota Timberwolves</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Los Angeles Lakers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Houston Rockets</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Utah Jazz</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Sacramento Kings</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Memphis Grizzlies</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Portland Trail Blazers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Golden State Warriors</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">San Antonio Spurs</td>
                </tr>
            </tbody>
          </table>

          <h1 v-if="showNBAEasternDivisionTitle" class="font-medium text-gray-400 text-3xl md:text-10xl my-10">Eastern Division</h1>
          <table v-if="showNBAEasternTable" class="mt-4 border-collapse border border-gray-500">
            <!-- Table content -->
            <colgroup>
              <col style="width: 33%;">
              <col style="width: 2px;">
              <col style="width: 33%;">
              <col style="width: 2px;">
              <col style="width: 33%;">
            </colgroup>
            <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-100">
              <tr>
                <th scope="col" class="px-6 py-3" @click="showNBADivision('atl')">Atlantic</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showNBADivision('cnt')">Central</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showNBADivision('se')">Southeast</th>
              </tr>
            </thead>
            <tbody>
              <!-- Table body content -->
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Boston Celtics</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Milwaukee Bucks</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Orlando Magic</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">New York Knicks</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Cleveland Cavaliers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Miami Heat</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Philadelphia 76ers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Indiana Pacers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Atlanta Hawks</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Brooklyn Nets</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Chicago Bulls</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Charlotte Hornets</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Toronto Raptors</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Detroit Pistons</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Washington Wizards</td>
                </tr>

            </tbody>
          </table>
        </div>

  </div>
</template>

<script>
export default {
  props: {
    showNBAWesternDivisionTitle: Boolean,
    showNBAEasternDivisionTitle: Boolean,
    showNBAWesternTable: Boolean,
    showNBAEasternTable: Boolean,
  },
  methods: {
    showNBADivision(conference) {
      this.$emit('showNBADivision', conference);
    },
  },
};
</script>