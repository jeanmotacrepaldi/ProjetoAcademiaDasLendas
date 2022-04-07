import axiosIns from '../plugins/axios'

export default class BaseRepository {
  _controller = ''
  _axiosIns = null
  constructor(controller) {
    this._controller = controller
    this._axiosIns = axiosIns;
  }
  obterTodos() {
    return this._axiosIns.get(`${this._controller}/ObterTodos`)
  }
  obterPorId(id) {
    return this._axiosIns.get(`${this._controller}/ObterPorId/${id}`)
  }
  adicionar(obj) {
    return this._axiosIns.post(`${this._controller}/Adicionar`, obj)
  }
  atualizar(obj) {
    return this._axiosIns.post(`${this._controller}/Atualizar`, obj)
  }
  deletar(obj) {
    return this._axiosIns.post(`${this._controller}/Deletar`, obj)
  }

}
