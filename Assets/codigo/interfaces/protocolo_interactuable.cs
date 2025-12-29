using System;
using UnityEngine;

public enum EstadosInteractuable {
    activo,
    inactivo,
}

public interface ProtocoloInteractuable{
    public EstadosInteractuable estado { get; set; }
    Boolean activar();
    Boolean desactivar();
    void accionar();
}
