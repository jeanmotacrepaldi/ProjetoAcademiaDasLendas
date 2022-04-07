import {
  mdiAccountOutline,
  mdiHelpCircleOutline,
  mdiFormatListBulleted,
  mdiDog,
  mdiAccountGroup,
  mdiGoogleDownasaur,
  mdiCastle,
  mdiAccountTie
} from '@mdi/js'

/* eslint-disable */
// prettier-ignore
export default [
  { header: 'Pages' },

  { title: 'Personagens', icon: mdiFormatListBulleted, to: 'personagem' },
  { title: 'Tipo Animal', icon: mdiDog, to: 'tipo-animal' },
  { title: 'Gênero', icon: mdiAccountGroup, to: 'genero' },
  { title: 'Raça', icon: mdiGoogleDownasaur, to: 'raca' },
  { title: 'Casa', icon: mdiCastle, to: 'casa' },
  { title: 'Cargo', icon: mdiAccountTie, to: 'cargo' },
  { title: 'Perfil', icon: mdiAccountOutline, to: { name: 'apps-user-view' } },
  { title: 'FAQ', icon: mdiHelpCircleOutline, to: { name: 'page-faq' } },
]

