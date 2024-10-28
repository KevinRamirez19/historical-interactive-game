using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    public Transform player; // Referencia al jugador 
    public float detectionRange = 10f; // Rango de detección para empezar a perseguir al jugador
    public float moveSpeed = 2f; // Velocidad del dron
    public float damageAmount = 5f; // Daño que hace el dron al jugador cuando lo alcanza
    public float attackDistance = 1.5f; // Distancia mínima para atacar al jugador
    public float attackCooldown = 2f; // Tiempo de espera entre ataques
    private bool canAttack = true; // Controla si el dron puede atacar o no

    private Player_Move playerMove; // Referencia al script del jugador

    void Start()
    {
        // Encuentra al jugador usando su tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerMove = playerObject.GetComponent<Player_Move>(); // Referencia al script del jugador
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calcula la distancia entre el dron y el jugador
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Si el jugador está dentro del rango de detección, el dron lo persigue
            if (distanceToPlayer <= detectionRange)
            {
                // Persigue al jugador
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
                transform.LookAt(player); // El dron mira al jugador

                // Si el dron está lo suficientemente cerca del jugador, intenta atacar
                if (distanceToPlayer <= attackDistance && canAttack)
                {
                    StartCoroutine(AttackPlayer());
                }
            }
        }
    }

    // Corutina para atacar al jugador y aplicar daño
    IEnumerator AttackPlayer()
    {
        canAttack = false; // Desactiva la capacidad de atacar temporalmente

        if (playerMove != null)
        {
            playerMove.TakeDamage((int)damageAmount); // Aplica el daño al jugador
            Debug.Log("Dron ha causado daño al jugador");
        }

        yield return new WaitForSeconds(attackCooldown); // Espera antes de poder atacar nuevamente
        canAttack = true; // Vuelve a permitir atacar
    }

    // Método para visualizar el rango de detección en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange); // Dibuja el rango de detección
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackDistance); // Dibuja la distancia de ataque
    }
}
