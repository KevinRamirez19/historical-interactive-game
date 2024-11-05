using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalZone : MonoBehaviour
{
    public Text mensajeUI; // Referencia al texto de UI para el mensaje final
    public GameObject zonaVisual; // Referencia al objeto visual de la zona final

    private void Start()
    {
        // Activar visualmente la zona final si hay un objeto asignado
        if (zonaVisual != null)
        {
            zonaVisual.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si el jugador ha entrado en la zona final
        if (other.CompareTag("Player"))
        {
            // Mostrar mensaje de victoria en la UI
            mensajeUI.text = "¡Felicidades! Has completado la misión.";
            Debug.Log("¡Felicidades! Has completado la misión.");

            // Aquí puedes añadir lógica para cargar otra escena o mostrar un menú de victoria.
        }
    }
}
