<template>
  <v-snackbar v-model="showToast" :color="typeToast" tile>
    {{ messageStored }}
    <template v-slot:actions>
      <v-btn variant="text" color="white" @click="showToast = false">
        <v-icon>mdi-close</v-icon>
      </v-btn>
    </template>
  </v-snackbar>
</template>

<script lang="ts">
import { defineComponent, ref, watch } from "vue";
import { ToastIconType } from "@/models/swag-api-models";
import { useToastStore } from "@/store/toast";
import { storeToRefs } from "pinia";

export default defineComponent({
  name: "toast-message",
  setup() {
    const icon = ref(ToastIconType.Success);

    const toastStore = useToastStore();
    const { hideToast } = toastStore;
    const { titleStored, messageStored, showToast, typeToast } =
      storeToRefs(toastStore);

    watch(showToast, () => {
      if (showToast.value) {
        setTimeout(() => {
          hideToast();
        }, 3 * 1000);
      }
    });

    return {
      typeToast,
      icon,
      showToast,
      titleStored,
      messageStored,
    };
  },
});
</script>