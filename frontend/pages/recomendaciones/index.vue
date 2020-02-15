<template>
  <v-container>
    <!-- FILA 1 -->
    <v-row align="center" justify="center">
      <v-col cols="12">
        <v-card class="mx-auto">
          <v-img
            class="white--text align-end"
            height="200px"
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
          >
            <v-card-title>{{viajesDestacado.title}}</v-card-title>
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

    <!-- FILA 2 -->
    <v-row>
      <v-col cols="12" lg="6" md="6" sm="12" xs="12" v-for="viaje in viajes2" :key="viaje.id">
        <v-card class="mx-auto">
          <v-img
            class="white--text align-end"
            height="200px"
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
          >
            <v-card-title>{{viaje.title}}</v-card-title>
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

    <!-- FILA 3 -->
    <v-row>
      <v-col cols="12" lg="3" md="3" sm="6" xs="12" v-for="viaje in viajes3" :key="viaje.id">
        <v-card class="mx-auto">
          <v-img
            class="white--text align-end"
            height="200px"
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
          >
            <v-card-title>{{viaje.title}}</v-card-title>
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

<script>
const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "default",
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
