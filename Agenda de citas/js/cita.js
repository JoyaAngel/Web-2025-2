let listaCita = [];

function agregarCita() {
  let nombrePaciente = document.getElementById("nombrePaciente").value;
  let fecha = document.getElementById("fecha").value;
  let hora = document.getElementById("hora").value;
  let razon = document.getElementById("razon").value;

  if (nombrePaciente === "" || fecha === "" || hora === "" || razon === "") {
    alert("Todos los campos son requeridos");
    return;
  }

  let listaCita = JSON.parse(localStorage.getItem("citas")) || [];
  let citaEditada = JSON.parse(localStorage.getItem("citaEditada"));

  if (citaEditada) {
    listaCita[citaEditada.index] = { nombrePaciente, fecha, hora, razon };
    localStorage.removeItem("citaEditada");
  } else {
    listaCita.push({ nombrePaciente, fecha, hora, razon });
  }

  localStorage.setItem("citas", JSON.stringify(listaCita));
  document.getElementById("citaForm").reset();
  window.location.href = "agenda.html";
}

function actualizarTabla() {
  let tabla = document.getElementById("tablaCitas");
  let listaCita = JSON.parse(localStorage.getItem("citas")) || [];

  tabla.innerHTML = "";
  listaCita.forEach((cita, index) => {
    let fila = `<tr>
        <td>${cita.nombrePaciente}</td>
        <td>${cita.fecha}</td>
        <td>${cita.hora}</td>
        <td>${cita.razon}</td>
        <td>
          <button onclick="eliminarCita(${index})">Eliminar</button>
          <br />
          <br />
          <button onclick="editarCita(${index})">
            <a href="cita.html">Editar</a>
          </button>
        </td>
    </tr>`;
    tabla.innerHTML += fila;
  });
}

function eliminarCita(index) {
  let listaCita = JSON.parse(localStorage.getItem("citas")) || [];
  listaCita.splice(index, 1);
  localStorage.setItem("citas", JSON.stringify(listaCita));
  actualizarTabla();
}

function editarCita(index) {
  let listaCita = JSON.parse(localStorage.getItem("citas")) || [];
  localStorage.setItem(
    "citaEditada",
    JSON.stringify({ index, ...listaCita[index] })
  );
  window.location.href = "cita.html";
}