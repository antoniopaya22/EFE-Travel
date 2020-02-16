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

    <br>


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
    <v-row align="center" justify="center" v-for="vuelo in vuelos" :key="vuelo.id">
      <v-col cols="12">
        <v-card class="mx-auto">
          <v-img
            class="white--text align-end"
            height="200px"
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
          >
            <v-card-title>{{vuelo.title}}</v-card-title>
          </v-img>

          <v-card-subtitle class="pb-0">Number 10</v-card-subtitle>

          <v-card-text class="text--primary">
            <div>Whitehaven Beach</div>

            <div>Whitsunday Island, Whitsunday Islands</div>
          </v-card-text>

          <v-card-actions>
            <v-btn color="orange" text>Share</v-btn>

            <v-btn color="orange" text>Explore</v-btn>
          </v-card-actions>
        </v-card>
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
const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "default",
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
    vuelos: [
      { id: "1", title: "Viaje 1" },
      { id: "2", title: "Viaje 2" },
      { id: "3", title: "Viaje 3" },
      { id: "4", title: "Viaje 4" }
    ]
  }),
  mounted() {
    console.log(this.$route.query);
    this.personas = this.$route.query.personas;
    this.salida = this.$route.query.salida;
    this.entrada = this.$route.query.entrada;
    this.origen = this.$route.query.origen;
    this.destino = this.$route.query.destino;
  },
  methods: {}
};
</script>
