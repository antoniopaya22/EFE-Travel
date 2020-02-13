<template>
    <v-row class="fill-height" align="center" justify="center">
      <v-col cols="12" sm="8" md="4">
        <v-card class="elevation-12">
          <v-alert type="error" :message="error" v-if="error" dismissible>{{error}}</v-alert>
          <v-form @submit.prevent="login()">
            <v-toolbar color="primary" dark flat>
              <v-toolbar-title>Iniciar sesión</v-toolbar-title>
              <v-spacer />
            </v-toolbar>
            <v-card-text>
              <v-text-field
                label="Usuario"
                v-model="username"
                prepend-icon="mdi-account"
                type="text"
              />
              <v-text-field
                label="Contraseña"
                v-model="password"
                prepend-icon="mdi-lock"
                type="password"
              />
            </v-card-text>
            <v-card-actions>
              <v-spacer />
              <v-btn color="primary" type="submit">Login</v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-col>
    </v-row>
</template>

<script>
const Cookie = process.client ? require("js-cookie") : undefined;

export default {
  layout: "blank",
  data() {
    return {
      username: "",
      password: "",
      error: null
    };
  },
  methods: {
    login() {
      this.$axios
        .post("/api/login", {
          username: this.username,
          password: this.password
        })
        .then(response => {
          const auth = response.data;
          this.$store.commit('setAuth', auth);
          Cookie.set('auth', auth)
          this.$router.push('/')
        })
        .catch(e => {
          this.error = e.response.data.Error;
        });
    }
  }
};
</script>
