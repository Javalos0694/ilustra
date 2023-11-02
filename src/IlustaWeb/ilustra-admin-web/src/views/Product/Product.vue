<template>
  <h1>Products</h1>
  <v-divider class="mb-4"></v-divider>
  <v-row class="my-5">
    <v-col cols="12" class="d-flex justify-md-end">
      <v-btn
        prepend-icon="mdi-plus-circle-outline"
        class="bg-grey-darken-4 mr-5"
        @click="goToNewProduct"
        >New Product</v-btn
      >
    </v-col>
  </v-row>
  <dataTable :headers="headers" :items="products.Products" key="IdProduct" />
</template>

<script lang="ts">
import { HeaderDataTable } from "@/models/swag-api-models";
import { ProductsResponse } from "@/models/swag-api-response";
import { useProduct } from "@/services/useProduct";
import { setHeadersDataTable } from "@/utils/data-table";
import { defineComponent, onMounted, ref } from "vue";

import dataTable from "@/components/base/data-table.vue";
import router from "@/router";

export default defineComponent({
  name: "Product",
  components: { dataTable },
  setup() {
    const { getProducts } = useProduct();

    const products = ref<ProductsResponse>({} as ProductsResponse);
    const headers = ref<HeaderDataTable[]>([]);
    const productHeaders = [
      "IdColor",
      "ColorName",
      "ColorCode",
      "BasePrice",
      "IsAvailable",
      "Actions",
    ];

    const goToNewProduct = () => {
      router.push("/products/detail");
    };

    onMounted(async () => {
      products.value = await getProducts();
      headers.value = setHeadersDataTable(productHeaders);
    });

    return {
      products,
      headers,
      goToNewProduct,
    };
  },
});
</script>