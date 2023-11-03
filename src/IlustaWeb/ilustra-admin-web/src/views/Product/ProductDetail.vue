<template>
  <titleBack
    path="/products"
    :title="idProduct != 0 ? 'Product detail' : 'Create Product'"
  />
  <v-divider class="mb-4"></v-divider>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-card class="px-4">
          <v-card-title class="mb-2">
            <h3 class="text-grey-darken-1">Details</h3>
          </v-card-title>
          <v-card-text>
            <v-row>
              <v-col cols="12" md="6">
                <v-row>
                  <v-col cols="12" md="6">
                    <v-text-field
                      label="ProductName"
                      v-model="product.ProductName"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="6">
                    <v-text-field
                      label="Description"
                      v-model="product.Description"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="6">
                    <v-text-field
                      label="BasePrice"
                      v-model="product.BasePrice"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="6">
                    <v-text-field
                      label="ProductCategory"
                      v-model="product.IdProductCategory"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-col>
              <v-col cols="12" md="6">
                <v-col cols="12">
                  <h4>Image</h4>
                </v-col>
                <v-col cols="12"></v-col>
              </v-col>
            </v-row>
          </v-card-text>
          <v-card-actions>
            <v-row>
              <v-col cols="12">
                <v-btn class="bg-cyan-lighten-2 text-grey-lighten-5"
                  >Save</v-btn
                >
              </v-col>
            </v-row>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
    <v-divider class="my-5"></v-divider>
    <v-row>
      <v-col cols="12">
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
                <v-btn class="bg-cyan-lighten-2 text-grey-lighten-5"
                  >Save</v-btn
                >
              </v-col>
            </v-row>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import {
  ColorResponse,
  ColorsResponse,
  ProductResponse,
} from "@/models/swag-api-response";
import router from "@/router";
import { useColor } from "@/services/useColor";
import { useProduct } from "@/services/useProduct";
import { defineComponent, onMounted, ref } from "vue";

import titleBack from "@/components/base/title-back.vue";
import ColorBox from "@/components/base/Inputs/color-box.vue";

export default defineComponent({
  name: "ProductDetail",
  components: { titleBack, ColorBox },
  setup() {
    const idProduct = ref(0);
    const product = ref<ProductResponse>({} as ProductResponse);
    const colors = ref<ColorsResponse>({} as ColorsResponse);
    const colorsSelected = ref<ColorResponse[]>([]);

    const { getProductById } = useProduct();
    const { getColors } = useColor();

    const getProductDetail = async () => {
      product.value = await getProductById(idProduct.value);
    };

    const getAllColors = async () => {
      colors.value = await getColors();
    };

    const setSelected = (arraySelected: any[]) => {
      colorsSelected.value = [...arraySelected];
    };

    const init = () => {
      idProduct.value =
        Number.parseInt(router.currentRoute.value.params.id.toString()) || 0;
      if (idProduct.value != 0) getProductDetail();
      getAllColors();
    };

    onMounted(() => {
      init();
    });

    return {
      idProduct,
      product,
      colors,
      colorsSelected,
      setSelected,
    };
  },
});
</script>