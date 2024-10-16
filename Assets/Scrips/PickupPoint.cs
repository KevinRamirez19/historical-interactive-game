using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoint : MonoBehaviour
{
    private MissionManager missionManager;

    private void Start()
    {
        // Busca el objeto MissionManager en la escena
        missionManager = FindObjectOfType<MissionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Llama al método para manejar la recogida de mensajes en el MissionManager
            missionManager.OnMessagePickedUp();
            Destroy(gameObject); // Opcional: Destruye el punto de recogida
        }
    }
}
