<template>
  <v-container fluid class="h-screen bg-grey-darken-4">
    <v-row class="h-100">
      <v-col cols="12">
        <v-card class="position-center" max-width="450" max-height="550">
          <v-card-title>
            <h5 class="text-center">Welcome</h5>
          </v-card-title>
          <LoginForm></LoginForm>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import LoginForm from "@/components/Auth/login.vue";

export default defineComponent({
  name: "Login",
  components: { LoginForm },
});
</script>