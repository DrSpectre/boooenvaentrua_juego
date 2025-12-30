using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BotonBasico : MonoBehaviour {
    private Button boton;
    void Start() {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(accion_a_perfomar);
    }

    void accion_a_perfomar() {
        Debug.Log($"Pero mira, que has pulsado el boton {name}");
    }
}
