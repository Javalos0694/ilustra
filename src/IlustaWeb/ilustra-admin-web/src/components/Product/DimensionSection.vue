<template>
  <v-card class="px-4">
    <v-card-text>
      <v-row>
        <v-col cols="12">
          <v-card>
            <v-card-title>
              <h3 class="text-grey-darken-1">Dimension</h3>
            </v-card-title>
            <v-card-text>
              <v-col cols="12">
                <dimensionBox
                  :items="dimensions.Dimensions"
                  :itemsSelected="request.Dimensions"
                  @setSelected="setSelected"
                />
              </v-col>
            </v-card-text>
          </v-card>
        </v-col>
      </v-row>
    </v-card-text>
    <v-card-actions class="mt-5">
      <v-row>
        <v-col cols="12">
          <v-btn
            class="bg-cyan-lighten-2 text-grey-lighten-5"
            :disabled="idProductActual == 0"
            @click="saveDimensions"
            >Save</v-btn
          >
        </v-col>
      </v-row>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import { DimensionsResponse } from "@/models/swag-api-response";
import { useDimension } from "@/services/useDimension";
import { computed, defineComponent, onMounted, ref } from "vue";
import dimensionBox from "../base/Inputs/dimension-box.vue";
import { useDimensionProduct } from "@/services/useDimensionProduct";
import { DimensionRequest } from "@/models/swag-api-request";

export default defineComponent({
  name: "DimensionSection",
  components: { dimensionBox },
  props: {
    idProduct: {
      type: Number,
      default: 0,
    },
  },
  setup(props) {
    const { getAllDimensions } = useDimension();
    const {
      initDimensionProductRequest,
      getDimensionsByProduct,
      associateDimensionsByProduct,
    } = useDimensionProduct();

    const idProductActual = computed(() => props.idProduct);
    const isDisabled = ref(false);
    const dimensions = ref<DimensionsResponse>({} as DimensionsResponse);
    const request = ref(initDimensionProductRequest());

    const getDimensions = async () => {
      dimensions.value = await getAllDimensions();
    };

    const getActualDimensionByProduct = async () => {
      let response = await getDimensionsByProduct(idProductActual.value);
      request.value.Dimensions = response.Dimensions;
    };

    const setSelected = (array: DimensionRequest[]) => {
      request.value.Dimensions = [...array];
    };

    const saveDimensions = async () => {
      request.value.IdProduct = idProductActual.value;
      await associateDimensionsByProduct(request.value);
    };

    const init = async () => {
      await getDimensions();
      if (idProductActual.value > 0) {
        request.value.IdProduct = idProductActual.value;
        await getActualDimensionByProduct();
      }
    };

    onMounted(() => init());

    return {
      isDisabled,
      dimensions,
      request,
      idProductActual,
      setSelected,
      saveDimensions,
    };
  },
});
</script>