using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool HasFlag = false; // Indica si el jugador tiene la bandera.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BaseAliada") && HasFlag) // Verifica si llegó a la base aliada con la bandera.
        {
            Debug.Log("¡Has llevado la bandera a la base aliada!");
            HasFlag = false; // Resetea el estado del jugador.
            // Aquí puedes activar un evento de victoria o sumar puntos.
        }
    }
}
