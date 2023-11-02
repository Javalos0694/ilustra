<template>
  <v-dialog max-width="1024" v-model="isShowed">
    <v-card>
      <v-card-title>
        <h5>User detail</h5>
      </v-card-title>
      <v-card-text>
        <v-container>
          <v-row>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="FirstName"
                v-model="userResponse.FirstName"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="LastName"
                v-model="userResponse.LastName"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="UserType"
                v-model="userResponse.UserType"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="DocumentType"
                v-model="userResponse.DocumentType"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="DocumentNumber"
                v-model="userResponse.DocumentNumber"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                type="Email"
                label="Email"
                v-model="userResponse.Email"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="Address"
                v-model="userResponse.Address"
              ></v-text-field>
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <InputDate
                label="BornDate"
                :date="userResponse.BornDate"
                @setDate="setDate"
              />
            </v-col>
            <v-col cols="12" sm="6" md="4">
              <v-text-field
                label="PhoneNumber"
                v-model="userResponse.PhoneNumber"
              ></v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-row justify="end" class="mr-5">
          <v-btn class="bg-grey-darken-4" @click="closeDialog">Cancel</v-btn>
          <v-btn class="bg-cyan-lighten-2 text-grey-lighten-5">Save</v-btn>
        </v-row>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { PersonResponse } from "@/models/swag-api-response";
import { useUser } from "@/services/useUser";
import { computed, defineComponent, watch, ref } from "vue";

import InputDate from "../base/Inputs/input-date.vue";

export default defineComponent({
  name: "Detail",
  components: { InputDate },
  emits: ["closeDialog"],
  props: {
    id: {
      type: Number,
      default: 0,
    },
    show: {
      type: Boolean,
      default: false,
    },
  },
  setup(props, { emit }) {
    const { getUserById } = useUser();

    const idUser = computed(() => props.id);
    const isShowed = computed(() => props.show);
    const userResponse = ref<PersonResponse>({} as PersonResponse);

    const setDate = (nDate: string) => {
      userResponse.value.BornDate = nDate;
      console.log(nDate);
    };

    const closeDialog = () => {
      emit("closeDialog");
    };

    const init = async () => {
      userResponse.value = await getUserById(idUser.value);
    };

    watch(isShowed, () => {
      if (isShowed.value) {
        init();
      }
    });

    return {
      userResponse,
      isShowed,
      setDate,
      closeDialog,
    };
  },
});
</script>