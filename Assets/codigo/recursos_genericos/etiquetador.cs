using System;
using System.Linq;
using UnityEditor.PackageManager;
using UnityEngine;

public class Etiquetador: MonoBehaviour, ProtocoloEtiqueta{
    public Etiquetas[] etiquetas;

    void Start() {
        if (etiquetas.Count<Etiquetas>() == 0) {
            throw new Exception("No hay etiquetas asiganadas a este objeto");
        }
    }

    public bool pertenezco_al_grupo(Etiquetas etiqueta_a_buscar) {
        foreach (var etiqueta in etiquetas) {
            if (etiqueta == etiqueta_a_buscar)
                return true;
        }

        return false;
    }
}
