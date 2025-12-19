using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaccion: MonoBehaviour{
    enum estados_interaccion {
        inactivo,
        activo
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerInput entradas;
    private InputAction interactuar;
    void Awake() {
        entradas = GetComponent<PlayerInput>();

       interactuar = entradas.actions.FindAction("interactuar");
    }

    // Update is called once per frame
    void Update(){
        if(interactuar.ReadValue<float>() > 0){
            Debug.Log("Se ha pulsado la tecla de itneractuar");
        }

    }
}
