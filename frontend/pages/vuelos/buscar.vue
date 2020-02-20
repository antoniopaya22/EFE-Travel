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

    <!-- FILA GRAFICA -->
    <v-card class="mt-4 mx-auto" max-width="600px">
      <v-sheet
        class="v-sheet--offset mx-auto"
        color="#363636"
        elevation="12"
        max-width="calc(100% - 32px)"
      >
        <v-sparkline
          :labels="meses"
          :value="valoresMeses"
          :gradient="['#f72047', '#ffd200', '#1feaea']"
          line-width="2"
          padding="16"
        ></v-sparkline>
      </v-sheet>

      <v-card-text class="pt-0">
        <div class="title font-weight-light mb-2">Precio de los vuelos para {{this.destino}}</div>
        <div
          class="subheading font-weight-light grey--text"
        >Los precios mostrados en la gráfica son únicamente de las compañías con las que trabaja EFE-Travel.</div>
        <v-divider class="my-2"></v-divider>
        <v-icon class="mr-2" small>mdi-clock</v-icon>
        <span class="caption grey--text font-weight-light">Actualizado ahora</span>
      </v-card-text>
    </v-card>

    <!-- FILA RESULTADOS -->
    <v-row align="center" justify="center" v-for="vuelo in vuelos" :key="vuelo.fechaSalida+vuelo.fechaLlegada">
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
  components: {
    Vuelo
  },
  data: () => ({
    destino: null,
    entrada: null,
    salida: null,
    personas: null,
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
    this.personas = this.$route.query.personas;
    this.salida = this.$route.query.salida;
    this.entrada = this.$route.query.entrada;
    this.origen = this.$route.query.origen;
    this.destino = this.$route.query.destino;
    let vuelosData = await this.$axios.get(
      process.env.REST_URL + `/api/vuelos`,
      {
        headers: { Authorization: this.$store.state.auth},
        params: {
          origin: this.origen,
          destination: this.destino,
          departureDate: this.entrada,
          adults: this.personas
        }
      }
    );
    console.log(vuelosData.data[0])
    this.vuelos = vuelosData.data;
  },
  methods: {}
};
</script>
