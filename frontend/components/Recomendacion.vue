<template>
  <v-card class="mx-auto" color="#363636">
    <v-img
      class="white--text align-end"
      height="200px"
      :src="img"
    >
      <v-card-title>{{recomendacion.origen}} - {{recomendacion.destino}}</v-card-title>
    </v-img>

    <v-card-subtitle class="pb-0">Fechas: {{recomendacion.fecha_salida}} - {{recomendacion.fecha_llegada}}</v-card-subtitle>

    <v-card-text class="text--primary">
      <div>Precio: {{recomendacion.precio}}€</div>
    </v-card-text>

    <v-card-actions>
      <v-btn color="orange" text>Saber mas</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  props: ["recomendacion"],
  data: () => ({
    locations: [],
    img: 'https://cdn.vuetifyjs.com/images/cards/docks.jpg'
  }),
  async mounted() {
    let destinos = await this.$axios.get(
      process.env.REST_URL + "/api/locations"
    );
    this.locations = destinos.data;
    let img = this.locations.find(x => x.code == this.recomendacion.destino);
    if(img){
      this.img = img.img;
    }
  }
};
</script>
