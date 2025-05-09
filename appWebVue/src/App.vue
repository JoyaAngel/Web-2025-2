<template>
  <div class="container mt-5">
    <h1 class="mb-4">Gestión de Alumnos</h1>
    <button class="btn btn-primary mb-3" @click="abrirModalAlumno">Agregar Alumno</button>

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
    <div class="modal fade show d-block" tabindex="-1" v-if="modalAlumnoVisible">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">{{ esEditar ? 'Editar Alumno' : 'Agregar Alumno' }}</h5>
            <button type="button" class="btn-close" @click="cerrarModal"></button>
          </div>
          <div class="modal-body">
            <div class="mb-3">
              <label class="form-label">Nombre</label>
              <input v-model="formAlumno.nombre" type="text" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Correo</label>
              <input v-model="formAlumno.correo" type="email" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Fecha de nacimiento</label>
              <input v-model="formAlumno.fechaNacimiento" type="date" class="form-control" />
            </div>
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" @click="cerrarModal">Cancelar</button>
            <button class="btn btn-success" @click="guardarAlumno">Guardar</button>
          </div>
        </div>
      </div>
    </div>
    <div v-if="modalAlumnoVisible" class="modal-backdrop fade show"></div>
  </div>

  <div class="container mt-5">
    <h1 class="mb-4">Gestión de Doctores</h1>
    <button class="btn btn-primary mb-3" @click="abrirModalDoctor">Agregar Doctor</button>
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Especialidad</th>
          <th>Correo</th>
          <th>Telefono</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="doctor in doctores" :key="doctor.id">
          <td>{{ doctor.nombre }}</td>
          <td>{{ doctor.especialidad }}</td>
          <td>{{ doctor.correo }}</td>
          <td>{{ doctor.telefono }}</td>
          <td>
            <button class="btn btn-warning btn-sm me-2" @click="editarDoctor(doctor)">
              Editar
            </button>
            <button class="btn btn-danger btn-sm" @click="eliminarDoctor(doctor.id)">
              Eliminar
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <div class="modal fade show d-block" tabindex="-1" v-if="modalDoctorVisible">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">{{ esEditar ? 'Editar Doctor' : 'Agregar Doctor' }}</h5>
            <button type="button" class="btn-close" @click="cerrarModal"></button>
          </div>
          <div class="modal-body">
            <div class="mb-3">
              <label class="form-label">Nombre</label>
              <input v-model="formDoctor.nombre" type="text" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Especialidad</label>
              <input v-model="formDoctor.especialidad" type="text" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Correo</label>
              <input v-model="formDoctor.correo" type="email" class="form-control" />
            </div>
            <div class="mb-3">
              <label class="form-label">Telefono</label>
              <input v-model="formDoctor.correo" type="text" class="form-control" />
            </div>
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" @click="cerrarModal">Cancelar</button>
            <button class="btn btn-success" @click="guardarDoctor">Guardar</button>
          </div>
        </div>
      </div>
    </div>
    <div v-if="modalDoctorVisible" class="modal-backdrop fade show"></div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
//agregamos la ruta global de nuestra API
const API_URL_ALUMNOS = 'http://localhost:5090/api/alumnos'
const API_URL_DOCTORES = 'http://localhost:5090/api/doctores'

//agregamos variables reactivas para el modal
const modalAlumnoVisible = ref(false)
const modalDoctorVisible = ref(false)
const esEditar = ref(false)

//agregamos la vairables para alumno
const alumnos = ref([]) //variables reactivas cada ves que cambie los valores se reflejan en la pagina
const formAlumno = ref({ id: null, nombre: '', correo: '', fechaNacimiento: '' })

//agregamos la variable para doctores
const doctores = ref([]) //variables reactivas cada ves que cambie los valores se reflejan en la pagina
const formDoctor = ref({ id: null, nombre: '', especialidad: '', correo: '', telefono: '' })

//funcion para obtener la lista de alumnos
const obtenerAlumnos = async () => {
  //funcion asincrona, obtiene la lista de alumnos
  const res = await fetch(API_URL_ALUMNOS)
  alumnos.value = await res.json()
}

const editarAlumno = (alumno) => {
  esEditar.value = true
  formAlumno.value = { ...alumno } //objeto alumno
  modalAlumnoVisible.value = true
}

const guardarAlumno = async () => {
  const metodo = esEditar.value ? 'PUT' : 'POST' //dependiendo si es agregar usa post, si es editar usa put
  const url = esEditar.value ? `${API_URL_ALUMNOS}/${formAlumno.value.id}` : API_URL_ALUMNOS //lo mismo, solo que aqui si es editar tiene un id, si no no tiene id

  await fetch(url, {
    method: metodo,
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formAlumno.value), //el body debe estar en formato json
  })

  cerrarModal() //cierra el modal
  obtenerAlumnos() //vuelve a solicitar la lista de alumnos
}

const eliminarAlumno = async (id) => {
  await fetch(`${API_URL_ALUMNOS}/${id}`, { method: 'DELETE' }) //elimina un alumno a partir de su id
  obtenerAlumnos() //vuelve a obtener la lista de alumnos
}

onMounted(obtenerAlumnos) //cada vez que se ejecuta la pagna llama a la lista de alumnos

//Funciones para doctores
const obtenerDoctores = async () => {
  //funcion asincrona, obtiene la lista de doctores
  const res = await fetch(API_URL_DOCTORES)
  doctores.value = await res.json()
}

const editarDoctor = (doctor) => {
  esEditar.value = true
  formDoctor.value = { ...doctor } //objeto doctor
  modalDoctorVisible.value = true
}

const guardarDoctor = async () => {
  const metodo = esEditar.value ? 'PUT' : 'POST' //dependiendo si es agregar usa post, si es editar usa put
  const url = esEditar.value ? `${API_URL_DOCTORES}/${formDoctor.value.id}` : API_URL_DOCTORES //lo mismo, solo que aqui si es editar tiene un id, si no no tiene id

  await fetch(url, {
    method: metodo,
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formDoctor.value), //el body debe estar en formato json
  })

  cerrarModal() //cierra el modal
  obtenerDoctores() //vuelve a solicitar la lista de doctores
}

const eliminarDoctor = async (id) => {
  await fetch(`${API_URL_DOCTORES}/${id}`, { method: 'DELETE' }) //elimina un alumno a partir de su id
  obtenerDoctores() //vuelve a obtener la lista de doctores
}

onMounted(obtenerDoctores) //cada vez que se ejecuta la pagna llama a la lista de doctores

const abrirModalAlumno = () => {
  esEditar.value = false
  formAlumno.value = { nombre: '', correo: '', fechaNacimiento: '' }
  modalAlumnoVisible.value = true
}

const abrirModalDoctor = () => {
  esEditar.value = false
  formDoctor.value = { nombre: '', especialidad: '', correo: '', telefono: '' }
  modalDoctorVisible.value = true
}

const cerrarModal = () => {
  modalAlumnoVisible.value = false
  modalDoctorVisible.value = false
}
</script>
