using UnityEngine;
using UnityEngine.AI;

public class SoldierEnemy : MonoBehaviour
{
    public float detectionRange = 10f; // Rango de detección del jugador
    private Transform player; // Referencia al transform del jugador
    private NavMeshAgent navAgent; // Referencia al NavMeshAgent

    void Start()
    {
        // Encuentra el jugador por la etiqueta
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Verifica si se encontró el jugador
        if (player == null)
        {
            Debug.LogError("No se encontró el objeto con la etiqueta 'Player'. Asegúrate de que exista en la escena.");
            return;
        }

        // Obtén el componente NavMeshAgent
        navAgent = GetComponent<NavMeshAgent>();

        // Verifica si el NavMeshAgent está asignado
        if (navAgent == null)
        {
            Debug.LogError("El objeto enemigo no tiene un componente NavMeshAgent.");
            return;
        }
    }

    void Update()
    {
        // Verifica la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Si el jugador está dentro del rango, mueve el agente hacia el jugador
            Debug.Log("Jugador detectado, persiguiendo..."); // Mensaje de depuración
            navAgent.SetDestination(player.position);
        }
        else
        {
            // Si el jugador está fuera del rango, puedes optar por detener al agente
            Debug.Log("Jugador fuera de rango."); // Mensaje de depuración
            navAgent.ResetPath(); // Esto detiene el movimiento del agente
        }

        // Mensaje para verificar si el NavMeshAgent está en movimiento
        if (navAgent.hasPath)
        {
            Debug.Log("El enemigo se está moviendo hacia el jugador.");
        }
        else
        {
            Debug.Log("El enemigo no tiene un camino hacia el jugador.");
        }
    }
}

