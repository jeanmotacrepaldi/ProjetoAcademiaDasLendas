<template>
  <div class="auth-wrapper auth-v1">
    <div class="auth-inner">
      <v-card class="auth-card">
        <v-card-title class="d-flex align-center justify-center py-7">
          <router-link
            to="/"
            class="d-flex align-center"
          >
            <v-img
              :src="appLogo"
              max-height="30px"
              max-width="30px"
              alt="logo"
              contain
              class="me-3 "
            ></v-img>

            <h2 class="text-2xl font-weight-semibold">
              {{ appName }}
            </h2>
          </router-link>
        </v-card-title>
        <v-card-text>
          <div class="btn-wrapper text-center">
                <a
                  href="https://discord.com/api/oauth2/authorize?client_id=953080027392655460&redirect_uri=http%3A%2F%2Flocalhost%3A8080%2Fperfil&response_type=code&scope=identify%20email"
                  class="btn btn-neutral btn-icon"
                >
                  <v-icon x-large color="#7289dc">{{ mdiDiscord }}</v-icon>
                </a>
              </div>
        </v-card-text>
      </v-card>
    </div>

    <!-- background triangle shape  -->
    <img
      class="auth-mask-bg"
      height="173"
      :src="require(`@/assets/images/misc/mask-${$vuetify.theme.dark ? 'dark':'light'}.png`)"
    >

    <!-- tree -->
    <v-img
      class="auth-tree"
      width="247"
      height="185"
      src="@/assets/images/misc/tree.png"
    ></v-img>

    <!-- tree  -->
    <v-img
      class="auth-tree-3"
      width="377"
      height="289"
      src="@/assets/images/misc/tree-3.png"
    ></v-img>
  </div>
</template>

<script>
// eslint-disable-next-line object-curly-newline
import { mdiDiscord } from '@mdi/js'
import themeConfig from '@themeConfig'

export default {
  setup() {
    return {
      mdiDiscord,
      appName: themeConfig.app.name,
      appLogo: themeConfig.app.logo,
    }
  },
}
</script>

<style lang="scss">
@import '@core/preset/preset/pages/auth.scss';
</style>
