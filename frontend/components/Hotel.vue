<template>
  <v-card class="mx-auto">
          <v-img
            class="white--text align-end"
            height="200px"
            src="https://cdn.vuetifyjs.com/images/cards/docks.jpg"
          >
            <v-card-title>{{hotel.name}}</v-card-title>
          </v-img>

          <v-card-subtitle class="pb-0">Dirección - {{hotel.address}}</v-card-subtitle>

          <v-card-text class="text--primary">
            <div>
              Descripción:
              <p>{{hotel.description}}</p>
            </div>

            <div>Precio: {{hotel.price}}€</div>
          </v-card-text>

          <v-card-actions>
            <v-btn color="orange" text>Ver más</v-btn>
          </v-card-actions>
        </v-card>
</template>

<script>
export default {
  props: ['hotel']
}
</script>
