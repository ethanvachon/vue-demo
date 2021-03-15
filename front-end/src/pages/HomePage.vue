<template>
  <div class="container-fluid">
    <div class="row">
      {{ posts }}
      <div class="col-4" v-for="post in state.posts" :key="post.id" :post="post">
      </div>
    </div>
  </div>
</template>

<script>
import { reactive, computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  setup() {
    const state = reactive({
      posts: computed(() => AppState.accounts)
    })
    return {
      state
    }
  }
}
</script>

<style scoped lang="scss">

</style>
