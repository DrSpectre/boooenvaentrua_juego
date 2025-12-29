using System;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaccion: MonoBehaviour{
    enum EstadosInteraccion {
        inactivo,
        activo
    }
    // Seccion diseñada para obtener la interaccion del usuario o pulsacion de teclas. 
    private PlayerInput entradas;
    private InputAction interactuar;
    // Seccion diseñada para identificar los objetos con colision para itneractuar
    private List<ProtocoloInteraccion> cosas_manejables = new List<ProtocoloInteraccion>();


    void Awake() {
        entradas = GetComponent<PlayerInput>();

        interactuar = entradas.actions.FindAction("interactuar");
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (cosas_manejables.Count > 0 && interactuar.WasPressedThisFrame()){
            Debug.Log($"La cantidad de objetos es {cosas_manejables.Count}");
            cosas_manejables[0].accionar();
            foreach (var objeto in cosas_manejables) {
                //Debug.Log($"Cosa interactuable: {objeto}");
                objeto.accionar();
            }
        }
    }
    
    void OnTriggerEnter(Collider colision){
        Debug.Log($"En trigger enter de {name} con {colision.name} entrando");
        var cosa = colision.GetComponent<Etiquetador>();

        var caracteristicas_del_objeto = colision.GetComponent<Caracteristicas>();
        ParLlaveValor[] caracteristcas_a_identificar = { new ParLlaveValor("farola", "clasica") }; 

        Debug.Log($"contiene las caracteristicas de una farola {caracteristicas_del_objeto.cumple_con(caracteristcas_a_identificar)}");

        if (cosa.pertenezco_al_grupo(Etiquetas.objeto)) {
            cosas_manejables.Add(colision.GetComponent<ProtocoloInteraccion>());
        }
    }

    void OnTriggerExit(Collider colision){
        Debug.Log($"En trigger exit de {name} con {colision.name} saliendo");
        var cosa = colision.GetComponent<Etiquetador>();

        if (cosa.pertenezco_al_grupo(Etiquetas.objeto)){ 
            cosas_manejables.Remove(colision.GetComponent<ProtocoloInteraccion>());
        }
    }
}
