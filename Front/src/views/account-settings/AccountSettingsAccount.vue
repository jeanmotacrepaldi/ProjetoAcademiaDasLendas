<template>
  <v-card flat class="pa-3 mt-2">
    <v-card-text class="d-flex">
      <v-avatar rounded size="120" class="me-6 multi-col-validation mt-3">
        <v-img :src="dadosDiscordLocale.avatar"></v-img>
      </v-avatar>

      <!-- upload photo -->
      <div>
        <v-form class="multi-col-validation mt-3">
          <v-row>
            <v-col md="6" cols="12">
              <v-text-field
                v-model="dadosDiscordLocale.nomeUsuario"
                label="Usuário # Id - Discord"
                dense
                outlined
                readonly
              ></v-text-field>
            </v-col>

            <v-col md="6" cols="12">
              <v-text-field v-model="dadosDiscordLocale.nome" label="Nome" dense outlined readonly></v-text-field>
            </v-col>

            <v-col cols="12" md="6">
              <v-text-field v-model="dadosDiscordLocale.email" label="E-mail" dense outlined readonly></v-text-field>
            </v-col>

            <v-col cols="12" md="6">
              <v-text-field
                v-model="dadosDiscordLocale.perfilAcesso"
                dense
                label="Perfil"
                outlined
                readonly
              ></v-text-field>
            </v-col>
          </v-row>
        </v-form>
      </div>
    </v-card-text>

    <v-card-text> </v-card-text>
  </v-card>
</template>

<script>
import { ref } from '@vue/composition-api'

export default {
  props: {
    dadosDiscord: {
      type: Object,
      default: () => {},
    },
  },
  setup(props) {
    const dadosDiscordLocale = ref(JSON.parse(JSON.stringify(props.dadosDiscord)))

    return {
      dadosDiscordLocale,
    }
  },
}
</script>
