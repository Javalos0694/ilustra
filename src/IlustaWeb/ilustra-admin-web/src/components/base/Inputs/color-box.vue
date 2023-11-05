<template>
  <div class="box-container">
    <div
      class="box-item"
      v-for="item in itemsArray"
      v-bind:key="item"
      :style="{
        backgroundColor: `${item.ColorCode ? item.ColorCode : '#fff'}`,
      }"
      :class="[
        item.IsAvailable ? '' : 'disabled',
        selectedArray.some((x) => x.IdColor == item.IdColor) ? 'selected' : '',
      ]"
      @click="selectItem(item)"
    >
      <v-tooltip activator="parent" location="top">{{
        item.ColorName
      }}</v-tooltip>
    </div>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";

export default defineComponent({
  name: "ColorBox",
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
    const itemsArray = computed(() => props.items);
    const selectedArray = computed(() => props.itemsSelected);

    const selectItem = (item: any) => {
      let array = [...selectedArray.value];
      if (array.every((x) => x.IdColor != item.IdColor)) {
        array.push(item);
      } else {
        array = array.filter((x) => x.IdColor != item.IdColor);
      }
      setArraySelected(array);
    };

    const setArraySelected = (array: any[]) => {
      emit("setSelected", array);
    };

    return {
      itemsArray,
      selectedArray,
      selectItem,
    };
  },
});
</script>