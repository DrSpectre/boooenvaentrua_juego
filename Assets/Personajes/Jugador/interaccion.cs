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
    void Update(){
        if (cosas_manejables.Count > 0 && interactuar.ReadValue<float>() > 0){
            Debug.Log($"La cantidad de objetos es {cosas_manejables.Count}");
            cosas_manejables[0].activar();
        }
    }
    
    void OnTriggerEnter(Collider colision){
        Debug.Log($"En trigger enter con {colision.name}");
        var cosa = colision.GetComponent<ProtocoloInteraccion>();
        
        if (cosa != null){
            cosas_manejables.Add(cosa);
        }
        
    }

    void OnTriggerExit(Collider colision){
        var cosa = colision.GetComponent<ProtocoloInteraccion>();
        
        if (cosa != null){
            cosas_manejables.Remove(cosa);
        }
    }
}
