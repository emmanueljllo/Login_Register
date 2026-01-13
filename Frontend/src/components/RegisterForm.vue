<template>
  <div class="auth-container">
    <div class="glass-card auth-card">
      <div class="auth-header">
        <h1 class="auth-title">Crear Cuenta</h1>
        <p class="auth-subtitle">Únete a nosotros hoy</p>
      </div>

      <div v-if="message" :class="['alert', messageType === 'success' ? 'alert-success' : 'alert-error']">
        {{ message }}
      </div>

      <form @submit.prevent="handleRegister">
        <div class="form-group">
          <label for="fullName" class="form-label">Nombre Completo</label>
          <input
            id="fullName"
            v-model="fullName"
            type="text"
            class="form-input"
            placeholder="Juan Pérez"
            :disabled="loading"
          />
        </div>

        <div class="form-group">
          <label for="email" class="form-label">Email</label>
          <input
            id="email"
            v-model="email"
            type="email"
            class="form-input"
            placeholder="tu@email.com"
            required
            :disabled="loading"
          />
        </div>

        <div class="form-group">
          <label for="password" class="form-label">Contraseña</label>
          <input
            id="password"
            v-model="password"
            type="password"
            class="form-input"
            placeholder="••••••••"
            required
            minlength="6"
            :disabled="loading"
          />
          <p class="text-muted text-sm mt-1">Mínimo 6 caracteres</p>
        </div>

        <div class="form-group">
          <label for="confirmPassword" class="form-label">Confirmar Contraseña</label>
          <input
            id="confirmPassword"
            v-model="confirmPassword"
            type="password"
            class="form-input"
            placeholder="••••••••"
            required
            :disabled="loading"
          />
        </div>

        <button type="submit" class="btn btn-primary btn-full" :disabled="loading">
          <span v-if="loading" class="spinner"></span>
          {{ loading ? 'Registrando...' : 'Registrarse' }}
        </button>
      </form>

      <div class="auth-footer">
        <p class="text-center text-muted text-sm mt-3">
          ¿Ya tienes una cuenta?
          <router-link to="/login" class="link">Inicia sesión aquí</router-link>
        </p>
      </div>
    </div>
  </div>
</template>

<script>
import authService from '../services/authService'

export default {
  name: 'RegisterForm',
  data() {
    return {
      fullName: '',
      email: '',
      password: '',
      confirmPassword: '',
      message: '',
      messageType: '',
      loading: false
    }
  },
  methods: {
    async handleRegister() {
      // Validate passwords match
      if (this.password !== this.confirmPassword) {
        this.messageType = 'error'
        this.message = 'Las contraseñas no coinciden'
        return
      }

      // Validate password length
      if (this.password.length < 6) {
        this.messageType = 'error'
        this.message = 'La contraseña debe tener al menos 6 caracteres'
        return
      }

      this.loading = true
      this.message = ''

      const response = await authService.register(
        this.email,
        this.password,
        this.fullName || null
      )

      if (response.success) {
        this.messageType = 'success'
        this.message = response.message
        
        setTimeout(() => {
          this.$router.push('/dashboard')
        }, 1000)
      } else {
        this.messageType = 'error'
        this.message = response.message
      }

      this.loading = false
    }
  }
}
</script>

<style scoped>
.auth-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  padding: 2rem;
}

.auth-card {
  width: 100%;
  max-width: 450px;
}

.auth-header {
  margin-bottom: 2rem;
  text-align: center;
}

.auth-title {
  font-size: 2rem;
  font-weight: 700;
  margin-bottom: 0.5rem;
  background: linear-gradient(135deg, #fff 0%, #e0e7ff 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.auth-subtitle {
  color: var(--text-muted);
  font-size: 1rem;
}

.auth-footer {
  margin-top: 2rem;
  padding-top: 2rem;
  border-top: 1px solid rgba(255, 255, 255, 0.1);
}
</style>
