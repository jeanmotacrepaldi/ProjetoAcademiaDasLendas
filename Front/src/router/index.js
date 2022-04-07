import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

function guardMyroute(to, from, next) {
  var isAuthenticated = false;
  if (localStorage.getItem('jwtToken'))
    isAuthenticated = true;
  else
    isAuthenticated = false;
  if (isAuthenticated) {
    next();
  }
  else {
    next('/login');
  }
}

const routes = [
  {
    path: '/',
    redirect: 'login',
  },
  {
    path: '/tipo-animal',
    name: 'tipo-animal',
    beforeEnter: guardMyroute,
    component: () => import('@/views/TipoAnimal.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/personagem',
    name: 'personagem',
    beforeEnter: guardMyroute,
    component: () => import('@/views/Personagem.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/genero',
    name: 'genero',
    beforeEnter: guardMyroute,
    component: () => import('@/views/Genero.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/raca',
    name: 'raca',
    beforeEnter: guardMyroute,
    component: () => import('@/views/Raca.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/casa',
    name: 'casa',
    beforeEnter: guardMyroute,
    component: () => import('@/views/Casa.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/cargo',
    name: 'cargo',
    beforeEnter: guardMyroute,
    component: () => import('@/views/Cargo.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/perfil',
    name: 'apps-user-view',
    component: () => import('@/views/account-settings/AccountSettings.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/faq',
    name: 'page-faq',
    beforeEnter: guardMyroute,
    component: () => import('@/views/Faq.vue'),
    meta: {
      layout: 'content',
    },
  },
  {
    path: '/login',
    name: 'auth-login',
    component: () => import('@/views/Login.vue'),
    meta: {
      layout: 'blank',
    },
  },
  {
    path: '*',
    redirect: 'error-404',
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
  scrollBehavior() {
    return { x: 0, y: 0 }
  },
})

export default router
