<template>
  <v-card-subtitle class="text-center"> Have a greate day! </v-card-subtitle>
  <v-card-text>
    <v-form>
      <v-container>
        <v-row>
          <v-col cols="12">
            <v-text-field
              label="Username"
              required
              :rules="[(v) => ValidateInput(v, 'Username')]"
              v-model="logRequest.Username"
            ></v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field
              label="Password"
              :rules="[(v) => ValidateInput(v, 'Password')]"
              required
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
      :loading="submitButtonStatus"
      @click="onLoginHandler"
      variant="tonal"
      class="bg-cyan-lighten-2 text-grey-lighten-5"
      >Log in</v-btn
    >
  </v-card-actions>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import { LoginRequest } from "@/models/swag-api-request";
import { useAuth } from "@/services/useAuth";
import { useAuthStore } from "@/store/auth";
import router from "@/router";

import { ValidateInput } from "@/utils/validate";
import { storeToRefs } from "pinia";

export default defineComponent({
  name: "LoginForm",
  setup() {
    const logRequest = ref<LoginRequest>({} as LoginRequest);
    const { login } = useAuth();

    const authStore = useAuthStore();
    const { tokenStored } = storeToRefs(authStore);
    const { setStoredValues } = authStore;

    const submitButtonStatus = ref(false);

    const onLoginHandler = async () => {
      submitButtonStatus.value = true;
      const { Username, token } = await login(logRequest.value);
      setStoredValues({ Username, token });
      submitButtonStatus.value = false;
      if (tokenStored.value.length > 0) router.push("/");
    };

    return {
      logRequest,
      submitButtonStatus,
      onLoginHandler,
      ValidateInput,
    };
  },
});
</script>