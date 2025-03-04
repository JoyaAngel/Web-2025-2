#!/bin/bash

# Ruta del archivo donde se guardará la información del agente
env="$HOME/.ssh/agent.env"

# Cargar el entorno del agente si existe
agent_load_env() {
    [ -f "$env" ] && . "$env" >| /dev/null
}

# Iniciar el agente y guardar las variables de entorno
agent_start() {
    (umask 077; ssh-agent >| "$env")
    . "$env" >| /dev/null
    ssh-add ~/.ssh/id_rsa # Cambia esto si tu clave tiene otro nombre
}

# Verificar si el agente está corriendo
agent_load_env

# Comprobar el estado del agente
ssh-add -l >| /dev/null 2>&1
agent_run_state=$?

# Si el agente no está corriendo o no tiene claves, iniciarlo y agregar la clave
if [ -z "$SSH_AUTH_SOCK" ] || [ $agent_run_state -eq 2 ]; then
    echo "Iniciando ssh-agent y agregando clave..."
    agent_start
elif [ $agent_run_state -eq 1 ]; then
    echo "Agregando clave al agente..."
    ssh-add ~/.ssh/id_rsa
else
    echo "ssh-agent ya está corriendo con claves cargadas."
fi
