using System.Collections.Generic;
using UnityEngine;

public class switch_linterna : MonoBehaviour, ProtocoloInteraccion {
    public GameObject farola;
    public EstadosInteracion estado { get; set; }
    void Start() {
        estado = EstadosInteracion.inactivo;
    }

    public void accionar() {
        switch (estado) {
            case EstadosInteracion.activo:
                activar();
                break;

            case EstadosInteracion.inactivo:
                desactivar();
                break;
        }
    }

    public bool activar() {
        if (farola == null || estado == EstadosInteracion.activo) {
            return false;
        }

        estado = EstadosInteracion.activo;
        farola.SetActive(true);
        
        return true;
    }

    public bool desactivar() {
        if (farola == null || estado == EstadosInteracion.inactivo) {
            return false;
        }

        estado = EstadosInteracion.inactivo;
        farola.SetActive(true);
        
        return true;
    }
}
