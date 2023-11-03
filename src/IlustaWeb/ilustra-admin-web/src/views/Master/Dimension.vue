<template>
  <titleBack path="/master" title="Dimension" />
  <v-divider class="my-5"></v-divider>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-form>
          <v-row>
            <v-col cols="12" md="6">
              <v-text-field
                label="DimensionName"
                v-model="request.DimensionName"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                label="DimensionCode"
                v-model="request.DimensionCode"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                label="BasePrice"
                v-model="request.BasePrice"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-switch
                label="IsAvailable"
                color="success"
                v-model="request.IsAvailable"
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
                  @click="newDimension"
                  >New dimension</v-btn
                >
                <v-btn
                  class="bg-cyan-lighten-2 text-grey-lighten-5 text-white"
                  prepend-icon="mdi-content-save"
                  @click="saveDimension"
                  >Save</v-btn
                >
              </div>
              <v-btn
                v-else
                class="bg-grey-darken-4 text-white"
                prepend-icon="mdi-plus"
                @click="saveDimension"
                >Add dimension</v-btn
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
        :items="dimensions.Dimensions"
        key="IdDimension"
        @selectItem="selectItem"
        @toogleAvailable="toogleDimension"
        @deleteItem="deleteDimensionSelected"
      />
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import dataTable from "@/components/base/data-table.vue";
import titleBack from "@/components/base/title-back.vue";
import { HeaderDataTable } from "@/models/swag-api-models";
import { setHeadersDataTable } from "@/utils/data-table";
import { DimensionsResponse } from "@/models/swag-api-response";
import { useDimension } from "@/services/useDimension";
import { DimensionRequest } from "@/models/swag-api-request";

export default defineComponent({
  name: "Dimension",
  components: { titleBack, dataTable },
  setup() {
    const {
      getAllDimensions,
      initDimensionRequest,
      createDimension,
      updateDimension,
      deleteDimension,
      toogleAvailableDimension,
    } = useDimension();

    const isEdit = ref(false);
    const headers = ref<HeaderDataTable[]>([]);
    const dimensions = ref<DimensionsResponse>({} as DimensionsResponse);
    const request = ref(initDimensionRequest());
    const idDimensionSelected = ref(0);

    const dimensionHeaders = [
      "IdDimension",
      "DimensionName",
      "DimensionCode",
      "BasePrice",
      "IsAvailable",
      "Actions",
    ];

    const getDimensions = async () => {
      dimensions.value = await getAllDimensions();
      isEdit.value = false;
    };

    const selectItem = (item: DimensionRequest) => {
      request.value = item;
      idDimensionSelected.value = item.IdDimension;
      isEdit.value = true;
    };

    const newDimension = () => {
      isEdit.value = false;
      request.value = initDimensionRequest();
    };

    const toogleDimension = async (item: DimensionRequest) => {
      await toogleAvailableDimension(item.IdDimension);
    };

    const deleteDimensionSelected = async (item: DimensionRequest) => {
      await deleteDimension(item.IdDimension);
    };

    const saveDimension = async () => {
      if (isEdit.value) {
        await updateDimension(idDimensionSelected.value, request.value);
      } else {
        await createDimension(request.value);
      }
      request.value = initDimensionRequest();
      await getDimensions();
    };

    const init = async () => {
      headers.value = setHeadersDataTable(dimensionHeaders);
      await getDimensions();
    };

    onMounted(() => init());

    return {
      isEdit,
      headers,
      dimensions,
      request,
      saveDimension,
      selectItem,
      newDimension,
      toogleDimension,
      deleteDimensionSelected,
    };
  },
});
</script>