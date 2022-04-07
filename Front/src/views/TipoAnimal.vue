<template>
  <div>
    <div class="text-center ma-2">
      <v-snackbar v-model="alertaMensagem" :color="alerta.cor">
        <v-icon>{{ alerta.icone }}</v-icon>
        {{ alerta.texto }}
      </v-snackbar>
    </div>
    <div class="text-center">
      <v-overlay :value="bloquearTela">
        <v-progress-circular indeterminate size="64" color="purple"></v-progress-circular>
      </v-overlay>
    </div>
    <v-data-table
      :headers="tituloTabela"
      :items="tipoAnimais"
      :search="filtrarTipoAnimal"
      sort-by="calories"
      class="elevation-1"
      :loading="carregarTabela"
      loading-text="Por favor, aguarde..."
      :footer-props="{
        showFirstLastPage: true,
        'items-per-page-options': [5, 10, 15, 'Todos'],
        'items-per-page-text': 'Linhas por página',
      }"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>Tipo Animal</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-text-field
            v-model="filtrarTipoAnimal"
            append-icon="mdi-magnify"
            label="Pesquisar"
            single-line
            hide-details
          ></v-text-field>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialogEditar" max-width="500px">
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on"> ADICIONAR </v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="text-h5">{{ formTitle }}</span>
              </v-card-title>

              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field autofocus v-model="tipoAnimal.descricao" label="Descrição"></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>

              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="secondary" text @click="fecharDialog"> Cancelar </v-btn>
                <v-btn color="success" text @click="salvar"> Salvar </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <v-dialog v-model="dialogDelete" max-width="500px">
            <v-card>
              <v-card-title class="text-h6">Tem certeza que deseja deletar este item?</v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12">
                      <v-text-field v-model="tipoAnimal.descricao" label="Descricao" disabled></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="secondary" text @click="fecharDialogDeletar">Não</v-btn>
                <v-btn color="error" text @click="confirmarDialogDeletar">Sim</v-btn>
                <v-spacer></v-spacer>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-toolbar>
      </template>
      <template v-slot:item.actions="{ item }">
        <v-icon small class="mr-2" @click="preencherDialogAtualizar(item)">
          {{ iconEditar }}
        </v-icon>
        <v-icon small @click="preencherDialogDeletar(item)">
          {{ iconDeletar }}
        </v-icon>
      </template>
      <template v-slot:no-data v-if="!carregarTabela">
        <v-btn color="primary" @click="inicializar"> Resetar </v-btn>
      </template>
      <template v-slot:[`footer.page-text`]="items">
        {{ items.pageStart }} - {{ items.pageStop }} de {{ items.itemsLength }}
      </template>
    </v-data-table>
  </div>
</template>

<script>
import { mdiPencilOutline, mdiDeleteOutline, mdiCloseCircle, mdiCheckCircle } from '@mdi/js'
import TipoAnimalRepository from './../repository/TipoAnimalRepository'

export default {
  data: () => ({
    tipoAnimalRepository: null,
    alerta: {
      cor: null,
      texto: null,
      icone: null,
    },
    alertaMensagem: false,
    bloquearTela: false,
    carregarTabela: false,
    iconEditar: mdiPencilOutline,
    iconDeletar: mdiDeleteOutline,
    filtrarTipoAnimal: '',
    dialogEditar: false,
    dialogDelete: false,
    tituloTabela: [
      {
        text: 'Descricao',
        align: 'start',
        sortable: true,
        value: 'descricao',
      },
      { text: 'Ações', value: 'actions', sortable: false },
    ],
    tipoAnimais: [],
    tipoAnimal: {
      id: 0,
      descricao: '',
      usuarioIdCadastro: 1,
    },
  }),

  computed: {
    formTitle() {
      return this.tipoAnimal.id === 0 ? 'Adicionar Tipo Animal' : 'Atualizar Tipo Animal'
    },
  },

  watch: {
    dialogEditar(val) {
      val || this.fecharDialog()
    },
    dialogDelete(val) {
      val || this.fecharDialogDeletar()
    },
  },

  created() {
    this.inicializar()
  },

  methods: {
    inicializar() {
      this.carregarTabela = true
      this.tipoAnimalRepository = new TipoAnimalRepository()

      this.tipoAnimalRepository
        .obterTodos()
        .then(response => {
          this.tipoAnimais = response.data
        })
        .catch(_ => {
          this.mostrarAlerta('error', 'Erro ao obter conteúdo')
        })
        .finally(_ => {
          this.carregarTabela = false
        })
    },

    preencherDialogAtualizar(item) {
      this.tipoAnimal = Object.assign({}, item)
      this.dialogEditar = true
    },

    preencherDialogDeletar(item) {
      this.tipoAnimal = Object.assign({}, item)
      this.dialogDelete = true
    },

    confirmarDialogDeletar() {
      this.bloquearTela = true
      this.tipoAnimalRepository
        .deletar(this.tipoAnimal)
        .then(response => {
          const index = this.tipoAnimais.findIndex(x => x.id == response.data.id)
          this.tipoAnimais.splice(index, 1)
          this.mostrarAlerta('success', 'Deletado com sucesso')
        })
        .catch(_ => {
          this.mostrarAlerta('error', 'Falha ao deletar')
        })
        .finally(_ => {
          this.bloquearTela = false
        })
      this.fecharDialogDeletar()
    },

    fecharDialog() {
      this.dialogEditar = false
      this.$nextTick(() => {
        this.tipoAnimal = Object.assign({}, this.tipoAnimal)
        this.limpar()
      })
    },

    fecharDialogDeletar() {
      this.dialogDelete = false
      this.$nextTick(() => {
        this.tipoAnimal = Object.assign({}, this.tipoAnimal)
        this.limpar()
      })
    },

    salvar() {
      this.bloquearTela = true
      if (this.tipoAnimal.id > 0) {
        this.tipoAnimalRepository
          .atualizar(this.tipoAnimal)
          .then(response => {
            const index = this.tipoAnimais.findIndex(x => x.id == response.data.id)
            Object.assign(this.tipoAnimais[index], response.data)
            this.mostrarAlerta('success', 'Atualizado com sucesso')
          })
          .catch(_ => {
            this.mostrarAlerta('error', 'Falha ao atualizar')
          })
          .finally(_ => {
            this.bloquearTela = false
          })
      } else {
        this.tipoAnimalRepository
          .adicionar(this.tipoAnimal)
          .then(response => {
            this.tipoAnimais.push(response.data)
            this.mostrarAlerta('success', 'Cadastrado com sucesso')
          })
          .catch(_ => {
            this.mostrarAlerta('error', 'Falha ao cadastrar')
          })
          .finally(_ => {
            this.bloquearTela = false
          })
      }
      this.fecharDialog()
    },

    limpar() {
      this.tipoAnimal = {
        id: 0,
        descricao: '',
        usuarioIdCadastro: 1,
      }
    },
    mostrarAlerta(acao, mensagem) {
      this.alerta.cor = acao
      this.alerta.texto = mensagem
      this.alerta.icone = acao == 'success' ? mdiCheckCircle : mdiCloseCircle
      this.alertaMensagem = true
    },
  },
}
</script>
