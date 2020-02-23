<template>
  <v-card class="mx-auto">
          <v-img
            class="white--text align-end"
            height="200px"
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
          >
            <v-card-title>{{vuelo.Origen}} - {{vuelo.Destino}}</v-card-title>
          </v-img>

          <v-card-subtitle class="pb-0">Salida {{vuelo.FechaSalida}} - Llegada {{vuelo.FechaLlegada}}</v-card-subtitle>

          <v-card-text class="text--primary">
            <div>Compañia: {{vuelo.Aerolinea}}</div>

            <div>Precio: {{vuelo.Precio}}€</div>
          </v-card-text>

          <v-card-actions>
            <v-btn color="orange" text>Ver más</v-btn>

            <v-btn color="orange" text>Ir a la reserva</v-btn>
          </v-card-actions>
        </v-card>
</template>

<script>
export default {
  props: ['vuelo']
}
</script>
