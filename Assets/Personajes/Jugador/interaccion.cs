using System;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaccion: MonoBehaviour{
    enum EstadosInteraccion {
        inactivo,
        activo
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerInput entradas;
    private InputAction interactuar;
    private EstadosInteraccion estado = EstadosInteraccion.inactivo;

    void Awake() {
        entradas = GetComponent<PlayerInput>();

       interactuar = entradas.actions.FindAction("interactuar");
    }

    // Update is called once per frame
    void Update(){
        if (estado == EstadosInteraccion.activo && interactuar.ReadValue<float>() > 0){
            Debug.Log("Se ha pulsado la tecla de itneractuar");
        }
    }

    void OllisionEnter(Collision collision){
        Debug.Log($"Colision con {collision.collider.name}");
        
    }
    
    void OnTriggerEnter(Collider colision){
        if(colision.gameObject.tag == "interactuable"){
            estado = EstadosInteraccion.activo;
        }
    }

    void OnTriggerExit(Collider colision){
        if(colision.gameObject.tag == "interactuable"){
            estado = EstadosInteraccion.inactivo;
        }
    }
}
