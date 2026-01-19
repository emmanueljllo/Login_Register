<template>
  <div class="container mt-4">
    <div class="card shadow">
        <div class="card-header bg-danger text-white">
            <h3>Panel de Administración</h3>
        </div>
        <div class="card-body">
            <p>Bienvenido, Administrador. Aquí puedes subir nuevas imágenes.</p>
            
            <div class="card mt-3">
                <div class="card-header bg-secondary text-white">Subir Imagen</div>
                <div class="card-body">
                    <form @submit.prevent="handleUpload">
                        <div class="mb-3">
                            <label class="form-label">Título</label>
                            <input v-model="title" type="text" class="form-control" required>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Imagen</label>
                            <input type="file" @change="onFileChange" class="form-control" accept="image/*" required>
                        </div>
                        <button type="submit" class="btn btn-primary" :disabled="uploading">
                            {{ uploading ? 'Subiendo...' : 'Subir Imagen' }}
                        </button>
                    </form>
                    <div v-if="message" :class="{'alert': true, 'alert-success': success, 'alert-danger': !success, 'mt-3': true}">
                        {{ message }}
                    </div>
                </div>
            </div>
        </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import imageService from '../services/imageService';

const title = ref('');
const file = ref<File | null>(null);
const uploading = ref(false);
const message = ref('');
const success = ref(false);

const onFileChange = (e: Event) => {
    const target = e.target as HTMLInputElement;
    if (target.files && target.files.length > 0) {
        file.value = target.files[0];
    }
};

const handleUpload = async () => {
    if (!file.value || !title.value) return;

    uploading.value = true;
    message.value = '';

    try {
        await imageService.upload(file.value, title.value);
        success.value = true;
        message.value = 'Imagen subida correctamente!';
        title.value = '';
        file.value = null;
        // Reset file input manually if needed using ref
    } catch (err: any) {
        console.error('Upload Error:', err);
        success.value = false;
        message.value = err.response?.data?.message || err.response?.data || err.message || 'Error al subir la imagen';
    } finally {
        uploading.value = false;
    }
};
</script>

<style scoped>
.admin-panel {
  background-color: #f0f0f0;
  padding: 20px;
  border-radius: 8px;
  border: 2px solid #333;
}
</style>
