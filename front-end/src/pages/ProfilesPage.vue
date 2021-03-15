<template>
  <div class="container-fluid" v-if="state.profiles">
    <div class="row mt-5">
      <div class="col-4" v-for="profile in state.profiles" :key="profile.id">
        <profile :profile="profile">
        </profile>
      </div>
    </div>
  </div>
</template>

<script>
import { accountService } from '../services/AccountService'
import { onMounted, reactive, computed } from 'vue'
import { AppState } from '../AppState'
import Profile from '../components/Profile.vue'
export default {
  components: { Profile },
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
