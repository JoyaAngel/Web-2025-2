<template>
  <div class="container mt-5">
    <h1 class="mb-4">Gestión de Alumnos</h1>
    <button class="btn btn-primary mb-3" @click="abrirModalNuevo">Agregar Alumno</button>

    <table class="table table-striped">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Correo</th>
          <th>Fecha Nacimiento</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="alumno in alumnos" :key="alumno.id">
          <td>{{ alumno.nombre }}</td>
          <td>{{ alumno.correo }}</td>
          <td>{{ alumno.fechaNacimiento }}</td>
          <td>
            <button class="btn btn-warning btn-sm me-2" @click="editarAlumno(alumno)">
              Editar
            </button>
            <button class="btn btn-danger btn-sm" @click="eliminarAlumno(alumno.id)">
              Eliminar
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- Modal Bootstrap -->
    <div class="modal fade show d-block" tabindex="-1" v-if="modalVisible">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">{{ esEditar ? 'Editar Alumno' : 'Agregar Alumno' }}</h5>
            <button type="button" class="btn-close" @click="cerrarModal"></button>
          </div>
          <div class="modal-body">
            <div class="mb-3">
              <label class="form-label">Nombre</label>
              <input v-model="form.nombre" type="text" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Correo</label>
              <input v-model="form.correo" type="email" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Fecha de nacimiento</label>
              <input v-model="form.fechaNacimiento" type="date" class="form-control" />
            </div>
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" @click="cerrarModal">Cancelar</button>
            <button class="btn btn-success" @click="guardarAlumno">Guardar</button>
          </div>
        </div>
      </div>
    </div>
    <div v-if="modalVisible" class="modal-backdrop fade show"></div>
  </div>

  <div class="container mt-5">
    <p>Agrega aqui la parte de los doctores</p>
  </div>
  <table class="table table-striped">
    <thead>
      <tr>
        <th>Nombre</th>
        <th>Correo</th>
        <th>Fecha Nacimiento</th>
        <th>Acciones</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="alumno in alumnos" :key="alumno.id">
        <td>{{ alumno.nombre }}</td>
        <td>{{ alumno.correo }}</td>
        <td>{{ alumno.fechaNacimiento }}</td>
        <td>
          <button class="btn btn-warning btn-sm me-2" @click="editarAlumno(alumno)">Editar</button>
          <button class="btn btn-danger btn-sm" @click="eliminarAlumno(alumno.id)">Eliminar</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script setup>
import { ref, onMounted } from 'vue'
//agregamos la ruta global de nuestra API
const API_URL = 'http://localhost:5167/api/alumnos'

const alumnos = ref([]) //variables reactivas cada ves que cambie los valores se reflejan en la pagina
const modalVisible = ref(false)
const esEditar = ref(false)
const form = ref({ id: null, nombre: '', correo: '', fechaNacimiento: '' })

const obtenerAlumnos = async () => {
  //funcion asincrona, obtiene la lista de alumnos
  const res = await fetch(API_URL)
  alumnos.value = await res.json()
}

const abrirModalNuevo = () => {
  esEditar.value = false
  form.value = { nombre: '', correo: '', fechaNacimiento: '' }
  modalVisible.value = true
}

const editarAlumno = (alumno) => {
  esEditar.value = true
  form.value = { ...alumno } //objeto alumno
  modalVisible.value = true
}

const cerrarModal = () => {
  modalVisible.value = false
}

const guardarAlumno = async () => {
  const metodo = esEditar.value ? 'PUT' : 'POST' //dependiendo si es agregar usa post, si es editar usa put
  const url = esEditar.value ? `${API_URL}/${form.value.id}` : API_URL //lo mismo, solo que aqui si es editar tiene un id, si no no tiene id

  await fetch(url, {
    method: metodo,
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(form.value), //el body debe estar en formato json
  })

  cerrarModal() //cierra el modal
  obtenerAlumnos() //vuelve a solicitar la lista de alumnos
}

const eliminarAlumno = async (id) => {
  await fetch(`${API_URL}/${id}`, { method: 'DELETE' }) //elimina un alumno a partir de su id
  obtenerAlumnos() //vuelve a obtener la lista de alumnos
}

onMounted(obtenerAlumnos) //cada vez que se ejecuta la pagna llama a la lista de alumnos
</script>
