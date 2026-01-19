<script setup lang="ts">
import { useAuthStore } from './store/auth';
import { useRouter } from 'vue-router';

const authStore = useAuthStore();
const router = useRouter();

const logout = () => {
    authStore.logout();
    router.push('/login');
};
</script>

<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark mb-4">
    <div class="container">
      <router-link class="navbar-brand" to="/">SecureApp</router-link>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav me-auto">
          <li class="nav-item">
            <router-link class="nav-link" to="/dashboard" v-if="authStore.state.isAuthenticated">Dashboard</router-link>
          </li>
          <li class="nav-item">
            <router-link class="nav-link" to="/admin" v-if="authStore.isAdmin">Admin Panel</router-link>
          </li>
        </ul>
        <ul class="navbar-nav">
          <li class="nav-item" v-if="!authStore.state.isAuthenticated">
            <router-link class="nav-link" to="/login">Login</router-link>
          </li>
          <li class="nav-item" v-if="!authStore.state.isAuthenticated">
            <router-link class="nav-link" to="/register">Register</router-link>
          </li>
          <li class="nav-item" v-if="authStore.state.isAuthenticated">
            <button class="btn btn-outline-light nav-link border-0" @click="logout">Logout</button>
          </li>
        </ul>
      </div>
    </div>
  </nav>
  <div class="container">
    <router-view></router-view>
  </div>
</template>

<style>
body {
  background-color: #f8f9fa;
}
</style>
