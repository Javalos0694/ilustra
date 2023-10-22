// Utilities
import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useAuthStore = defineStore('auth', () => {
  const usernameStored = ref("");
  const tokenStored = ref("");

  const setStoredValues = ({ Username = "", token = "" }) => {
    usernameStored.value = Username;
    tokenStored.value = token;
  }

  return { usernameStored, tokenStored, setStoredValues }

}, { persist: true })
