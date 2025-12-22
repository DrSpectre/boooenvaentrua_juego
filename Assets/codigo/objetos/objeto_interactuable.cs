using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class ObjetoInteractuable : MonoBehaviour, ProtocoloInteraccion, ProtocoloEtiqueta {
    public EstadosInteracion estado { get; set; }
    public List<Etiquetas> etiquetas { get; set; }
    [SerializeField] public float temporizador;
    [SerializeReference] public GameObject objeto_a_activar;
    private ProtocoloInteraccion _objeto_a_activar;
    void Start() {
        estado = EstadosInteracion.inactivo;
        etiquetas = new List<Etiquetas>();
        etiquetas.Add(Etiquetas.objeto);

        if (objeto_a_activar != null) {
            _objeto_a_activar = objeto_a_activar.GetComponent<ProtocoloInteraccion>();
        }
    }

    // Update is called once per frame
    void Update() { }

    public bool pertenezco_al_grupo(Etiquetas etiqueta_a_buscar) {
        foreach (var etiqueta in etiquetas) {
            if (etiqueta == etiqueta_a_buscar)
                return true;
        }

        return false;
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
        if (estado == EstadosInteracion.activo) {
            return false;
        }
        estado = EstadosInteracion.activo;

        if (_objeto_a_activar != null) {
            _objeto_a_activar.accionar();
        }

        Debug.Log($"Accionando a {this.gameObject.name}");

        return true;
    }

    public bool desactivar() {
        if (estado == EstadosInteracion.inactivo) {
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

    public void OnDrawGizmos() {
        Gizmos.color = Color.violet;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
