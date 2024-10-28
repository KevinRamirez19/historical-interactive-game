using UnityEngine;

public class FlagEnemy : MonoBehaviour
{
    public GameObject canvasCaptura; // Referencia al Canvas.

    private bool isCarried = false; // Bandera capturada o no.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCarried) // Si es el jugador y no está capturada.
        {
            Debug.Log("¡Has capturado la bandera enemiga!");
            isCarried = true;
            this.gameObject.SetActive(false); // Desactiva la bandera.

            // Muestra el Canvas.
            if (canvasCaptura != null)
            {
                canvasCaptura.SetActive(true);
            }
            else
            {
                Debug.LogError("No se asignó el CanvasCaptura.");
            }

            // Marca que el jugador tiene la bandera.
            other.GetComponent<PlayerController>().HasFlag = true;
        }
    }
}
