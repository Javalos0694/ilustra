<template>
  <titleBack path="/master" title="Colors" />
  <v-divider class="my-5"></v-divider>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-form>
          <v-row>
            <v-col cols="12" md="6">
              <v-text-field
                label="ColorName"
                v-model="color.ColorName"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                label="ColorCode"
                v-model="color.ColorCode"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                label="BasePrice"
                v-model="color.BasePrice"
                type="number"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-switch
                label="IsAvailable"
                color="success"
                v-model="color.IsAvailable"
                hide-details
              ></v-switch>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12">
              <div v-if="isEdit" class="d-flex">
                <v-btn
                  class="bg-grey-darken-4 text-white mr-3"
                  prepend-icon="mdi-plus"
                  @click="newColor"
                  >New color</v-btn
                >
                <v-btn
                  class="bg-cyan-lighten-2 text-grey-lighten-5 text-white"
                  prepend-icon="mdi-content-save"
                  @click="saveColor"
                  >Save</v-btn
                >
              </div>
              <v-btn
                v-else
                class="bg-grey-darken-4 text-white"
                prepend-icon="mdi-plus"
                @click="saveColor"
                >Add color</v-btn
              >
            </v-col>
          </v-row>
        </v-form>
      </v-col>
    </v-row>
    <v-divider class="my-3"></v-divider>
    <v-row>
      <dataTable
        :headers="headers"
        :items="colors.Colors"
        key="IdColor"
        @selectItem="selectItem"
        @deleteItem="deleteItem"
        @toogleAvailable="toogleAvailableColor"
      />
    </v-row>
  </v-container>
</template>

<script lang="ts">
import router from "@/router";
import { defineComponent, onMounted, ref } from "vue";
import { useColor } from "@/services/useColor";
import { ColorsResponse } from "@/models/swag-api-response";

import titleBack from "@/components/base/title-back.vue";
import dataTable from "@/components/base/data-table.vue";
import { HeaderDataTable } from "@/models/swag-api-models";
import { setHeadersDataTable } from "@/utils/data-table";
import { ColorRequest } from "@/models/swag-api-request";

export default defineComponent({
  name: "Color",
  components: { titleBack, dataTable },
  setup() {
    const {
      getColors,
      initColorRequest,
      createColor,
      updateColor,
      deleteColor,
      toogleAvailable,
    } = useColor();

    const isEdit = ref(false);
    const colors = ref<ColorsResponse>({} as ColorsResponse);
    const color = ref<ColorRequest>(initColorRequest());
    const headers = ref<HeaderDataTable[]>([]);
    const colorHeaders = [
      "IdColor",
      "ColorName",
      "ColorCode",
      "BasePrice",
      "IsAvailable",
      "Actions",
    ];

    const goBack = () => {
      router.push("/master");
    };

    const getAllColors = async () => {
      colors.value = await getColors();
    };

    const newColor = () => {
      color.value = initColorRequest();
      isEdit.value = false;
    };

    const saveColor = async () => {
      if (isEdit.value) {
        await updateColor(color.value.IdColor, color.value);
      } else {
        await createColor(color.value);
      }
      await getAllColors();
      color.value = initColorRequest();
      isEdit.value = false;
    };

    const selectItem = (item: ColorRequest) => {
      isEdit.value = true;
      color.value = item;
    };

    const deleteItem = async (item: ColorRequest) => {
      await deleteColor(item.IdColor);
      await getAllColors();
    };

    const toogleAvailableColor = async (item: ColorRequest) => {
      await toogleAvailable(item.IdColor);
    };

    const init = async () => {
      await getAllColors();
      headers.value = setHeadersDataTable(colorHeaders);
    };

    onMounted(() => {
      init();
    });

    return {
      goBack,
      saveColor,
      selectItem,
      newColor,
      deleteItem,
      toogleAvailableColor,
      colors,
      headers,
      color,
      isEdit,
    };
  },
});
</script>