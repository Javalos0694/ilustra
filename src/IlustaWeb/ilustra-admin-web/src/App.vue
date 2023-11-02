<template>
  <v-app>
    <router-view />
    <toast />
    <Loader v-if="showLoader" />
  </v-app>
</template>

<script lang="ts">
import { defineComponent, watch } from "vue";
import toast from "@/components/base/toast.vue";
import Loader from "@/components/base/loader.vue";
import { useAuthStore } from "./store/auth";
import { useLoaderStore } from "./store/loader";
import { storeToRefs } from "pinia";
import router from "./router";

export default defineComponent({
  name: "App",
  components: { toast, Loader },
  setup() {
    const authStore = useAuthStore();
    const { tokenStored } = storeToRefs(authStore);

    const loaderStore = useLoaderStore();
    const { showLoader } = storeToRefs(loaderStore);

    watch(tokenStored, () => {
      if (tokenStored.value.length == 0) {
        router.push("/login");
      }
    });

    return {
      showLoader,
    };
  },
});
</script>
