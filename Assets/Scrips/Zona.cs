using UnityEngine;

public class PlayerOnlyTrigger : MonoBehaviour
{
    // Este método se ejecuta cuando un objeto entra en el BoxCollider
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("El objeto con etiqueta 'Player' ha ingresado al área.");
            // Aquí puedes agregar la funcionalidad que desees activar para el jugador
        }
        else
        {
            Debug.Log("Objeto no autorizado intentó ingresar.");
            // Evitar que el enemigo entre en el área
            PreventEnemyEntry(other);
        }
    }

    // Método para evitar que los enemigos entren
    private void PreventEnemyEntry(Collider enemy)
    {
        // Verifica si el objeto tiene un Rigidbody
        Rigidbody rb = enemy.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Calcula la dirección desde el centro del BoxCollider hasta el enemigo
            Vector3 direction = enemy.transform.position - transform.position;
            direction.Normalize(); // Normaliza la dirección

            // Aplica una fuerza en la dirección opuesta al centro del BoxCollider
            rb.AddForce(direction * 10f, ForceMode.Impulse); // Ajusta la fuerza según sea necesario
        }
    }

    // Este método se ejecuta cuando un objeto sale del BoxCollider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El objeto con etiqueta 'Player' ha salido del área.");
            // Puedes agregar funcionalidad para cuando el jugador salga
        }
    }
}
