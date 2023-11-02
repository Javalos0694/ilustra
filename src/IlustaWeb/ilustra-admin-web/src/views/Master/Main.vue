<template>
  <h1>Master</h1>
  <v-divider class="my-5"></v-divider>
  <v-container fluid>
    <v-row class="mb-4">
      <h4 class="text-grey-darken-1">Select option</h4>
    </v-row>
    <v-row>
      <v-col cols="12" md="4">
        <v-card class="rounded bg-grey-lighten-4 pointer" hover to="/colors">
          <v-card-title>Colors</v-card-title>
          <v-card-text>
            <span>Can configure colors</span>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col cols="12" md="4">
        <v-card class="rounded bg-grey-lighten-4 pointer" hover to="categories">
          <v-card-title>Categories</v-card-title>
          <v-card-text>
            <span>Can configure categories</span>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col cols="12" md="4">
        <v-card class="rounded bg-grey-lighten-4 pointer" hover to="/dimensions">
          <v-card-title>Dimensions</v-card-title>
          <v-card-text>
            <span>Can configure dimension</span>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
  name: "Master",
});
</script>