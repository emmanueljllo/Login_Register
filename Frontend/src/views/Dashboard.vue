<template>
  <div class="container mt-4">
    <div class="card shadow mb-4">
        <div class="card-body">
            <h2 class="card-title">Bienvenido, {{ user?.fullName }}!</h2>
            <p class="card-text">Tu rol es: <span class="badge bg-info">{{ user?.role }}</span></p>
            <div v-if="isAdmin" class="alert alert-warning">
                Tienes permisos de administrador. 
                <router-link to="/admin" class="alert-link">Ir al Panel Admin</router-link>
            </div>
        </div>
    </div>

    <h3 class="mb-3">Galería de Imágenes</h3>
    
    <div v-if="loading" class="text-center">
        <div class="spinner-border text-primary" role="status">
            <span class="visually-hidden">Cargando...</span>
        </div>
    </div>

    <div v-else class="row row-cols-1 row-cols-md-3 g-4">
        <div v-for="image in images" :key="image.id" class="col">
            <div class="card h-100 shadow-sm">
                <img :src="image.url" class="card-img-top" :alt="image.title" style="height: 200px; object-fit: cover;">
                <div class="card-body">
                    <h5 class="card-title">{{ image.title }}</h5>
                </div>
            </div>
        </div>
    </div>
    
    <div v-if="!loading && images.length === 0" class="alert alert-info text-center">
        No hay imágenes para mostrar.
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, ref, onMounted } from 'vue';
import { useAuthStore } from '../store/auth';
import imageService, { type Image } from '../services/imageService';

const authStore = useAuthStore();
const user = computed(() => authStore.state.user);
const isAdmin = authStore.isAdmin;

const images = ref<Image[]>([]);
const loading = ref(true);

onMounted(async () => {
    try {
        images.value = await imageService.getAll();
    } catch (error) {
        console.error('Error loading images:', error);
    } finally {
        loading.value = false;
    }
});
</script>

<style scoped>
.container {
  max-width: 600px;
  margin: 0 auto;
  padding: 20px;
}
.actions {
  margin-top: 20px;
  display: flex;
  gap: 10px;
}
.btn {
  padding: 10px 15px;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  text-decoration: none;
  color: white;
}
.admin-btn {
  background-color: #4CAF50;
}
.logout-btn {
  background-color: #f44336;
}
</style>
