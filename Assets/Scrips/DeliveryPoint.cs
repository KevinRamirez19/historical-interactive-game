using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necesario para manejar la UI

public class DeliveryPoint : MonoBehaviour
{
    private MissionManager missionManager;
    public int puntajePorEntrega = 50; // Puntaje otorgado por cada entrega
    public TMP_Text puntajeTexto; // Referencia al componente UI Text para mostrar el puntaje
    private int puntajeTotal = 0; // Variable para almacenar el puntaje total

    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;

    private void Start()
    {
        // Busca el objeto MissionManager en la escena
        missionManager = FindObjectOfType<MissionManager>();

        // Inicializa el puntaje en 0 en la UI
        ActualizarPuntajeUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Llama al método para manejar la entrega de mensajes en el MissionManager
            missionManager.OnMessageDelivered();

            // Incrementa el puntaje por la entrega
            puntajeTotal += puntajePorEntrega;

            // Actualiza el puntaje en la UI
            ActualizarPuntajeUI();
            puntaje.sumarPuntos(cantidadPuntos);
            Destroy(gameObject); // Opcional: Destruye el punto de entrega
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
