<template>
  <v-menu offset-y left nudge-bottom="14" min-width="230" content-class="user-profile-menu-content">
    <template v-slot:activator="{ on, attrs }">
      <v-badge bottom color="success" overlap offset-x="12" offset-y="12" class="ms-4" dot>
        <v-avatar size="40px" v-bind="attrs" color="primary" class="v-avatar-light-bg primary--text" v-on="on">
          <v-img :src="require('@/assets/images/avatars/1.png')"></v-img>
        </v-avatar>
      </v-badge>
    </template>
    <v-list>
      <div class="pb-3 pt-2">
        <v-badge bottom color="success" overlap offset-x="12" offset-y="12" class="ms-4" dot>
          <v-avatar size="40px" color="primary" class="v-avatar-light-bg primary--text">
            <v-img :src="require('@/assets/images/avatars/1.png')"></v-img>
          </v-avatar>
        </v-badge>
        <div class="d-inline-flex flex-column justify-center ms-3" style="vertical-align: middle">
          <span class="text--primary font-weight-semibold mb-n1"> John Doe </span>
          <small class="text--disabled text-capitalize">Admin</small>
        </div>
      </div>

      <v-divider></v-divider>

      <v-list-item :to="{ name: 'apps-user-view' }">
        <v-list-item-icon class="me-2">
          <v-icon size="22">
            {{ icons.mdiAccountOutline }}
          </v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>Perfil</v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-list-item :to="{ name: 'page-faq' }">
        <v-list-item-icon class="me-2">
          <v-icon size="22">
            {{ icons.mdiHelpCircleOutline }}
          </v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>FAQ</v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-divider class="my-2"></v-divider>

      <v-list-item @click="logoutUser">
        <v-list-item-icon class="me-2">
          <v-icon size="22">
            {{ icons.mdiLogoutVariant }}
          </v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>Sair</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-menu>
</template>

<script>
import { mdiAccountOutline, mdiHelpCircleOutline, mdiLogoutVariant } from '@mdi/js'

import { useRouter } from '@core/utils'

export default {
  setup() {
    const { router } = useRouter()
    const userData = JSON.parse(localStorage.getItem('userData'))
    const logoutUser = () => {
      localStorage.removeItem('jwtToken')
      localStorage.removeItem('userData')
      localStorage.removeItem('userAbility')
      router.push({ name: 'auth-login' })
    }
    return {
      logoutUser,
      userData,
      icons: {
        mdiAccountOutline,
        mdiHelpCircleOutline,
        mdiLogoutVariant,
      },
    }
  },
}
</script>

<style lang="scss">
.user-profile-menu-content {
  .v-list-item {
    min-height: 2.5rem !important;
  }
}
</style>
