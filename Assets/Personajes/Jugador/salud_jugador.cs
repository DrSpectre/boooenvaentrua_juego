using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProtocoloMuerte))]
public class SaludJugador: MonoBehaviour, ProtocoloSalud {
    [SerializeField] int salud = 100;
    ProtocoloMuerte[] _efectos_de_muerte;
    public GameObject[] elementos_ui;
    private List<ProtocoloIndicadorSalud> indicadores_salud { get; set; }


    void Awake() {
        _efectos_de_muerte = GetComponents<ProtocoloMuerte>();

        indicadores_salud = new List<ProtocoloIndicadorSalud>();

        foreach (var elemento_ui in elementos_ui) {
            var indicador = elemento_ui.GetComponent<ProtocoloIndicadorSalud>();

            if (indicador != null) {
                indicadores_salud.Add(indicador);
            }
        }
    }

    public void quitar_salud(int cantidad) {
        salud -= cantidad;
        if (salud < 0) {
            efectuar_muerte();
        }
    }

    public void agregar_salud(int cantidad) {
        salud += cantidad;
    }

    public void establecer_salud(int cantidad) {
        salud = cantidad;
    }

    public void efectuar_muerte() {
        foreach (var efecto in _efectos_de_muerte) {
            efecto.activar();
        }
    }
}
