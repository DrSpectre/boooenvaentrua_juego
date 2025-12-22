using Unity.VisualScripting;
using UnityEngine;

public class GizmoCaja: MonoBehaviour{
    public Color color = Color.violet.WithAlpha(0.5f);
    public void OnDrawGizmos() {
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
