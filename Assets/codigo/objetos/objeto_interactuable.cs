using System;
using UnityEngine;

public class ObjetoInteractuable: MonoBehaviour, ProtocoloInteraccion{
    public EstadosInteracion estado { get; set; }
    void Start(){
        estado = EstadosInteracion.inactivo;
    }

    // Update is called once per frame
    void Update(){

    }

    public void accionar(){
        switch (estado) {
            case EstadosInteracion.activo:
                desactivar();
                break;
            case EstadosInteracion.inactivo:
                activar();
                break;
        }
    }

    public bool activar(){
        if (estado == EstadosInteracion.activo) {
            return false;
        }

        return true;
    }

    public bool desactivar(){
        if (estado == EstadosInteracion.inactivo) {
            return false;
        }

        return true;
    }

    void OnTriggerEnter(Collider entrante){
        Debug.Log($"Con {this.name} esta entrando {entrante.name}");
    }

    private void OnTriggerExit(Collider saliente){
        Debug.Log($"Con {this.name} esta saliendo {saliente.name}");
    }
}
