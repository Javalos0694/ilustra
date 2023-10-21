<template>
  <v-container fluid class="h-screen bg-grey-darken-4">
    <v-row class="h-100">
      <v-col cols="12">
        <v-card class="position-center" max-width="450" max-height="550">
          <v-card-title>
            <h5 class="text-center">Welcome</h5>
          </v-card-title>
          <v-card-subtitle class="text-center"> Have a greate day! </v-card-subtitle>
          <v-card-text>
            <v-form>
              <v-container>
                <v-row>
                  <v-col cols="12">
                    <v-text-field label="Username" hide-details></v-text-field>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      label="Password"
                      hide-details
                      type="password"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-form>
          </v-card-text>
          <v-card-actions class="justify-center">
            <v-btn variant="tonal" class="bg-cyan-lighten-2 text-grey-lighten-5">Login</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent } from "vue";

defineComponent({
  name: "Login",
});
</script>