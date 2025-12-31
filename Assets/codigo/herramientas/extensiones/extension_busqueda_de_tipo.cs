using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Herramientas {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static TipoBuscado ObtenerElPrimerComponenteDeTipo<TipoBuscado>() where TipoBuscado : class {
        var raiz_objetos = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var raiz in raiz_objetos) {
            // GetComponentsInChildren works with interfaces directly!
            TipoBuscado componente = raiz.GetComponentInChildren<TipoBuscado>(true);

            if (componente != null) {
                return componente;
            }
        }

        return null;
    }

    public static TipoBuscado[] ObtenerComponentesDeTipo<TipoBuscado>() where TipoBuscado : class {
        var raiz_objetos = SceneManager.GetActiveScene().GetRootGameObjects();
        TipoBuscado[] componentes = { };

        foreach (var raiz in raiz_objetos) {
            // GetComponentsInChildren works with interfaces directly!
            TipoBuscado componente = raiz.GetComponentInChildren<TipoBuscado>(true);

            if (componente != null) {
                componentes.Append<TipoBuscado>(componente);
            }
        }

        return componentes;
    }
}
