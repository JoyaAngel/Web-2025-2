function agregarComentario() {
  const nombre = document.getElementById("nombre").value;
  const apellido = document.getElementById("apellido").value;
  const comentario = document.getElementById("comentario").value;

  if (nombre && apellido && comentario) {
    const comentariosLista = document.getElementById("comentarios-lista");
    const nuevoComentario = document.createElement("div");
    nuevoComentario.classList.add("card", "mb-3");
    nuevoComentario.innerHTML = `
                      <div class="card-body">
                        <h5 class="card-title text-primary">${nombre} ${apellido}</h5>
                        <hr class="my-3 border-2 border-primary opacity-75" />
                        <p class="card-text text-muted">${comentario}</p>
                      </div>
                      <hr class="my-5 border-3 border-top border-success opacity-50" />
                    `;
    comentariosLista.appendChild(nuevoComentario);

    // Limpiar los campos del formulario
    document.getElementById("nombre").value = "";
    document.getElementById("apellido").value = "";
    document.getElementById("comentario").value = "";
  } else {
    alert("Por favor, completa todos los campos.");
  }
}
