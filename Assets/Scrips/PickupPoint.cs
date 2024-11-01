using UnityEngine;
using UnityEngine.UI; // Necesario para manejar la UI
using TMPro;
using System.Collections;
using UnityEngine.Networking; // Necesario para manejar TextMeshPro

public class PickupPoint : MonoBehaviour
{
    public int currentPickupIndex; // Índice del punto de recogida
    private MissionManager missionManager;
    public int puntajePorRecolecta = 20; // Puntaje por recoger un objeto
    public Text puntajeTexto; // Referencia al componente UI Text para mostrar el puntaje
    private int puntajeTotal = 0; // Variable para almacenar el puntaje total (compartida con el sistema de entrega)

    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    [SerializeField] private Canvas mensajeRecolectaCanvas; // Canvas para mostrar mensaje al jugador
    private float mensajeDuracion = 6f; // Duración en segundos para mostrar el mensaje

    private void Start()
    {
        // Busca el objeto MissionManager en la escena
        missionManager = FindObjectOfType<MissionManager>();

        // Inicializa el puntaje en la UI
        ActualizarPuntajeUI();

        // Asegura que el canvas esté oculto al inicio
        if (mensajeRecolectaCanvas != null)
        {
            mensajeRecolectaCanvas.gameObject.SetActive(false);
        }
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
                puntaje.sumarPuntos(cantidadPuntos);

                // Muestra el canvas de recolección
                MostrarMensajeRecolecta();

                // Destruye el punto de recogida después de mostrar el mensaje
                Destroy(gameObject, mensajeDuracion); // Opcional: Destruye después de mostrar el mensaje
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

    // Método para mostrar el canvas de recolección
    private void MostrarMensajeRecolecta()
    {
        if (mensajeRecolectaCanvas != null)
        {
            mensajeRecolectaCanvas.gameObject.SetActive(true);
            Invoke(nameof(OcultarMensajeRecolecta), mensajeDuracion); // Oculta el canvas después de 6 segundos
        }
    }

    // Método para ocultar el canvas de recolección
    private void OcultarMensajeRecolecta()
    {
        if (mensajeRecolectaCanvas != null)
        {
            mensajeRecolectaCanvas.gameObject.SetActive(false);
        }
    }
}
