<template>
  <v-container
    fluid
    class="loader-container position-fixed-start h-screen w-screen"
  >
    <div class="position-center">
      <span class="loader"></span>
    </div>
  </v-container>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Loader",
});
</script>