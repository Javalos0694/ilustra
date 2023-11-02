<template>
  <v-main class="d-flex">
    <sidebar />
    <v-container fluid class="px-5 py-5">
      <v-card class="px-4 py-4">
        <router-view />
      </v-card>
    </v-container>
  </v-main>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import sidebar from "@/components/base/sidebar.vue";

export default defineComponent({
  name: "Layout",
  components: { sidebar },
});
</script>