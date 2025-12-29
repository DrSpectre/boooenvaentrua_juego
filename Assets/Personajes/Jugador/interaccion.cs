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

        interactuar.performed += realizar_interaccion;  // Esta accion se ejecuta cuando el jugador pulsa el boton y solo una vez
        // interactuar.canceled += actualizar_pulsacion; // este es caundo se deja de pulsar o finaliza la pulsación
        // interactuar.started += actualizar_pulsacion;  // Este se manda a llamar cuando apenas se acaba de pulsar el boton. 
    }

    // Update is called once per frame
    void realizar_interaccion(InputAction.CallbackContext _) {
        if (cosas_manejables.Count > 0 && interactuar.WasPressedThisFrame()) {
            // Debug.Log($"La cantidad de objetos es {cosas_manejables.Count}");
            foreach (var objeto in cosas_manejables) {
                // Debug.Log($"Cosa interactuable: {objeto}");
                objeto.accionar();
            }
        }
    }

    // Este solo funciona para observar la informacion que se pasa y tener una mejor idea de lo que esta mandando y funciona.
    void actualizar_pulsacion(InputAction.CallbackContext contexto) {
        Debug.Log($"HOla mundo:: CONTEXTO: {contexto} ::");
    }

    void OnTriggerEnter(Collider colision){
        // Debug.Log($"En trigger enter de {name} con {colision.name} entrando");
        var cosa = colision.GetComponent<Etiquetador>();

        // Fragmento diseñado para generar un fitlro de objetos para identificar reglas especificas de interaccion.
        // var caracteristicas_del_objeto = colision.GetComponent<Caracteristicas>();
        // ParLlaveValor[] caracteristcas_a_identificar = { new ParLlaveValor("farola", "clasica") }; 

        // Debug.Log($"contiene las caracteristicas de una farola {caracteristicas_del_objeto.cumple_con(caracteristcas_a_identificar)}");

        if (cosa.pertenezco_al_grupo(Etiquetas.objeto)) { // Condicional apra identificar que hacer y como interactuar con el objeto
            if (!cosas_manejables.Contains(colision.GetComponent<ProtocoloInteraccion>())) { // Condicional para evitar agregar multiples instancias del objeto y tener problemas despues.
                cosas_manejables.Add(colision.GetComponent<ProtocoloInteraccion>());
            }
        }
    }

    void OnTriggerExit(Collider colision){
        // Debug.Log($"En trigger exit de {name} con {colision.name} saliendo");
        var cosa = colision.GetComponent<Etiquetador>();

        if (cosa.pertenezco_al_grupo(Etiquetas.objeto)){ 
            cosas_manejables.Remove(colision.GetComponent<ProtocoloInteraccion>());
        }
    }
}
