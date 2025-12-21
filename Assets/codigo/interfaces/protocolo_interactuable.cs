using System;
using UnityEngine;

public enum EstadosInteracion{
    activo,
    inactivo,
}
public interface ProtocoloInteraccion{
    public EstadosInteracion estado { get; set; }
    Boolean activar();
    Boolean desactivar();
    void accionar();
}
