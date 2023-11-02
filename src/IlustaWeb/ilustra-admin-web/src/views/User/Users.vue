<template>
  <h1>Users</h1>
  <v-divider class="mb-4"></v-divider>
  <Datatable
    :headers="headers"
    :items="users.Users"
    key="IdUser"
    :loading="loadingData"
    @selectItem="selectUser"
    @deleteItem="deleteUserSelected"
  />
  <DetailUser
    :id="idUserSelected"
    :show="showDialog"
    @closeDialog="closeDialog"
  />
</template>

<script lang="ts">
import { UserResponse, UsersResponse } from "@/models/swag-api-response";
import { useUser } from "@/services/useUser";
import { defineComponent, onMounted, ref } from "vue";

import Datatable from "@/components/base/data-table.vue";
import { HeaderDataTable } from "@/models/swag-api-models";

import { setHeadersDataTable } from "@/utils/data-table";
import DetailUser from "@/components/User/Detail.vue";

export default defineComponent({
  name: "Users",
  components: { Datatable, DetailUser },
  setup() {
    const { getUsers, deleteUser } = useUser();
    const loadingData = ref(false);

    const headers = ref<HeaderDataTable[]>([]);
    const users = ref<UsersResponse>({} as UsersResponse);

    const idUserSelected = ref(0);
    const showDialog = ref(false);

    const userHeaders = ["IdUser", "UserType", "Username", "Actions"];

    const selectUser = (item: UserResponse) => {
      idUserSelected.value = item.IdUser;
      showDialog.value = true;
    };

    const closeDialog = () => (showDialog.value = false);

    const deleteUserSelected = async (item: UserResponse) => {
      await deleteUser(item.IdUser);
    };

    const getAllUsers = async () => {
      loadingData.value = true;
      users.value = await getUsers();
      loadingData.value = false;
    };

    const init = async () => {
      await getAllUsers();
      headers.value = setHeadersDataTable(userHeaders);
    };

    onMounted(async () => {
      init();
    });

    return {
      users,
      headers,
      loadingData,
      idUserSelected,
      showDialog,
      selectUser,
      deleteUserSelected,
      closeDialog,
    };
  },
});
</script>