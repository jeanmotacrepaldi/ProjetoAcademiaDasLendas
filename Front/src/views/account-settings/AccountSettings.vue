<template>
  <div>
    <div class="text-center">
      <v-overlay :value="overlay">
        <v-progress-circular indeterminate size="64" color="purple"></v-progress-circular>
      </v-overlay>
    </div>
    <v-card id="account-setting-card" v-if="discordLogado">
      <v-tabs v-model="tab" show-arrows>
        <v-tab v-for="tab in tabs" :key="tab.icon">
          <v-icon size="20" class="me-3">
            {{ tab.icon }}
          </v-icon>
          <span>{{ tab.title }}</span>
        </v-tab>
      </v-tabs>

      <v-tabs-items v-model="tab">
        <v-tab-item>
          <account-settings-account :dados-discord="contaLogada.dadosDiscord"></account-settings-account>
        </v-tab-item>

        <v-tab-item>
          <account-settings-info :information-data="contaLogada.information"></account-settings-info>
        </v-tab-item>
      </v-tabs-items>
    </v-card>
  </div>
</template>

<script>
import { mdiAccountOutline, mdiInformationOutline } from '@mdi/js'
import { ref } from '@vue/composition-api'
import jwt_decode from 'jwt-decode'

import DiscordRepository from '../../repository/DiscordRepository'
import AccountSettingsAccount from './AccountSettingsAccount.vue'
import AccountSettingsInfo from './AccountSettingsInfo.vue'
import UsuarioRepository from '../../repository/UsuarioRepository'

export default {
  components: {
    AccountSettingsAccount,
    AccountSettingsInfo,
  },
  setup() {
    const tab = ref('')

    return {
      overlay: false,
      usuarioRepository: null,
      discordRepository: null,
      tab,
      tabs: [
        { title: 'Account', icon: mdiAccountOutline },
        { title: 'Info', icon: mdiInformationOutline },
      ],
      contaLogada: {
        dadosDiscord: {
          avatar: '',
          nomeUsuario: '',
          nome: '',
          email: '',
          perfilAcesso: '',
        },
        information: {
          bio: '',
          birthday: '',
          phone: '',
          website: '',
          country: '',
          languages: ['', ''],
          gender: '',
        },
      },
      discordLogado: false,
      icons: {
        mdiAccountOutline,
        mdiInformationOutline,
      },
    }
  },
  async created() {
    this.overlay = true

    const jwtToken = localStorage.getItem('jwtToken')
    if (jwtToken) {
      const tokenDecoded = jwt_decode(jwtToken)
      const jwtProfile = {
        email: tokenDecoded.email,
      }
      this.preencherDadosPerfilApi(jwtProfile)
    } else {
      const url_string = window.location.href
      const url = new URL(url_string)
      const code = url.searchParams.get('code')

      if (code) {
        this.discordRepository = new DiscordRepository()
        const profile = await this.discordRepository.getTokenDiscord(code, url.origin + url.pathname)
        const discordProfile = {
          avatar: profile.avatar,
          username: profile.username,
          email: profile.email,
          discriminator: profile.discriminator,
          discordId: profile.id,
          perfilAcesso: 'ADM',
        }
        this.preencherDadosPerfilApi(discordProfile)
        window.history.replaceState({}, document.title, '/')
      }
    }
  },
  methods: {
    logoutUser() {
      localStorage.removeItem('jwtToken')
      localStorage.removeItem('userData')
      localStorage.removeItem('userAbility')
      window.location = '/login'
    },
    preencherDadosPerfilApi(dadosApi) {
      if (dadosApi) {
        this.usuarioRepository = new UsuarioRepository()
        this.usuarioRepository
          .login(dadosApi)
          .then(response => {
            localStorage.setItem('jwtToken', response.data.token)
            dadosApi = response.data
          })
          .catch(_ => {
            this.logoutUser()
          })
          .finally(_ => {
            this.preencherInformacoesPerfil(dadosApi)
            this.overlay = false
          })
      }
    },
    preencherInformacoesPerfil(dados) {
      this.contaLogada.dadosDiscord.avatar = `https://cdn.discordapp.com/avatars/${dados.discordId}/${dados.avatar}`
      this.contaLogada.dadosDiscord.nomeUsuario = `${dados.username}#${dados.discriminator}`
      this.contaLogada.dadosDiscord.nome = dados.username
      this.contaLogada.dadosDiscord.email = dados.email
      this.contaLogada.dadosDiscord.perfilAcesso = dados.perfilAcesso
      this.discordLogado = true
    },
  },
}
</script>
