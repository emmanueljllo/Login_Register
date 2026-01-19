export interface User {
    id: number;
    email: string;
    fullName?: string;
    role: string;
}

export interface AuthResponse {
    success: boolean;
    message: string;
    token?: string;
    user?: User;
}

export interface LoginRequest {
    email: string;
    password: string;
}

export interface RegisterRequest {
    email: string;
    password: string;
    fullName?: string;
    role?: string;
}
