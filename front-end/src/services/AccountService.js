import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/api/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getProfiles() {
    try {
      const res = await api.get('/api/profiles')
      AppState.accounts = res.data
    } catch (err) {
      logger.error(err)
    }
  }
}

export const accountService = new AccountService()
