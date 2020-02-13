<template>
  <v-app dark class="trans">
    <v-content class="bgimg">
      <nuxt />
    </v-content>
    <v-footer padless>
    <v-col
      class="text-center"
      cols="12"
    >
      {{ new Date().getFullYear() }} — <strong>Antonio Payá González</strong>
    </v-col>
  </v-footer>
  </v-app>
</template>

<script>
export default {
  layout: "empty"
};
</script>

<style scoped>
.trans{
  background-color: transparent;
}

.bgimg {
  background-image: url("~assets/login-background.jpg");
  background-repeat: no-repeat;
  background-size: 100% 100%;
}
</style>
