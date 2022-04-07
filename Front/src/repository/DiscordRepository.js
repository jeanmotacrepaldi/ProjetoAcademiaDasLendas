import fetch from 'node-fetch'
//https://discord.com/developers/docs/reference#image-formatting
export default class DiscordRepository {
  async getTokenDiscord(code, redirectUri) {
    const params = new URLSearchParams()
    params.append('client_id', '953080027392655460')
    params.append('client_secret', 'sAQv7XciBoLrjHcTw-1Q5WYvHacw8XEs')
    params.append('grant_type', 'authorization_code')
    params.append('code', code)
    params.append('redirect_uri', redirectUri)
    params.append('scope', 'identify email')

    const resp = await fetch('https://discord.com/api/oauth2/token', {
      method: 'post',
      body: params,
      headers: {
        'Content-Type': 'application/x-www-form-urlencoded',
        Accept: 'application/json',
      },
    })

    if (!resp.ok) {
      return null
    }
    return await this.getUser(await resp.json())
  }
  async getUser(tokenDiscord) {
    const resp = await fetch('https://discordapp.com/api/v8/users/@me', {
      method: 'get',
      headers: {
        Authorization: `Bearer ${tokenDiscord.access_token}`,
        'Content-Type': 'application/x-www-form-urlencoded',
        Accept: 'application/json',
      },
    })
    if (!resp.ok) {
      return null
    }
    return await resp.json()
  }
}
