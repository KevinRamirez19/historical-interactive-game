using UnityEngine;

public class FlagEnemy : MonoBehaviour
{
    private bool isCarried = false; // Indica si la bandera fue recogida.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCarried) // Verifica si el jugador la tocó.
        {
            Debug.Log("¡Has capturado la bandera enemiga!");
            isCarried = true;
            this.gameObject.SetActive(false); // Desactiva la bandera de la escena.
            other.GetComponent<PlayerController>().HasFlag = true; // Asigna la bandera al jugador.
        }
    }
}
