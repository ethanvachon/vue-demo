<template>
  <div class="about" v-if="state.profiles">
    {{ state.profiles }}
  </div>
</template>

<script>
import { accountService } from '../services/AccountService'
import { onMounted, reactive, computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'ProfilesPage',
  setup() {
    const state = reactive({
      profiles: computed(() => AppState.accounts)
    })
    onMounted(async() => {
      await accountService.getProfiles()
    })
    return {
      state
    }
  }
}
</script>
<style scoped>

</style>
