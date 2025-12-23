using UnityEngine;

public interface ProtocoloIndicadorSalud {
    void establecer_valor_maximo(int valor_maximo);

    void actualizar_barra(int nueva_cantidad);
}
