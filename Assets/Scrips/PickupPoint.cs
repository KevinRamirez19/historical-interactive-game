using UnityEngine;
using UnityEngine.UI; // Necesario para manejar la UI

public class PickupPoint : MonoBehaviour
{
    public int currentPickupIndex; // Índice del punto de recogida
    private MissionManager missionManager;
    public int puntajePorRecolecta = 20; // Puntaje por recoger un objeto
    public Text puntajeTexto; // Referencia al componente UI Text para mostrar el puntaje
    private int puntajeTotal = 0; // Variable para almacenar el puntaje total (compartida con el sistema de entrega)

    private void Start()
    {
        // Busca el objeto MissionManager en la escena
        missionManager = FindObjectOfType<MissionManager>();

        // Inicializa el puntaje en la UI
        ActualizarPuntajeUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            if (missionManager != null && missionManager.CanPickup(currentPickupIndex)) // Verifica si el índice de recogida es válido
            {
                // Llama al método para manejar la recogida de mensajes en el MissionManager
                missionManager.OnMessagePickedUp();

                // Incrementa el puntaje por la recogida
                puntajeTotal += puntajePorRecolecta;

                // Actualiza el puntaje en la UI
                ActualizarPuntajeUI();

                Destroy(gameObject); // Opcional: Destruye el punto de recogida
            }
        }
    }

    // Método para actualizar el puntaje en la UI
    private void ActualizarPuntajeUI()
    {
        if (puntajeTexto != null)
        {
            puntajeTexto.text = "Puntaje: " + puntajeTotal.ToString();
        }
    }
}
