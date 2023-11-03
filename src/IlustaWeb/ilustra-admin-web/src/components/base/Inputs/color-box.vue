<template>
  <div class="box-container">
    <div
      class="box-item"
      v-for="item in itemsArray"
      v-bind:key="item"
      :style="{
        backgroundColor: `${item.ColorCode ? item.ColorCode : '#fff'}`,
      }"
      :class="[item.IsAvailable ? '' : 'disabled']"
      @click="selectItem(item)"
    >
      <v-tooltip activator="parent" location="top">{{
        item.ColorName
      }}</v-tooltip>
    </div>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent, ref } from "vue";

export default defineComponent({
  name: "ColorBox",
  emits: ["setSelected"],
  props: {
    items: {
      type: Array<any>,
      default: () => [],
    },
  },
  setup(props, { emit }) {
    const itemsArray = computed(() => props.items);
    const selectedArray = ref<Array<any>>([]);

    const selectItem = (item: any) => {
      if (selectedArray.value.every((x) => x != item)) {
        selectedArray.value.push(item);
      } else {
        let array = [...selectedArray.value];
        array = array.filter((x) => x != item);
        selectedArray.value = array;
      }
      setArraySelected();
    };

    const setArraySelected = () => {
      emit("setSelected", selectedArray.value);
    };

    return {
      itemsArray,
      selectedArray,
      selectItem,
    };
  },
});
</script>