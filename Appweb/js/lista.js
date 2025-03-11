let arreglo = []; //Declaración de un arreglo

function actualizarLista() {
  //Declaración de una función para actualizar listas

  let lista = document.getElementById("listaElementos");
  let mostrar = document.getElementById("mostrarElementos");
  lista.innerHTML = "";
  arreglo.forEach((elemento, index) => {

    let opcion = document.createElement("option");
    opcion.value = index;
    opcion.textContent = `${index}: ${elemento}`;
    lista.appendChild(opcion);
  });

  mostrar.textContent = JSON.stringify(arreglo);
}

function agregarElemento() {
  let nuevoElemento = document.getElementById("nuevoElemento").value;
  if (nuevoElemento) {
    arreglo.push(nuevoElemento);
    document.getElementById("nuevoElemento").value = "";
    actualizarLista();
  }
}

function modificarElemento() {
  let indice = parseInt(document.getElementById("indiceModificar").value);
  let valor = document.getElementById("valorModificar").value;
  if(!isNaN(indice) && indice >= 0 && indice < arreglo.length && valor){
    arreglo[indice] = valor;
    actualizarLista();
  }
}


function eliminarElemento(){
    let lista = document.getElementById("listaElementos");
    let indice = lista.value;
    if(indice !== ""){
        arreglo.splice(indice, 1);
        actualizarLista();
    }
}