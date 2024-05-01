<template>
  <div>
    <!-- Conditional rendering of NHL table -->
    <h1 v-if="showMLBWesternDivisionTitle" class="font-medium text-gray-400 text-3xl md:text-10xl my-10">Western Division</h1>
        <div class="relative overflow-x-auto shadow-md sm:rounded-lg">
          <table v-if="showMLBALTable" class="mt-4 border-collapse border border-gray-500">
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
                <th scope="col" class="px-6 py-3" @click="showMLBDivision('eastern')">American League East</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showMLBDivision('central')">American League Central</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showMLBDivision('western')">American League West</th>
              </tr>
            </thead>
            <tbody>
              <!-- Table body content -->
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Baltimor Orioles</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Cleveland Guardians</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Texas Rangers</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">New York Yankees</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Kansas City Royals</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Seattle Mariners</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Toronto Blue Jays</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Detroit Tigers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Oakland Athletics</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Boston Red Sox</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Minnesota Twins</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Los Angeles Angels</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Tampa Bay Rays</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Chicago White Sox</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Houston Astros</td>
                </tr>
            </tbody>
          </table>

          <h1 v-if="showMLBEasternDivisionTitle" class="font-medium text-gray-400 text-3xl md:text-10xl my-10">Eastern Division</h1>
          <table v-if="showMLBNLTable" class="mt-4 border-collapse border border-gray-500">
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
                <th scope="col" class="px-6 py-3" @click="showMLBDivision('eastern')">National League East</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showMLBDivision('central')">National League Central</th>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <th scope="col" class="px-6 py-3" @click="showMLBDivision('western')">National League West</th>
              </tr>
            </thead>
            <tbody>
              <!-- Table body content -->
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Atlanta Braves</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Milwaukee Brewers</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Los Angeles Dodgers</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Philadelphia Phillies</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Chicago Cubs</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">San Diego Padres</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">New York Mets</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Cincinati Reds</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Arizona Diamondbacks</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Washington Nationals</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Pittsburgh Pirates</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">San Francisco Giants</td>
              </tr>
              <tr class="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700">
                <td class="px-6 py-4 text-gray-400">Miami Marlins</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Saint Louis Cardinals</td>
                <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
                <td class="px-6 py-4 text-gray-400">Colorado Rockies</td>
                </tr>

            </tbody>
          </table>
        </div>

  </div>
</template>

<script>
export default {
  props: {
    showMLBWesternDivisionTitle: Boolean,
    showMLBEasternDivisionTitle: Boolean,
    showMLBALTable: Boolean,
    showMLBNLTable: Boolean,
  },
  methods: {
    showMLBDivision(conference) {
      this.$emit('showMLBDivision', conference);
    },
  },
};
</script>