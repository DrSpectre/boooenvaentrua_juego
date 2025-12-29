using System.Collections.Generic;
using UnityEngine;

public class switch_linterna : MonoBehaviour, ProtocoloInteractuable {
    public GameObject farola;
    private Light _farola;
    public EstadosInteractuable estado { get; set; }
    void Start() {
        estado = EstadosInteractuable.inactivo;
        _farola = farola.GetComponent<Light>();
        _farola.enabled = false;

    }

    public void accionar() {
        switch (estado) {
            case EstadosInteractuable.activo:
                desactivar();
                break;

            case EstadosInteractuable.inactivo:
                activar();
                break;
        }
    }

    public bool activar() {
        if (_farola == null || estado == EstadosInteractuable.activo) {
            return false;
        }

        estado = EstadosInteractuable.activo;
        _farola.enabled = true;
        
        return true;
    }

    public bool desactivar() {
        if (_farola == null || estado == EstadosInteractuable.inactivo) {
            return false;
        }

        estado = EstadosInteractuable.inactivo;
        _farola.enabled = false; 
        
        return true;
    }
}
