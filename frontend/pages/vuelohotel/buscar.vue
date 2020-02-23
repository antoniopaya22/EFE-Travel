<template>
  <v-container>
    <!-- FILA STEPPER -->
    <v-stepper :value="paso">
      <v-stepper-header>
        <v-stepper-step step="1">Seleccionar vuelo</v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="2">Seleccionar hotel</v-stepper-step>
      </v-stepper-header>
    </v-stepper>

    <br />

    <!-- FILA RESULTADOS -->
    <v-sheet
      :color="`grey ${theme.isDark ? 'darken-2' : 'lighten-4'}`"
      class="px-3 pt-3 pb-3"
      v-show="loading"
    >
      Cargando Resultados ...
      <v-skeleton-loader class="mx-auto" max-width="300" type="card"></v-skeleton-loader>
    </v-sheet>
    <div v-if="paso == 1">
      <v-btn @click="verHoteles()">Ver hoteles</v-btn>
      <v-row
        align="center"
        justify="center"
        v-for="(vuelo, index) in vuelos"
        :key="`vuelo-${index}`"
      >
        <v-col cols="12">
          <Vuelo :vuelo="vuelo" />
        </v-col>
      </v-row>
      <div v-if="!loading && vuelos.length == 0">
        <br />
        <v-card>
          <v-card-title>Sin coincidencias</v-card-title>
          <v-card-text>Lo sentimos mucho, no hay resultados para estas fechas</v-card-text>
        </v-card>
      </div>
    </div>
    <div v-else>
      <v-btn @click="verVuelos()">Ver vuelos</v-btn>
      <v-row
        align="center"
        justify="center"
        v-for="(hotel, index) in hoteles"
        :key="`hotel-${index}`"
      >
        <v-col cols="12">
          <Hotel :hotel="hotel" />
        </v-col>
      </v-row>
      <div v-if="!loading && hoteles.length == 0">
        <br />
        <v-card>
          <v-card-title>Sin coincidencias</v-card-title>
          <v-card-text>Lo sentimos mucho, no hay resultados para estas fechas</v-card-text>
        </v-card>
      </div>
    </div>
  </v-container>
</template>

<style>
.v-sheet--offset {
  top: -24px;
  position: relative;
}
</style>

<script>
import Vuelo from "~/components/Vuelo";
import Hotel from "~/components/Hotel";

const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "color",
  inject: ["theme"],
  middleware: "authenticated",
  components: {
    Vuelo,
    Hotel
  },
  data: () => ({
    loading: true,
    paso: 1,
    vuelos: [],
    hoteles: []
  }),
  async mounted() {
    let vuelosData = await this.$axios.get(
      process.env.REST_URL + `/api/vueloshoteles`,
      {
        headers: { Authorization: this.$store.state.auth },
        params: {
          origen: this.$route.query.origen,
          destino: this.$route.query.destino,
          fechaEntrada: this.$route.query.entrada,
          fechaSalida: this.$route.query.salida,
          personas: this.$route.query.personas
        }
      }
    );
    this.vuelos = vuelosData.data.vuelos;
    this.hoteles = vuelosData.data.hoteles;
    this.loading = false;
  },
  methods: {
    verHoteles() {
      this.paso = 2;
    },
    verVuelos() {
      this.paso = 1;
    }
  }
};
</script>
