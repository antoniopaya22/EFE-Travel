<template>
  <v-container>

    <!-- FILA RESULTADOS -->
    <v-sheet :color="`grey ${theme.isDark ? 'darken-2' : 'lighten-4'}`" class="px-3 pt-3 pb-3" v-show="loading">
      Cargando Resultados ...
      <v-skeleton-loader class="mx-auto" max-width="300" type="card"></v-skeleton-loader>
    </v-sheet>
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
  </v-container>
</template>

<style>
.v-sheet--offset {
  top: -24px;
  position: relative;
}
</style>

<script>
import Hotel from "~/components/Hotel";

const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "color",
  inject: ['theme'],
  components: {
    Hotel
  },
  data: () => ({
    loading: true,
    hoteles: []
  }),
  async mounted() {
    let hotelesData = await this.$axios.get(
      process.env.REST_URL + `/api/hoteles`,
      {
        headers: { Authorization: this.$store.state.auth },
        params: {
          ciudad: this.$route.query.destino,
          fechaSalida: this.$route.query.entrada,
          fechaLlegada: this.$route.query.salida,
          personas: this.$route.query.personas
        }
      }
    );
    this.hoteles = hotelesData.data;
    this.loading = false;
  },
  methods: {}
};
</script>
