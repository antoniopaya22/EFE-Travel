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
      <v-col cols="12" lg="6" md="6" sm="12" xs="12" v-for="viaje in viajes2" :key="viaje.id">
        <Recomendacion :recomendacion="viaje" />
      </v-col>
    </v-row>

    <!-- FILA 3 -->
    <v-row>
      <v-col cols="12" lg="3" md="3" sm="6" xs="12" v-for="viaje in viajes3" :key="viaje.id">
        <Recomendacion :recomendacion="viaje" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Recomendacion from '~/components/Recomendacion'


const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "default",
  components: {
    Recomendacion
  },
  data: () => ({
    viajesDestacado: { id: "1", title: "Viaje 1" },
    viajes2: [
      { id: "1", title: "Viaje 1" },
      { id: "2", title: "Viaje 2" },
    ],
    viajes3: [
      { id: "1", title: "Viaje 1" },
      { id: "2", title: "Viaje 2" },
      { id: "3", title: "Viaje 3" },
      { id: "4", title: "Viaje 4" }
    ]
  }),
  methods: {}
};
</script>
