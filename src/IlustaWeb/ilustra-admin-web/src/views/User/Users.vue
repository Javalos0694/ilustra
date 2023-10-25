<template>
  <h1>Users</h1>
  <v-divider class="mb-4"></v-divider>
  <Datatable
    :headers="headers"
    :items="users.Users"
    key="IdUser"
    :loading="loadingData"
  />
</template>

<script lang="ts">
import { UsersResponse } from "@/models/swag-api-response";
import { useUser } from "@/services/useUser";
import { defineComponent, onMounted, ref } from "vue";

import Datatable from "@/components/base/data-table.vue";
import { AlignHeader, HeaderDataTable } from "@/models/swag-api-models";

import { setHeadersDataTable } from "@/utils/data-table";

export default defineComponent({
  name: "Users",
  components: { Datatable },
  setup() {
    const { getUsers } = useUser();
    const loadingData = ref(false);

    const headers = ref<HeaderDataTable[]>([]);
    const users = ref<UsersResponse>({} as UsersResponse);

    const userHeaders = ["IdUser", "UserType", "Username", "Actions"];

    onMounted(async () => {
      loadingData.value = true;
      users.value = await getUsers();
      headers.value = setHeadersDataTable(userHeaders, AlignHeader.Center);
      loadingData.value = false;
    });

    return {
      users,
      headers,
      loadingData,
    };
  },
});
</script>