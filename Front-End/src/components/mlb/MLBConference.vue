<template>
  <div>
    <!-- Conditional rendering of NHL table -->
    <div class="relative overflow-x-auto shadow-md sm:rounded-lg">
      <table v-if="showMLBTable" class="mt-4 border-collapse border border-gray-500 cursor-pointer">
      <!-- Table content -->
        <colgroup>
          <col style="width: 50%;">
          <col style="width: 2px;">
          <col style="width: 50%;">
        </colgroup>
        <thead class="text-xs text-gray-700 uppercase bg-gray-100 dark:bg-gray-700 dark:text-gray-100">
        <tr>
          <th scope="col" class="px-6 py-3" @click="showMLBDivision('al')">American League</th>
          <th scope="col" class="px-6 py-3 bg-gray-500"></th> <!-- Empty header for separator -->
          <th scope="col" class="px-6 py-3" @click="showMLBDivision('nl')">National League</th>
        </tr>
      </thead>
      <tbody>
        <!-- Table body content -->
      </tbody>
      </table>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    showConferenceTitle: Boolean,
    showMLBTable: Boolean,
  },
  methods: {
    showMLBDivision(conference) {
      this.$emit('showMLBDivision', conference);
    },
  },
};
</script>