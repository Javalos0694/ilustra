<template>
  <v-text-field
    type="date"
    v-model="nDate"
    :label="label"
    @change="onChangeDate"
  ></v-text-field>
</template>

<script lang="ts">
import { computed, defineComponent, ref, watch } from "vue";
import { FormatDateString } from "@/utils/string-helper";

export default defineComponent({
  name: "input-date",
  props: {
    label: {
      type: String,
      default: "",
    },
    date: {
      type: String,
      default: "",
    },
  },
  emits: ["setDate"],
  setup(props, { emit }) {
    const nDate = ref("");

    const date = computed(() => FormatDateString(props.date));
    const label = computed(() => props.label);

    const onChangeDate = () => {
      emit("setDate", nDate.value);
    };

    watch(date, () => {
      nDate.value = date.value;
    });

    return {
      nDate,
      date,
      label,
      onChangeDate,
    };
  },
});
</script>