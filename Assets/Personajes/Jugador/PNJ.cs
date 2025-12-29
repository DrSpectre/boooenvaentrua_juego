using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

// Parte de lo que he seguido, con adecuaciones: https://www.youtube.com/watch?v=hgZgn1gZ_U0
[RequireComponent(typeof(Rigidbody))]
public class PNJ : MonoBehaviour {
    private CharacterController controlador;
    private Rigidbody cuerpo;
    private PlayerInput entradas;
    private InputAction movimiento;

    public Transform camara;
    public float velocidad = 0.5f;

    public float velocidad_rotacion = 0.1f;
    float tiempo_rotacion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        controlador = GetComponent<CharacterController>();
        cuerpo = GetComponent<Rigidbody>();
    }

    private void Awake() {
        entradas = GetComponent<PlayerInput>();
        movimiento = entradas.actions.FindAction("mover");
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 lectura_direccion = movimiento.ReadValue<Vector2>();

        Vector3 direccion = new Vector3(lectura_direccion.x, 0, lectura_direccion.y).normalized;

        if (direccion.magnitude >= 0.1) {
            actualizar_movimiento_RigidBody(direccion);
        }
    }

    void actualizar_movimiento_RigidBody(Vector3 direccion) { 
        float angulo_direccion = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.eulerAngles.y;

        float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo_direccion, ref tiempo_rotacion, velocidad_rotacion);

        transform.rotation = Quaternion.Euler(0f, angulo, 0f);

        Vector3 direccion_movimiento = (Quaternion.Euler(0f, angulo_direccion, 0f) * Vector3.forward).normalized;

       cuerpo.MovePosition(cuerpo.position + direccion_movimiento * velocidad);
    }

    void actualizar_movimiento_usando_CharactherController(Vector3 direccion) {
        float angulo_direccion = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.eulerAngles.y;

        float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo_direccion, ref tiempo_rotacion, velocidad_rotacion);

        transform.rotation = Quaternion.Euler(0f, angulo, 0f);

        Vector3 direccion_movimiento = (Quaternion.Euler(0f, angulo_direccion, 0f) * Vector3.forward).normalized;
        controlador.Move(direccion_movimiento * velocidad);
    }
}
