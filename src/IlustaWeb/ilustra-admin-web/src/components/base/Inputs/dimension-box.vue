<template>
  <div class="box-container">
    <div
      class="box-item square text-center"
      v-for="item in items"
      v-bind:key="item.IdDimension"
      :class="[
        item.IsAvailable ? '' : 'disabled',
        selectedArray.some((x) => x.IdDimension == item.IdDimension) ? 'selected' : '',
      ]"
      @click="selectItem(item)"
    >
      {{ item.DimensionCode }}
      <v-tooltip activator="parent" location="top">{{
        item.DimensionName
      }}</v-tooltip>
    </div>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";

export default defineComponent({
  name: "DimensionBox",
  emits: ["setSelected"],
  props: {
    items: {
      type: Array<any>,
      default: () => [],
    },
    itemsSelected: {
      type: Array<any>,
      default: () => [],
    },
  },
  setup(props, { emit }) {
    const dimensions = computed(() => props.items);
    const selectedArray = computed(() => props.itemsSelected);

    const selectItem = (item: any) => {
      let array = [...selectedArray.value];
      if (array.every((x) => x.IdDimension != item.IdDimension)) {
        array.push(item);
      } else {
        array = array.filter((x) => x.IdDimension != item.IdDimension);
      }
      setArraySelected(array);
    };

    const setArraySelected = (array: any[]) => {
      emit("setSelected", array);
    };

    return {
      dimensions,
      selectedArray,
      selectItem,
    };
  },
});
</script>