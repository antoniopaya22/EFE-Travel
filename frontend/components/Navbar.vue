<template>
  <div>
    <v-navigation-drawer
      v-model="drawer"
      clipped
      app
      v-if="this.$store.state.auth"
    >
      <v-list dense>
        <template v-for="item in items">
          <v-list-item :key="item.text">
            <v-list-item-action>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-action>
            <v-list-item-content>
              <v-list-item-title><v-btn text small :href="item.href">{{ item.text }}</v-btn></v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </template>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar :clipped-left="$vuetify.breakpoint.lgAndUp" app color="primary" dark>
      <v-toolbar-title style="width: 300px" class="ml-0 pl-3">
        <v-app-bar-nav-icon @click.stop="drawer = !drawer" v-if="this.$store.state.auth"></v-app-bar-nav-icon>
        <v-btn text large to="/">EFE-Forms</v-btn>
      </v-toolbar-title>
      <v-autocomplete
        v-model="select"
        :loading="loading"
        :items="destinos"
        :search-input.sync="search"
        append-icon="mdi-magnify"
        cache-items
        flat
        hide-no-data
        hide-details
        label="Busca un destino"
        class="hidden-sm-and-down"
        solo-inverted
      ></v-autocomplete>
      <v-spacer></v-spacer>
      <v-menu
        bottom left
        offset-y
        open-on-hover
        v-if="this.$store.state.auth">
        <template v-slot:activator="{ on }">
          <v-btn dark icon v-on="on">
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </template>

        <v-list>

          <v-list-item>
              <v-list-item-icon>
                <v-icon>mdi-account-circle</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-btn text to="/perfil">Perfil</v-btn>
              </v-list-item-content>
          </v-list-item>

          <v-list-item>
              <v-list-item-icon>
                <v-icon>mdi-logout-variant</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-btn text @click="logout()">Cerrar sesión</v-btn>
              </v-list-item-content>
          </v-list-item>

        </v-list>
      </v-menu>
      <div v-else>
        <v-btn text large to="/register">Regístrate</v-btn>
        <v-btn text large to="/login">Inicia Sesión</v-btn>
      </div>
    </v-app-bar>
  </div>
</template>


<script>
const Cookie = process.client ? require('js-cookie') : undefined

export default {
  data: () => ({
    dialog: false,
    drawer: null,
    loading: false,
    search: null,
    select: null, //Elemento seleccionado
    destinos: ["Madrid", "NewYork", "Osaka", "San Petesburgo"],
    items: [
      { icon: "mdi-airplane", text: "Vuelos", href: "/vuelos"},
      { icon: "mdi-earth", text: "Vuelo + Hotel", href: "/vuelohotel" },
      { icon: "mdi-bunk-bed", text: "Hoteles", href: "/hoteles" },
      { icon: "mdi-check-decagram", text: "Recomendaciones", href: "/recomendaciones" },
    ]
  }),
  watch: {
    search(val) {
      val && val !== this.select && this.querySelections(val);
    }
  },
  methods: {
    querySelections(v) {
      this.loading = true;
      // Simulated ajax query
      setTimeout(() => {
        this.items = this.destinos.filter(e => {
          return (e || "").toLowerCase().indexOf((v || "").toLowerCase()) > -1;
        });
        this.loading = false;
      }, 500);
    },
    logout () {
      Cookie.remove('auth')
      this.$store.commit('setAuth', null)
      this.$router.push('/login')
    }
  }
};
</script>
