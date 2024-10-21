using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public GameObject player; // Referencia al jugador
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo
    public int damageAmount = 5; // Cantidad de daño que inflige el enemigo

    public float attackRange = 1.5f; // Rango de ataque
    public float detectionRadius = 10f; // Radio de la zona de detección

    private Vector3 initialPosition; // Posición inicial del enemigo
    private bool isPlayerInRange = false;
    private bool isAttacking = false; // Controla si el enemigo está atacando
    private bool isReturning = false; // Controla si el enemigo está regresando a su posición

    void Start()
    {
        initialPosition = transform.position; // Guarda la posición inicial del enemigo
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Verifica si el jugador está dentro del radio de detección
        if (distanceToPlayer <= detectionRadius)
        {
            isPlayerInRange = true;
            MoveTowardsPlayer(); // Persigue al jugador
        }
        else
        {
            isPlayerInRange = false;
            if (!isReturning)
            {
                StartCoroutine(ReturnToInitialPosition()); // Vuelve a la posición inicial
            }
        }
    }

    void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Moverse hacia el jugador si está fuera del rango de ataque
        if (distanceToPlayer > attackRange)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else if (!isAttacking)
        {
            StartCoroutine(AttackPlayer()); // Comienza el ataque si está dentro del rango de ataque
        }
    }

    IEnumerator ReturnToInitialPosition()
    {
        isReturning = true; // Comienza el retorno
        while (Vector3.Distance(transform.position, initialPosition) > 0.1f) // Mientras no esté cerca de la posición inicial
        {
            Vector3 direction = (initialPosition - transform.position).normalized; // Dirección hacia la posición inicial
            transform.position += direction * moveSpeed * Time.deltaTime; // Mueve al enemigo hacia su posición inicial
            yield return null; // Espera un frame
        }
        isReturning = false; // Ha regresado a la posición inicial
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;

        while (isPlayerInRange) // Mientras el jugador esté en la zona de detección
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // Comprobar si el jugador está dentro del rango de ataque
            if (distanceToPlayer <= attackRange)
            {
                // Inflige daño al jugador
                Player_Move playerMove = player.GetComponent<Player_Move>();
                if (playerMove != null)
                {
                    Debug.Log("Atacando al jugador, infligiendo daño.");
                    playerMove.TakeDamage(damageAmount); // Aplica daño
                }
            }

            // Espera 1 segundo antes de volver a atacar
            yield return new WaitForSeconds(1f);
        }

        isAttacking = false;
    }

    void OnDrawGizmos()
    {
        // Dibuja el radio de detección en la escena para depuración
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
