<template>
  <div class="dashboard-container">
    <div class="glass-card dashboard-card">
      <div class="dashboard-header">
        <h1 class="dashboard-title">¡Bienvenido! 🎉</h1>
        <p class="dashboard-subtitle" v-if="user">
          {{ user.fullName || user.email }}
        </p>
      </div>

      <div class="user-info">
        <div class="info-item">
          <span class="info-label">Email:</span>
          <span class="info-value">{{ user?.email }}</span>
        </div>
        <div class="info-item" v-if="user?.fullName">
          <span class="info-label">Nombre:</span>
          <span class="info-value">{{ user.fullName }}</span>
        </div>
        <div class="info-item">
          <span class="info-label">ID:</span>
          <span class="info-value">{{ user?.id }}</span>
        </div>
      </div>

      <div class="dashboard-actions">
        <button @click="handleLogout" class="btn btn-secondary btn-full">
          Cerrar Sesión
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import authService from '../services/authService'

export default {
  name: 'Dashboard',
  data() {
    return {
      user: null
    }
  },
  mounted() {
    this.user = authService.getCurrentUser()
    
    if (!this.user) {
      this.$router.push('/login')
    }
  },
  methods: {
    handleLogout() {
      authService.logout()
      this.$router.push('/login')
    }
  }
}
</script>

<style scoped>
.dashboard-container {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  padding: 2rem;
}

.dashboard-card {
  width: 100%;
  max-width: 600px;
}

.dashboard-header {
  margin-bottom: 2rem;
  text-align: center;
}

.dashboard-title {
  font-size: 2.5rem;
  font-weight: 700;
  margin-bottom: 0.5rem;
  background: linear-gradient(135deg, #fff 0%, #e0e7ff 100%);
  -webkit-background-clip: text;
  -webkit-text-fill-color: transparent;
  background-clip: text;
}

.dashboard-subtitle {
  color: var(--text-secondary);
  font-size: 1.25rem;
  font-weight: 500;
}

.user-info {
  background: rgba(255, 255, 255, 0.03);
  border: 1px solid rgba(255, 255, 255, 0.1);
  border-radius: 16px;
  padding: 2rem;
  margin-bottom: 2rem;
}

.info-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 0;
  border-bottom: 1px solid rgba(255, 255, 255, 0.05);
}

.info-item:last-child {
  border-bottom: none;
}

.info-label {
  color: var(--text-muted);
  font-weight: 500;
  text-transform: uppercase;
  font-size: 0.875rem;
  letter-spacing: 0.5px;
}

.info-value {
  color: var(--text-primary);
  font-weight: 600;
  font-size: 1rem;
}

.dashboard-actions {
  margin-top: 2rem;
}
</style>
