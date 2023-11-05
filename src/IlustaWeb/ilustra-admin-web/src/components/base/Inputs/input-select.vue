<template>
  <v-select
    :label="selectLabel"
    :items="itemsSelect"
    :item-title="itemKey"
    :item-value="itemValue"
    v-model="itemChecked"
  ></v-select>
</template>

<script lang="ts">
import {
  computed,
  defineComponent,
  onBeforeMount,
  onMounted,
  onUpdated,
  ref,
  watch,
} from "vue";

export default defineComponent({
  name: "InputSelect",
  emits: ["setItemSelected"],
  props: {
    items: {
      type: Array<any>,
      default: () => [],
    },
    keyValue: {
      type: String,
      default: "",
    },
    value: {
      type: String,
      default: "",
    },
    label: {
      type: String,
      default: "",
    },
    valueSelected: {
      type: Number,
      default: 0,
    },
  },
  setup(props, { emit }) {
    const itemsSelect = computed(() => formatSelectItems(props.items));
    const itemKey = computed(() => props.keyValue);
    const itemValue = computed(() => props.value);
    const selectLabel = computed(() => props.label);
    const itemSelected = computed(() => props.valueSelected);

    const itemChecked = ref(0);

    const formatSelectItems = (arrayItems: any[]): any[] => {
      const defaultSelect: { [key: string]: any } = {
        [itemValue.value]: 0,
        [selectLabel.value]: `Select ${selectLabel.value}`,
      };
      const array: any[] = [defaultSelect];
      return [...array, ...arrayItems];
    };

    const selectHandler = () => {
      emit("setItemSelected", itemChecked.value);
    };

    watch(itemChecked, () => selectHandler());

    watch(itemSelected, () => (itemChecked.value = itemSelected.value));

    return {
      itemsSelect,
      itemKey,
      itemValue,
      selectLabel,
      itemSelected,
      itemChecked,
    };
  },
});
</script>