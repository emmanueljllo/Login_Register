import axios from 'axios';
import authService from './authService';

const API_URL = 'http://localhost:5109/api/images';

export interface Image {
    id: number;
    url: string;
    title: string;
}

export default {
    async getAll(): Promise<Image[]> {
        const response = await axios.get(API_URL);
        return response.data;
    },

    async upload(file: File, title: string): Promise<Image> {
        const formData = new FormData();
        formData.append('file', file);
        formData.append('title', title);

        const token = authService.getToken();
        const response = await axios.post(`${API_URL}/upload`, formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
                Authorization: `Bearer ${token}`
            }
        });
        return response.data;
    }
};
