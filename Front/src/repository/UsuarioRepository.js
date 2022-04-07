import BaseRepository from './BaseRepository'

export default class UsuarioRepository extends BaseRepository {
  constructor() {
    super('usuario')
  }
  login(obj) {
    return this._axiosIns.post(`${this._controller}/Login`, obj)
  }
}
