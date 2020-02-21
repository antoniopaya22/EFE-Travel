<template>
  <v-container>
    <!-- FILA STEPPER -->
    <v-stepper value="1">
      <v-stepper-header>
        <v-stepper-step step="1">Seleccionar vuelo</v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="2">Introducir datos</v-stepper-step>

        <v-divider></v-divider>

        <v-stepper-step step="3">Completar reserva</v-stepper-step>
      </v-stepper-header>
    </v-stepper>

    <br />

    <!-- FILA RESULTADOS -->
    <v-sheet :color="`grey ${theme.isDark ? 'darken-2' : 'lighten-4'}`" class="px-3 pt-3 pb-3" v-show="loading">
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
  inject: ['theme'],
  components: {
    Vuelo
  },
  data: () => ({
    loading: true,
    meses: [
      "Ene",
      "Feb",
      "Mar",
      "Abr",
      "May",
      "Jun",
      "Jul",
      "Ago",
      "Sep",
      "Oct",
      "Nov",
      "Dic"
    ],
    valoresMeses: [423, 446, 675, 510, 590, 610, 760, 80, 190, 400, 300, 230],
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
