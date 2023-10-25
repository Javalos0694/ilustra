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
import { useToastStore } from "@/store/toast";
import router from "@/router";

import { handlerError } from "@/utils/handlers";
import { ToastTitle, ToastMessage, ToastType } from "@/models/swag-api-models";
import { ValidateInput } from "@/utils/validate";

export default defineComponent({
  name: "LoginForm",
  setup() {
    const logRequest = ref<LoginRequest>({} as LoginRequest);
    const { login } = useAuth();

    const authStore = useAuthStore();
    const { setStoredValues } = authStore;

    const toastStore = useToastStore();
    const { setToastProperties } = toastStore;

    const submitButtonStatus = ref(false);

    const onLoginHandler = async () => {
      try {
        submitButtonStatus.value = true;
        const { Username, token } = await login(logRequest.value);
        setStoredValues({ Username, token });
        setToastProperties({
          title: ToastTitle.Success,
          message: ToastMessage.Success,
          type: ToastType.Success,
          show: true,
        });
        router.push("/");
      } catch (e) {
        const error = handlerError(e);
        setToastProperties({
          title: ToastTitle.Error,
          message: error.Message,
          type: ToastType.Error,
          show: true,
        });
      } finally {
        submitButtonStatus.value = false;
      }
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