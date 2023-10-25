<template>
  <v-app>
    <v-main class="d-flex">
      <sidebar v-if="tokenStored.length > 0" />
      <router-view v-if="tokenStored.length == 0" />
      <v-container fluid v-if="tokenStored.length > 0" class="px-5 py-5">
        <v-card class="px-4 py-4">
          <router-view />
        </v-card>
      </v-container>
    </v-main>
    <toast />
  </v-app>
</template>

<script lang="ts">
import { defineComponent, watch } from "vue";
import toast from "@/components/base/toast.vue";
import sidebar from "@/components/base/sidebar.vue";
import { useAuthStore } from "./store/auth";
import { storeToRefs } from "pinia";
import router from "./router";

export default defineComponent({
  name: "App",
  components: { toast, sidebar },
  setup() {
    const authStore = useAuthStore();
    const { tokenStored } = storeToRefs(authStore);
    watch(tokenStored, () => {
      if (tokenStored.value.length == 0) {
        router.push("/login");
      }
    });
    return {
      tokenStored,
    };
  },
});
</script>
