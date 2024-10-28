using UnityEngine;

public class MinimapIcons : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public Transform activePoint; // Referencia al punto activo
    public SpriteRenderer playerIcon; // Icono del jugador
    public SpriteRenderer activePointIcon; // Icono del punto activo

    void Update()
    {
        // Actualiza la posición del ícono del jugador
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            playerPosition.y = playerIcon.transform.position.y; // Mantiene la altura
            playerIcon.transform.position = playerPosition;
        }

        // Actualiza la posición del ícono del punto activo
        if (activePoint != null)
        {
            Vector3 pointPosition = activePoint.position;
            pointPosition.y = activePointIcon.transform.position.y; // Mantiene la altura
            activePointIcon.transform.position = pointPosition;
        }
    }
}
