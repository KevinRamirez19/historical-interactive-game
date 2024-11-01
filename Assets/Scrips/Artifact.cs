using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Objeto : MonoBehaviour
{
    private MissionBB missionManager;

    public string mensaje = "Has recogido el objeto"; // Mensaje personalizado para cada objeto

    private void Start()
    {
        // Encontrar el MissionBB en la escena
        missionManager = FindObjectOfType<MissionBB>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Llama al método de recogida en el MissionBB
            missionManager.RecogerObjeto(gameObject);
        }
    }
}
