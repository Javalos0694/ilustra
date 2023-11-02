<template>
  <div class="d-flex align-center">
    <v-icon icon="mdi-arrow-left-bold-circle mr-5" @click="goBack"></v-icon>
    <h1 class="d-block">{{ title }}</h1>
  </div>
</template>

<script lang="ts">
import router from "@/router";
import { computed, defineComponent } from "vue";

export default defineComponent({
  name: "TitleLabel",
  props: {
    path: {
      type: String,
      default: "",
    },
    title: {
      type: String,
      default: "",
    },
  },
  setup(props) {
    const path = computed(() => props.path);
    const title = computed(() => props.title);

    const goBack = () => {
      router.push(path.value);
    };

    return {
      goBack,
      path,
      title,
    };
  },
});
</script>