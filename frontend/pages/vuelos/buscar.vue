<template>
  <v-container>
    <!-- FILA RESULTADOS -->
    <v-sheet
      :color="`grey ${theme.isDark ? 'darken-2' : 'lighten-4'}`"
      class="px-3 pt-3 pb-3"
      v-show="loading"
    >
      Cargando Resultados ...
      <v-skeleton-loader class="mx-auto" max-width="300" type="card"></v-skeleton-loader>
    </v-sheet>
    <v-row
      align="center"
      justify="center"
      v-for="vuelo in vuelos"
      :key="vuelo.fechaSalida+vuelo.fechaLlegada"
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

const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "color",
  inject: ["theme"],
  middleware: "authenticated",
  components: {
    Vuelo
  },
  data: () => ({
    loading: true,
    vuelos: []
  }),
  async mounted() {
    let vuelosData = await this.$axios.get(
      process.env.REST_URL + `/api/vuelos`,
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
    this.vuelos = vuelosData.data;
    this.loading = false;
  },
  methods: {}
};
</script>
