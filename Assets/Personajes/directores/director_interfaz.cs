using System.Collections.Generic;
using UnityEngine;

public class DirectorUI : MonoBehaviour, ProtocoloDirectorInterfaz {
    // Este componente sirve para poder modificar el UI en timepo real y comunicar diferentes partes entre si. 

    public EstadosInterfaz estado { get; set; }

    public GameObject interfaz;
    private Dictionary<string, GameObject> elementos_del_interfaz;

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public bool activar_elemento(string nombre) {
        interfaz.SetActive(true);
        return true;
    }

    public bool desactivar_elemento(string nombre) {
        interfaz.SetActive(false);
        return true;
    }

    public bool limpiar_interfaz() {
        interfaz.SetActive(false);
        return true;
    }
}
