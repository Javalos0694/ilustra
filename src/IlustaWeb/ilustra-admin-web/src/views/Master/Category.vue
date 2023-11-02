<template>
  <titleBack path="/master" title="Categories" />
  <v-divider class="my-5"></v-divider>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-form>
          <v-row>
            <v-col cols="12" md="6">
              <v-text-field
                label="Category"
                v-model="request.Category"
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                label="Description"
                v-model="request.Description"
              ></v-text-field>
            </v-col>
          </v-row>
          <v-row>
            <v-col cols="12">
              <div v-if="isEdit" class="d-flex">
                <v-btn
                  class="bg-grey-darken-4 text-white mr-3"
                  prepend-icon="mdi-plus"
                  @click="newCategory"
                  >New category</v-btn
                >
                <v-btn
                  class="bg-cyan-lighten-2 text-grey-lighten-5 text-white"
                  prepend-icon="mdi-content-save"
                  @click="saveCategory"
                  >Save</v-btn
                >
              </div>
              <v-btn
                v-else
                class="bg-grey-darken-4 text-white"
                prepend-icon="mdi-plus"
                @click="saveCategory"
                >Add category</v-btn
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
        :items="categories.Categories"
        key="IdProductCategory"
        @selectItem="selectItem"
        @deleteItem="deleteItem"
      />
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from "vue";
import { useCategory } from "@/services/useCategory";
import dataTable from "@/components/base/data-table.vue";
import titleBack from "@/components/base/title-back.vue";
import { HeaderDataTable } from "@/models/swag-api-models";
import { setHeadersDataTable } from "@/utils/data-table";
import { CategoriesResponse } from "@/models/swag-api-response";
import { CategoryRequest } from "@/models/swag-api-request";

export default defineComponent({
  name: "Category",
  components: { titleBack, dataTable },
  setup() {
    const {
      initCategoryRequest,
      getAllCategories,
      createCategory,
      updateCategory,
      deleteCategory,
    } = useCategory();

    const isEdit = ref(false);
    const idCategorySelected = ref(0);
    const request = ref(initCategoryRequest());
    const headers = ref<HeaderDataTable[]>([]);
    const categories = ref<CategoriesResponse>({} as CategoriesResponse);
    const categoryHeaders = [
      "IdProductCategory",
      "Category",
      "Description",
      "Actions",
    ];

    const newCategory = () => {
      isEdit.value = false;
      request.value = initCategoryRequest();
    };

    const getCategories = async () => {
      categories.value = await getAllCategories();
      isEdit.value = false;
    };

    const selectItem = (item: CategoryRequest) => {
      request.value = item;
      idCategorySelected.value = item.IdProductCategory;
      isEdit.value = true;
    };

    const saveCategory = async () => {
      if (!isEdit.value) {
        await createCategory(request.value);
      } else {
        await updateCategory(idCategorySelected.value, request.value);
      }
      request.value = initCategoryRequest();
      await getCategories();
    };

    const deleteItem = async (item: CategoryRequest) => {
      await deleteCategory(item.IdProductCategory);
      await getCategories();
    };

    const init = async () => {
      headers.value = setHeadersDataTable(categoryHeaders);
      await getCategories();
    };

    onMounted(() => {
      init();
    });

    return {
      isEdit,
      request,
      headers,
      categories,
      newCategory,
      selectItem,
      saveCategory,
      deleteItem,
    };
  },
});
</script>