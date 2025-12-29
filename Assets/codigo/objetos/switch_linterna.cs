using System.Collections.Generic;
using UnityEngine;

public class switch_linterna : MonoBehaviour, ProtocoloInteraccion {
    public GameObject farola;
    private Light _farola;
    public EstadosInteracion estado { get; set; }
    void Start() {
        estado = EstadosInteracion.inactivo;
        _farola = farola.GetComponent<Light>();
        _farola.enabled = false;

    }

    public void accionar() {
        switch (estado) {
            case EstadosInteracion.activo:
                desactivar();
                break;

            case EstadosInteracion.inactivo:
                activar();
                break;
        }
    }

    public bool activar() {
        if (_farola == null || estado == EstadosInteracion.activo) {
            return false;
        }

        estado = EstadosInteracion.activo;
        _farola.enabled = true;
        
        return true;
    }

    public bool desactivar() {
        if (_farola == null || estado == EstadosInteracion.inactivo) {
            return false;
        }

        estado = EstadosInteracion.inactivo;
        _farola.enabled = false; 
        
        return true;
    }
}
