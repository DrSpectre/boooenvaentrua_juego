using UnityEngine;

public enum EstadosInterfaz {
    limpio,
    mostrando_leyenda,
    mostrando_imagen,
    mostrando_
}

public interface ProtocoloDirectorInterfaz {
    public EstadosInterfaz estado { get; set; }

    public bool activar_elemento(string nombre);

    public bool desactivar_elemento(string nombre);

    public bool limpiar_interfaz();
}
