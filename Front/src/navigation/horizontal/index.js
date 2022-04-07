import {
  mdiAccountGroup,
  mdiAccountTie,
  mdiCastle,
  mdiDog,
  mdiFormatListBulleted,
  mdiGoogleDownasaur
} from '@mdi/js'

export default [
  {
    title: 'Personagens',
    icon: mdiFormatListBulleted,
    to: 'personagem',
  },
  {
    title: 'Tipo Animal',
    icon: mdiDog,
    to: 'tipo-animal',
  },
  {
    title: 'Gênero',
    icon: mdiAccountGroup,
    to: 'genero',
  },
  {
    title: 'Raça',
    icon: mdiGoogleDownasaur,
    to: 'raca',
  },
  {
    title: 'Casa',
    icon: mdiCastle,
    to: 'casa',
  },
  {
    title: 'Cargo',
    icon: mdiAccountTie,
    to: 'cargo',
  },
]
