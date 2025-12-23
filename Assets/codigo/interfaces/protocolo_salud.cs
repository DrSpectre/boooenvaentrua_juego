using UnityEngine;

public interface ProtocoloSalud{
    void quitar_salud(int cantidad);
    void agregar_salud(int cantidad);

    void establecer_salud(int cantidad);
    void efectuar_muerte();
}
