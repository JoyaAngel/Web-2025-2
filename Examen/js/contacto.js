let listaContactos = [];

function agregarContacto() {
    let contacto = {
        nombre: document.getElementById("nombre").value,
        correo: document.getElementById("correo").value,
        mensaje: document.getElementById("mensaje").value,
    };
    
    listaContactos.push(contacto);
    actualizarTabla();
    document.getElementById("contactoForm").reset();
}

function actualizarTabla() {
    let tabla = document.getElementById("tablaContactos");
    let listaContactos = document.getElementById("listaContactosMovil");
    
    tabla.innerHTML = "";
    listaContactos.innerHTML="";
    listaContactos.forEach((contacto, index) => {
        let fila = `<tr>
            <td>${contacto.nombre}</td>
            <td>${contacto.correo}</td>
            <td>${contacto.mensaje}</td>
            <td><button class="btn btn-danger" onclick="eliminarContacto(${index})">Eliminar</button></td>
        </tr>`;
        tabla.innerHTML += fila;

        let itemContacto= `<li class="list-group-item">
            <strong>Nombre: </strong> ${contacto.nombre} ${contacto.correo} ${contacto.mensaje} <br>
            <strong>Telefono: </strong><br>
            <button class="btn btn-danger mt-2" onclick="eliminarContacto(${index})">Eliminar</button>
            </li>`;

        listaContactos.innerHTML += itemContacto;




    });
}

function eliminarContacto(indice) {
    listaContactos.splice(indice, 1);
    actualizarTabla();
}