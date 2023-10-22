<template>
  <v-card-subtitle class="text-center"> Have a greate day! </v-card-subtitle>
  <v-card-text>
    <v-form>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              label="Username"
              hide-details
              v-model="logRequest.Username"
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              label="Password"
              hide-details
              type="password"
              v-model="logRequest.Password"
            ></v-text-field>
          </v-col>
        </v-row>
      </v-container>
    </v-form>
  </v-card-text>
  <v-card-actions class="justify-end">
    <v-btn
      @click="onLoginHandler"
      variant="tonal"
      class="bg-cyan-lighten-2 text-grey-lighten-5"
      >Login</v-btn
    >
  </v-card-actions>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import { LoginRequest } from "@/models/swag-api-request";
import { useAuth } from "@/services/useAuth";
import { useAuthStore } from "@/store/auth";
import router from "@/router";

export default defineComponent({
  name: "LoginForm",
  setup() {
    const logRequest = ref<LoginRequest>({} as LoginRequest);
    const { login } = useAuth();
    const authStore = useAuthStore();
    const { setStoredValues } = authStore;

    const onLoginHandler = async () => {
      try {
        const { Username, token } = await login(logRequest.value);
        setStoredValues({ Username, token });
        router.push("/")
      } catch (e) {
        console.log(e as string);
      }
    };

    return {
      logRequest,
      onLoginHandler,
    };
  },
});
</script>