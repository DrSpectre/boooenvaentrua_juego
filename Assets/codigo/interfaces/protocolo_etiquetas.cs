using System.Collections.Generic;
using UnityEngine;

public enum Etiquetas {
    jugador,
    enemigo,
    objeto,
    pista,

}


public interface ProtocoloEtiqueta {
    public List<Etiquetas> etiquetas { get; set; }

    public bool pertenezco_al_grupo(Etiquetas etiqueta);
}
