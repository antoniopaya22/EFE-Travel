<template>
  <v-container>
    <v-card class="mx-auto"></v-card>
  </v-container>
</template>

<script>
const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "default",
  data: () => ({
    destino: null,
    entrada: null,
    salida: null,
    personas: null
  }),
  mounted() {
    console.log(this.$route.query)
    this.personas = this.$route.query.personas;
    this.salida = this.$route.query.salida;
    this.entrada = this.$route.query.entrada;
    this.destino = this.$route.query.destino;
  },
  methods: {}
};
</script>
