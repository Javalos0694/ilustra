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
                      v-model="request.ProductName"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="6">
                    <v-text-field
                      label="Description"
                      v-model="request.Description"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="6">
                    <v-text-field
                      label="BasePrice"
                      v-model="request.BasePrice"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" md="6">
                    <!-- <v-select
                      label="Category"
                      :items="categories.Categories"
                      item-value="IdProductCategory"
                      item-title="Category"
                      v-model="request.IdProductCategory"
                    ></v-select> -->
                    <inputSelect
                      :items="categories.Categories"
                      keyValue="Category"
                      value="IdProductCategory"
                      label="Category"
                      :valueSelected="request.IdProductCategory"
                      @setItemSelected="setItemSelected"
                    />
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
                <v-btn
                  class="bg-cyan-lighten-2 text-grey-lighten-5"
                  @click="saveProduct"
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
        <ColorSection :idProduct="idProduct" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import {
  CategoriesResponse,
  ProductResponse,
} from "@/models/swag-api-response";
import router from "@/router";
import { useProduct } from "@/services/useProduct";
import { defineComponent, onMounted, ref } from "vue";

import titleBack from "@/components/base/title-back.vue";
import inputSelect from "@/components/base/Inputs/input-select.vue";
import ColorBox from "@/components/base/Inputs/color-box.vue";
import ColorSection from "@/components/Product/ColorSection.vue";
import { useCategory } from "@/services/useCategory";

export default defineComponent({
  name: "ProductDetail",
  components: { titleBack, ColorBox, ColorSection, inputSelect },
  setup() {
    const {
      getProductById,
      createProduct,
      initProductRequest,
      updateProductById,
    } = useProduct();
    const { getAllCategories } = useCategory();

    const idProduct = ref(0);
    const isEdit = ref(false);
    const product = ref<ProductResponse>({} as ProductResponse);
    const request = ref(initProductRequest());
    const categories = ref<CategoriesResponse>({} as CategoriesResponse);

    const getProductDetail = async () => {
      product.value = await getProductById(idProduct.value);
    };

    const setRequest = () => {
      Object.assign(request.value, product.value);
    };

    const saveProduct = async () => {
      if (!isEdit.value) {
        const response = await createProduct(request.value);
        idProduct.value = response.Id;
      } else {
        await updateProductById(idProduct.value, request.value);
      }
    };

    const setCategories = async () => {
      categories.value = await getAllCategories();
    };

    const setItemSelected = (id: any) => {
      request.value.IdProductCategory = id;
    };

    const init = async () => {
      idProduct.value =
        Number.parseInt(router.currentRoute.value.params.id.toString()) || 0;
      setCategories();
      if (idProduct.value != 0) {
        await getProductDetail();
        setRequest();
        isEdit.value = true;
      }
    };

    onMounted(() => {
      init();
    });

    return {
      idProduct,
      product,
      request,
      categories,
      saveProduct,
      setItemSelected,
    };
  },
});
</script>