<template>
  <v-app dark class="trans">
    <Navbar />
    <v-content class="bgimg">
      <v-container class="fill-height">
        <nuxt />
      </v-container>
    </v-content>
    <Footer/>
  </v-app>
</template>

<script>
import Navbar from "~/components/Navbar";
import Footer from '~/components/Footer';

export default {
  layout: "empty",
  components: {
    Navbar,
    Footer
  }
};
</script>

<style scoped>
.trans {
  background-color: transparent;
}

.bgimg {
  background-image: url("~assets/login-background.jpg");
  background-repeat: no-repeat;
  background-size: 100% 100%;
}
</style>
