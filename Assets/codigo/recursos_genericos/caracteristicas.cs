using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Caracteristicas: MonoBehaviour {
    public Dictionary<string, string> _caracteristicas = new Dictionary<string, string>();

    public ParLlaveValor[] caracteristicas;

    void Start() {
        foreach (var caracteristica in caracteristicas) {
            _caracteristicas.Add(caracteristica.llave, caracteristica.valor);
        }
    }

    public bool cumple_con(ParLlaveValor[] caracteristicas) {
        int cantidad_caracteristicas = 0;

        foreach (var caracteristica in caracteristicas) {
            if (_caracteristicas.ContainsKey(caracteristica.llave)) {
                if (_caracteristicas[caracteristica.llave] == caracteristica.valor) {
                    cantidad_caracteristicas++;
                }
            }
        }

        return cantidad_caracteristicas == caracteristicas.Count();
    }

}

[System.Serializable]
public class ParLlaveValor {
    public string llave;
    public string valor;

    public ParLlaveValor(string llave_nueva, string valor_nuevo) {
        llave = llave_nueva;
        valor = valor_nuevo;
    }
}