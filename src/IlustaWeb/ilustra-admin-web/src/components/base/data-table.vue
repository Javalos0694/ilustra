<template>
  <VDataTable
    hide-no-data
    no-data-text="No results"
    hover
    :headers="headers"
    class="mx-auto rounded px-5 py-5"
    :items="items"
    :item-key="keyItem"
    :loading="loading"
  >
    <template v-slot:headers="{ headers }">
      <tr>
        <th
          v-for="header in headers[0]"
          :key="header.title"
          class="text-white"
          :style="{
            width: `${Math.floor(100 / headers[0].length)}%`,
            textAlign: `${header.align}`,
          }"
        >
          {{ header.title }}
        </th>
      </tr>
    </template>
    <template
      v-slot:item.Actions
      v-if="headers.some((x) => x.title == 'Actions')"
    >
      <div>Hay acciones</div>
    </template>
    <template
      v-slot:item.Switch
      v-if="headers.some((x) => x.title == 'Switch')"
    >
      <div>Switch</div>
    </template>
  </VDataTable>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";
import { HeaderDataTable } from "@/models/swag-api-models";
import { VDataTable } from "vuetify/lib/labs/components.mjs";

export default defineComponent({
  name: "data-table",
  components: { VDataTable },
  props: {
    headers: {
      type: Array<HeaderDataTable>,
      default: () => [],
    },
    items: {
      type: Array<any>,
      default: () => [],
    },
    key: {
      type: String,
      default: "",
    },
    loading: {
      type: Boolean,
      default: false,
    },
  },
  setup(props) {
    const headers = computed(() => props.headers);
    const items = computed(() => props.items);
    const loading = computed(() => props.loading);
    const keyItem = computed(() => "item." + props.key);

    return {
      headers,
      items,
      keyItem,
      loading,
    };
  },
});
</script>

<style lang="scss">
table thead tr th {
  background-color: #212121;
}

table tbody tr:nth-child(2n) {
  background-color: #e0e0e0;
}

table tbody tr td {
  cursor: pointer;
}
</style>