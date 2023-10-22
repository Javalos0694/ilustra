// Utilities
import { createPinia } from 'pinia'
import piniapluginpersistedstate from 'pinia-plugin-persistedstate'

const pinia = createPinia()
    .use(piniapluginpersistedstate)


export default pinia
