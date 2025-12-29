using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Etiquetador))] // Aqui idnicamos que tenemos una dependencia de objetos o componentes para funcionar y evitar errores en utilizacion
public class ObjetoInteractuable : MonoBehaviour, ProtocoloInteractuable {
    public EstadosInteractuable estado { get; set; }
    [SerializeField] public float temporizador;
    [SerializeReference] public GameObject objeto_a_activar;
    private ProtocoloInteractuable _objeto_a_activar;
    void Start() {
        estado = EstadosInteractuable.inactivo;

        if (objeto_a_activar != null) {
            _objeto_a_activar = objeto_a_activar.GetComponent<ProtocoloInteractuable>();
        }
    }

    // Update is called once per frame
    void Update() { }


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
        if (estado == EstadosInteractuable.activo) {
            return false;
        }
        estado = EstadosInteractuable.activo;

        if (_objeto_a_activar != null) {
            _objeto_a_activar.accionar();
        }

        Debug.Log($"Accionando a {this.gameObject.name}");

        return true;
    }

    public bool desactivar() {
        if (estado == EstadosInteractuable.inactivo) {
            return false;
        }

        return true;
    }

    void OnTriggerEnter(Collider entrante) {
        Debug.Log($"Con {this.name} esta entrando {entrante.name}");
    }

    private void OnTriggerExit(Collider saliente) {
        Debug.Log($"Con {this.name} esta saliendo {saliente.name}");
    }
}
