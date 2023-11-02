<template>
  <v-layout>
    <v-navigation-drawer
      :v-model="drawer"
      :rail="rail"
      permanent
      :class="['side-bar']"
      @click="rail = false"
    >
      <v-list-item
        prepend-avatar="https://randomuser.me/api/portraits/men/85.jpg"
        title="Joseph"
        nav
      >
        <template v-slot:append>
          <v-btn
            variant="text"
            icon="mdi-chevron-left"
            @click.stop="rail = !rail"
          ></v-btn>
        </template>
      </v-list-item>
      <v-divider></v-divider>
      <v-list density="compact" nav>
        <v-list-item
          prepend-icon="mdi-home-city"
          title="Home"
          value="home"
          @click="goToView('/')"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-account"
          title="My Account"
          value="account"
          @click="goToView('/account')"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-account-group-outline"
          title="Users"
          value="users"
          @click="goToView('/users')"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-bus-double-decker"
          title="Products"
          value="products"
          @click="goToView('/products')"
        ></v-list-item>
        <v-list-item
          prepend-icon="mdi-cogs"
          title="Master"
          value="master"
          @click="goToView('/master')"
        ></v-list-item>
      </v-list>
      <template v-slot:append>
        <v-list density="compact" nav>
          <v-list-item
            prepend-icon="mdi-logout"
            title="Logout"
            value="logout"
            @click.capture="logout"
          >
          </v-list-item>
        </v-list>
      </template>
    </v-navigation-drawer>
    <v-main></v-main>
  </v-layout>
</template>

<script lang="ts">
import router from "@/router";
import { useAuthStore } from "@/store/auth";
import { defineComponent, ref } from "vue";

export default defineComponent({
  name: "sidebar",
  setup() {
    const drawer = ref(true);
    const rail = ref(true);

    const { setStoredValues } = useAuthStore();

    const goToView = (path: string) => {
      if (!rail.value) router.push(path);
    };

    const logout = () => {
      if (!rail.value) {
        setStoredValues({});
        router.push({ name: "Login" });
      }
    };

    return {
      drawer,
      rail,
      logout,
      goToView,
    };
  },
});
</script>