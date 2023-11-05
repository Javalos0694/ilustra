<template>
  <v-card class="px-4">
    <v-card-text>
      <v-row>
        <v-col cols="12" md="6">
          <v-card>
            <v-card-title>
              <h3 class="text-grey-darken-1">Colors</h3>
            </v-card-title>
            <v-card-text>
              <v-col cols="12">
                <ColorBox
                  :items="colors.Colors"
                  :itemsSelected="request.Colors"
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
            @click="saveColors"
            :disabled="idActualProduct == 0"
            >Save</v-btn
          >
        </v-col>
      </v-row>
    </v-card-actions>
  </v-card>
</template>


<script lang="ts">
import { ColorRequest } from "@/models/swag-api-request";
import { ColorsResponse } from "@/models/swag-api-response";
import { useColorProduct } from "@/services/useColorProduct";
import { useColor } from "@/services/useColor";
import { computed, defineComponent, onMounted, ref } from "vue";
import ColorBox from "../base/Inputs/color-box.vue";

export default defineComponent({
  name: "ColorSection",
  components: { ColorBox },
  props: {
    idProduct: {
      type: Number,
      default: 0,
    },
  },
  setup(props) {
    const { getColors } = useColor();
    const {
      createColorByProduct,
      initColorProductRequest,
      getColorsByProduct,
    } = useColorProduct();

    const idActualProduct = computed(() => props.idProduct);
    const colors = ref<ColorsResponse>({} as ColorsResponse);
    const request = ref(initColorProductRequest());

    const getAllColors = async () => {
      colors.value = await getColors();
    };

    const setSelected = (array: ColorRequest[]) => {
      request.value.Colors = [...array];
    };

    const colorsByProduct = async () => {
      let response = await getColorsByProduct(idActualProduct.value);
      request.value.Colors = response.Colors;
    };

    const saveColors = async () => {
      request.value.IdProduct = idActualProduct.value;
      await createColorByProduct(request.value);
    };

    const init = async () => {
      await getAllColors();
      if (idActualProduct.value != 0) {
        request.value.IdProduct = idActualProduct.value;
        await colorsByProduct();
      }
    };

    onMounted(() => init());

    return {
      colors,
      request,
      idActualProduct,
      setSelected,
      saveColors,
    };
  },
});
</script>