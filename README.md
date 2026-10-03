# 🛒 ApiCatalogo

> **API REST** para la gestión de un catálogo de productos e-commerce organizado como **Árbol General**.
> Trabajo Final Práctico — Estructuras de Datos

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-UI-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)
![Estado](https://img.shields.io/badge/Estado-En%20Desarrollo-orange?style=for-the-badge)

---

## 📖 Descripción

Los **Árboles Generales** son la estructura ideal para modelar catálogos de e-commerce: permiten representar jerarquías dinámicas y asimétricas donde cada categoría puede tener un número variable de subcategorías.

```
                        🏪 Catálogo Global
                       /        |         \
              Electrónica      Moda       Hogar  ...
             /         \
        Grupo 1       Grupo 2
        /    \          |
    Prod 1  Prod 2    Prod 3
```

- **Raíz** → catálogo completo de la tienda
- **Nodos internos** → categorías y subcategorías
- **Hojas** → productos finales

---

## 🚀 Cómo ejecutar

```bash
# Abrir el proyecto
cd ApiCatalogo/ApiCatalogo

# Ejecutar la API
dotnet run
```

La API levanta en **`http://localhost:5000`**
Swagger disponible en **`http://localhost:5000/swagger`**

---

## 📱 Aplicación Móvil (Android)

El proyecto incluye una **app móvil Android** que se conecta a la API y permite navegar el catálogo desde el celular.

### ⬇️ Descargar la APK

| Archivo | Tamaño | Plataforma |
|---|---|---|
| [`catalogo_movil.apk`](../catalogo_movil.apk) | ~15 MB | Android |

### 📲 Instrucciones de instalación

1. Descargá el archivo `catalogo_movil.apk`
2. En tu Android, andá a **Ajustes → Seguridad**
3. Activá la opción **"Instalar aplicaciones de fuentes desconocidas"**
4. Abrí el archivo `.apk` descargado y tocá **Instalar**
5. Asegurate de que la API esté corriendo antes de abrir la app

> ⚠️ **Requisito:** La API debe estar ejecutándose en la misma red que el dispositivo Android para que la app pueda conectarse.

---


## 📡 Endpoints

| Método | Ruta | Descripción |
|--------|------|-------------|
| `GET`  | `/api/catalogo/todos` | Retorna todos los productos del catálogo |
| `GET`  | `/api/catalogo/buscar?elemento=X` | Busca productos por nombre (parcial o total) |
| `POST` | `/api/catalogo/agregar` | Agrega un nuevo ítem al catálogo |
| `GET`  | `/api/catalogo/urls-seo` | Genera todas las URLs SEO del árbol |
| `GET`  | `/api/catalogo/url-seoPorId?id=X` | URL SEO de un ítem específico por ID |
| `GET`  | `/api/catalogo/niveles` | Elementos del árbol agrupados por nivel |

---

## 🔍 Ejemplos de respuesta

### `GET /api/catalogo/urls-seo`
```json
[
  "tienda.com/Catalogo Global/Electronica/Electronica - Grupo 1/Prod 1",
  "tienda.com/Catalogo Global/Electronica/Electronica - Grupo 1/Prod 2",
  "tienda.com/Catalogo Global/Moda/Moda - Grupo 1/Prod 1"
]
```

### `GET /api/catalogo/url-seoPorId?id=5`
```json
"tienda.com/Catalogo Global/Electronica/Electronica - Grupo 1/Electronica - Grupo 1 Prod 2"
```

### `GET /api/catalogo/niveles`
```json
[
  ["Catalogo Global"],
  ["Electronica", "Moda", "Hogar", "Deportes", "Belleza", "Juguetes"],
  ["Electronica - Grupo 1", "Electronica - Grupo 2", "..."],
  ["Prod 1", "Prod 2", "Prod 3"]
]
```

---

## 🏗️ Estructura del proyecto

```
ApiCatalogo/
├── ArbolGeneral.cs     # Estructura de datos: Árbol General genérico
├── Cola.cs             # Estructura de datos: Cola genérica (usada en BFS)
├── ItemCat.cs          # Modelo: categorías y productos del catálogo
├── Estrategia.cs       # ⭐ Lógica principal — métodos implementados aquí
├── Util.cs             # Generador de datos de prueba (catálogo masivo)
└── Program.cs          # Configuración de la API (Minimal API + Swagger)
```

---

## ⚙️ Clase `Estrategia` — Métodos implementados

### ✅ `GetUrlSeoPorId(arbol, id)`
Recorre el árbol en profundidad (**DFS**) buscando el nodo con el `Id` indicado.
Acumula el camino desde la raíz hasta ese nodo y retorna la URL completa.

```
DFS: raíz → hijos → hijos de hijos → ...
Si encuentra el Id → retorna "tienda.com/camino/hasta/ese/nodo"
Si no lo encuentra  → retorna "No encontrado"
```

### ✅ `GetURLsSEO(arbol)`
Recorre el árbol en profundidad (**DFS**) y genera una URL por cada **hoja** (producto).
Cada URL representa el camino completo desde la raíz hasta ese producto.

```
DFS: raíz → hijos → ... → hoja → agrega URL a la lista
```

---

## 🧩 Estructuras de datos utilizadas

| Estructura | Uso en el proyecto |
|---|---|
| `ArbolGeneral<T>` | Almacena el catálogo completo de categorías y productos |
| `Cola<T>` | Recorrido BFS por niveles (`ConsultaNiveles`) |
| `List<T>` | Retorno de resultados en los endpoints |

---

## 📚 Conceptos aplicados

- ✔️ Recorrido **DFS** (Depth First Search) recursivo
- ✔️ Recorrido **BFS** (Breadth First Search) iterativo con Cola
- ✔️ Árbol General con nodos de cantidad variable de hijos
- ✔️ API REST con **ASP.NET Core Minimal API**
- ✔️ Documentación interactiva con **Swagger / OpenAPI**

---

*Trabajo Final Práctico — Estructuras de Datos*

