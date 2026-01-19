<template>
  <div class="row justify-content-center mt-5">
    <div class="col-md-6 col-lg-4">
      <div class="card shadow">
        <div class="card-header bg-success text-white text-center">
          <h3 class="mb-0">Registro</h3>
        </div>
        <div class="card-body">
          <form @submit.prevent="handleRegister">
            <div class="mb-3">
              <label class="form-label">Nombre Completo:</label>
              <input v-model="fullName" type="text" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Email:</label>
              <input v-model="email" type="email" class="form-control" required />
            </div>
            <div class="mb-3">
              <label class="form-label">Contraseña:</label>
              <input v-model="password" type="password" class="form-control" required />
            </div>
            <div class="mb-3">
              <label class="form-label">Rol (Demo):</label>
              <select v-model="role" class="form-select">
                <option value="User">Usuario</option>
                <option value="Admin">Administrador</option>
              </select>
            </div>
            <div class="d-grid">
              <button type="submit" class="btn btn-success">Registrarse</button>
            </div>
          </form>
          <div v-if="error" class="alert alert-danger mt-3">{{ error }}</div>
          <p class="mt-3 text-center">
            Ya tienes cuenta? <router-link to="/login">Inicia Sesión</router-link>
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useAuthStore } from '../store/auth'

const email = ref('')
const password = ref('')
const fullName = ref('')
const role = ref('User')
const error = ref('')
const router = useRouter()
const { register } = useAuthStore()

const handleRegister = async () => {
  error.value = ''
  try {
    const response = await register({ 
        email: email.value, 
        password: password.value, 
        fullName: fullName.value,
        role: role.value 
    })
    
    if (response.success) {
      router.push('/dashboard')
    } else {
      error.value = response.message
    }
  } catch (e) {
    error.value = 'Ocurrió un error inesperado'
  }
}
</script>
