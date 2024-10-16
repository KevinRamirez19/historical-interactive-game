using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEnemigo : MonoBehaviour
{
    public GameObject player; // Referencia al jugador
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo
    public int damageAmount = 5; // Cantidad de daño que inflige el enemigo (cambiado a 5)

    public Transform detectionZone; // Zona de detección
    public float attackRange = 1.5f; // Rango de ataque

    private bool isPlayerInRange = false;
    private bool isAttacking = false; // Para controlar si ya está atacando

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en el campo de detección es el jugador
        if (other.gameObject == player)
        {
            isPlayerInRange = true; // El jugador ha entrado en la zona de detección
            if (!isAttacking)
            {
                StartCoroutine(AttackPlayer()); // Comienza a atacar si no está atacando ya
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que salió del campo de detección es el jugador
        if (other.gameObject == player)
        {
            isPlayerInRange = false; // El jugador ha salido de la zona de detección
            StopCoroutine(AttackPlayer()); // Detiene el ataque cuando el jugador sale
            isAttacking = false; // Reinicia el estado de ataque
        }
    }

    void Update()
    {
        // Si el jugador está dentro de la zona de detección, el enemigo lo persigue
        if (isPlayerInRange)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Mover al enemigo hacia el jugador si está fuera del rango de ataque
        if (distanceToPlayer > attackRange)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator AttackPlayer()
    {
        isAttacking = true;

        while (isPlayerInRange) // Mientras el jugador esté en la zona de detección
        {
            // Comprobar si el jugador está dentro del rango de ataque
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= attackRange)
            {
                // Inflige daño al jugador
                PlayerMove playerMove = player.GetComponent<PlayerMove>();
                if (playerMove != null)
                {
                    playerMove.TakeDamage(damageAmount);
                }
            }

            // Espera 3 segundos antes de volver a atacar
            yield return new WaitForSeconds(3f);
        }

        isAttacking = false;
    }
}
