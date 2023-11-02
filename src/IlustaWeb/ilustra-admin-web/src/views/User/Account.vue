<template>
  <h1>User detail</h1>
  <v-divider class="mb-4"></v-divider>
  <v-form>
    <v-row>
      <v-col cols="12" sm="6" md="4">
        <v-text-field label="FirstName" v-model="user.FirstName"></v-text-field>
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <v-text-field label="LastName" v-model="user.LastName"></v-text-field>
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <v-text-field label="UserType" v-model="user.UserType"></v-text-field>
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <v-text-field
          label="DocumentType"
          v-model="user.DocumentType"
        ></v-text-field>
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <v-text-field
          label="DocumentNumber"
          v-model="user.DocumentNumber"
        ></v-text-field>
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <v-text-field
          type="Email"
          label="Email"
          v-model="user.Email"
        ></v-text-field>
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <v-text-field label="Address" v-model="user.Address"></v-text-field>
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <InputDate label="BornDate" :date="user.BornDate" @setDate="setDate" />
      </v-col>
      <v-col cols="12" sm="6" md="4">
        <v-text-field
          label="PhoneNumber"
          v-model="user.PhoneNumber"
        ></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <v-btn
          class="bg-cyan-lighten-2 text-grey-lighten-5"
          @click="onSubmitChanges"
          :loading="btnStatus"
          >Save</v-btn
        >
      </v-col>
    </v-row>
  </v-form>
</template>

<script lang="ts">
import { PersonResponse } from "@/models/swag-api-response";
import { useUser } from "@/services/useUser";
import { defineComponent, onMounted, ref } from "vue";
import InputDate from "@/components/base/Inputs/input-date.vue";
import { UpdatePersonRequest } from "@/models/swag-api-request";

export default defineComponent({
  name: "Account",
  components: { InputDate },
  setup() {
    const { getUserAccount, putUserById, initUpdateUserRequest } = useUser();
    const user = ref<PersonResponse>({} as PersonResponse);
    const request = ref<UpdatePersonRequest>(initUpdateUserRequest());
    const btnStatus = ref(false);

    const setRequest = () => {
      request.value = Object.fromEntries(
        Object.entries(user.value).map(([key, val]) => {
          if (Object.hasOwn(request.value, key)) {
            return [key, val];
          }
          return [];
        })
      );
    };

    const onSubmitChanges = async () => {
      setRequest();
      btnStatus.value = true;
      await putUserById(user.value.IdUser, request.value);
      btnStatus.value = false;
    };

    const setDate = (nDate: string) => {
      user.value.BornDate = nDate;
    };

    onMounted(async () => {
      try {
        user.value = await getUserAccount();
      } catch (error) {
        console.log(error);
      }
    });

    return { user, btnStatus, setDate, onSubmitChanges };
  },
});
</script>