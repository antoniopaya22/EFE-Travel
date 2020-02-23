<template>
  <v-container>
    <!-- FILA 1 -->
    <v-row align="center" justify="center">
      <v-col cols="12">
        <Recomendacion :recomendacion="viajesDestacado" />
      </v-col>
    </v-row>

    <!-- FILA 2 -->
    <v-row>
      <v-col cols="12" lg="6" md="6" sm="12" xs="12" v-for="viaje in viajes2" :key="viaje.destino+viaje.precio">
        <Recomendacion :recomendacion="viaje" />
      </v-col>
    </v-row>

    <!-- FILA 3 -->
    <v-row>
      <v-col cols="12" lg="3" md="3" sm="6" xs="12" v-for="viaje in viajes3" :key="viaje.destino+viaje.precio">
        <Recomendacion :recomendacion="viaje" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Recomendacion from '~/components/Recomendacion'


const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "color",
  components: {
    Recomendacion
  },
  data: () => ({
    viajesDestacado: { origen: "Cargando", destino: "Recomendaciones ...", fecha_salida: "Cargando fechas ..." },
    viajes2: [],
    viajes3: [],
  }),
  async mounted() {
    this.$axios.get(
      process.env.REC_URL + '/api/recomendaciones/MAD'
    ).then(viajes => {
      this.viajesDestacado = viajes.data.principal;
      this.viajes2 = viajes.data.secundaria;
      this.viajes3 = viajes.data.terciarias;
    }).catch(error => console.log(error));
    this.loading = false;
  },
  methods: {}
};
</script>
