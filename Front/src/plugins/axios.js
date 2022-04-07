// axios
import axios from 'axios'
import Vue from 'vue'
import { useRouter } from '@core/utils'

const axiosIns = axios.create({
  baseURL: 'https://localhost:44363/api',
})

axiosIns.interceptors.request.use(
  config => {
    const accessToken = localStorage.getItem('jwtToken')

    // eslint-disable-next-line no-param-reassign
    if (accessToken) config.headers.Authorization = `Bearer ${accessToken}`

    return config
  },
  error => Promise.reject(error),
)

axiosIns.interceptors.response.use(response => {
  return response;
}, error => {
  if (error.response.status === 401) {
    localStorage.removeItem('jwtToken')
    localStorage.removeItem('userData')
    localStorage.removeItem('userAbility')
    window.location = "/login";
  }
  return error;
});

Vue.prototype.$http = axiosIns

export default axiosIns
