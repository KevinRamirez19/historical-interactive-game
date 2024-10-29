using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el jugador ha entrado en la zona final
        if (other.CompareTag("Player"))
        {

            // Opción 2: Mostrar un mensaje de victoria (puedes usar un Canvas para esto)
            Debug.Log("¡Felicidades! Has completado la misión.");
            // Aquí podrías activar un UI que muestre un mensaje de éxito
        }
    }
}
