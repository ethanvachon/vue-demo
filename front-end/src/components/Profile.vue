<template>
  <div class="card">
    <div class="card-body d-flex align-items-center justify-content-around">
      <img class="rounded-circle" :src="profile.picture" alt="">
      <p class="card-title">
        {{ profile.name }}
      </p>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    profile: {
      type: Object,
      required: true
    }
  }
}
</script>
<style scoped>
img {
  height: 50px;
  width: 50px;
}
</style>
