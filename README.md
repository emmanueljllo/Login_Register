# Login & Register System

Sistema completo de autenticación con backend en C#.NET y frontend en Vue.js

## 🚀 Características

### Backend (C#.NET)
- ASP.NET Core Web API (.NET 9.0)
- Entity Framework Core con SQL Server LocalDB
- Autenticación JWT (JSON Web Tokens)
- Hash de contraseñas con BCrypt
- Validación de datos
- CORS configurado para Vue

### Frontend (Vue.js)
- Vue 3 con Composition API
- Vue Router para navegación
- Diseño moderno con glassmorphism
- Animaciones suaves
- Validación de formularios
- Manejo de tokens JWT
- Rutas protegidas

## 📋 Requisitos Previos

- .NET 9.0 SDK
- Node.js (v18 o superior)
- SQL Server LocalDB (incluido con Visual Studio)

## 🛠️ Instalación

### Backend

1. Navega a la carpeta del backend:
```bash
cd Backend
```

2. Restaura los paquetes:
```bash
dotnet restore
```

3. Ejecuta la aplicación:
```bash
dotnet run
```

El backend estará disponible en `https://localhost:7000`

### Frontend

1. Navega a la carpeta del frontend:
```bash
cd Frontend
```

2. Instala las dependencias:
```bash
npm install
```

3. Ejecuta el servidor de desarrollo:
```bash
npm run dev
```

El frontend estará disponible en `http://localhost:5173`

## 📡 API Endpoints

### POST /api/auth/register
Registra un nuevo usuario

**Request Body:**
```json
{
  "email": "Emmanuel@gmail.com",
  "password": "contraseña123",
  "fullName": "Emmanuel Jaramillo" 
}
```

**Response:**
```json
{
  "success": true,
  "message": "Usuario registrado exitosamente",
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "user": {
    "id": 1,
    "email": "usuario@ejemplo.com",
    "fullName": "Nombre Completo"
  }
}
```

### POST /api/auth/login
Inicia sesión con un usuario existente

**Request Body:**
```json
{
  "email": "usuario@ejemplo.com",
  "password": "contraseña123"
}
```

**Response:**
```json
{
  "success": true,
  "message": "Login exitoso",
  "token": "eyJhbGciOiJIUzI1NiIs...",
  "user": {
    "id": 1,
    "email": "usuario@ejemplo.com",
    "fullName": "Nombre Completo"
  }
}
```

## 🎨 Características del Frontend

- **Diseño Moderno**: Glassmorphism con gradientes vibrantes
- **Animaciones**: Transiciones suaves y efectos hover
- **Responsive**: Adaptable a diferentes tamaños de pantalla
- **Validación**: Validación en tiempo real de formularios
- **Rutas Protegidas**: Dashboard solo accesible con autenticación
- **Manejo de Errores**: Mensajes claros de error y éxito

## 🔒 Seguridad

- Contraseñas hasheadas con BCrypt
- Tokens JWT con expiración de 7 días
- Validación de datos en backend y frontend
- CORS configurado específicamente para el frontend
- HTTPS en desarrollo

## 📁 Estructura del Proyecto

```
Login_Register/
├── Backend/
│   ├── Controllers/
│   │   └── AuthController.cs
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Models/
│   │   ├── User.cs
│   │   ├── LoginRequest.cs
│   │   ├── RegisterRequest.cs
│   │   └── AuthResponse.cs
│   ├── Services/
│   │   ├── IAuthService.cs
│   │   └── AuthService.cs
│   ├── Program.cs
│   └── appsettings.json
│
└── Frontend/
    ├── src/
    │   ├── components/
    │   │   ├── LoginForm.vue
    │   │   ├── RegisterForm.vue
    │   │   └── Dashboard.vue
    │   ├── router/
    │   │   └── index.js
    │   ├── services/
    │   │   └── authService.js
    │   ├── assets/
    │   │   └── style.css
    │   ├── App.vue
    │   └── main.js
    ├── index.html
    ├── package.json
    └── vite.config.js
```

## 🧪 Pruebas

1. Inicia el backend
2. Inicia el frontend
3. Navega a `http://localhost:5173`
4. Registra un nuevo usuario
5. Inicia sesión con las credenciales
6. Verifica que puedas acceder al dashboard
7. Cierra sesión y verifica que no puedas acceder al dashboard sin autenticación

## 🔧 Configuración

### Cambiar la base de datos

Edita `Backend/appsettings.json` y modifica la cadena de conexión:

```json
"ConnectionStrings": {
  "DefaultConnection": "tu-cadena-de-conexion"
}
```

### Cambiar la clave secreta JWT

Edita `Backend/appsettings.json`:

```json
"JwtSettings": {
  "SecretKey": "tu-clave-secreta-muy-segura"
}
```

### Cambiar el puerto del frontend

Edita `Frontend/vite.config.js`:

```javascript
server: {
  port: 3000 // Tu puerto preferido
}
```

## 📝 Notas

- La base de datos se crea automáticamente al iniciar el backend
- Los tokens se almacenan en localStorage del navegador
- En producción, considera usar variables de entorno para configuraciones sensibles
- Cambia la clave secreta JWT en producción

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue primero para discutir los cambios que te gustaría hacer.

## 📄 Licencia

Este proyecto es de código abierto y está disponible bajo la licencia MIT.
