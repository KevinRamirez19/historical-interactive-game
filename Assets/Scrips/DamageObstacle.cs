using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObstacle : MonoBehaviour
{
    public int damageAmount = 5; // Cantidad de daño que inflige el obstáculo cada 3 segundos
    private bool playerInContact = false; // Para saber si el jugador está en contacto con el obstáculo
    private PlayerMove player; // Referencia al script del jugador
    private Coroutine damageCoroutine; // Para controlar la corutina de daño

    // Detecta cuando el jugador entra en el Trigger del obstáculo
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador
        if (other.CompareTag("Projecto"))
        {
            player = other.GetComponent<PlayerMove>();
            if (player != null)
            {
                playerInContact = true;
                // Inicia la corutina para infligir daño cada 3 segundos
                damageCoroutine = StartCoroutine(ApplyDamageOverTime());
            }
        }
    }

    // Detecta cuando el jugador sale del Trigger del obstáculo
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projecto") && playerInContact)
        {
            playerInContact = false;
            // Detenemos la corutina cuando el jugador sale del obstáculo
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }

    // Corutina que inflige daño al jugador cada 3 segundos
    IEnumerator ApplyDamageOverTime()
    {
        while (playerInContact)
        {
            yield return new WaitForSeconds(1); // Espera 3 segundos
            if (playerInContact) // Si el jugador sigue en contacto con el obstáculo
            {
                player.TakeDamage(damageAmount); // Inflige daño
            }
        }
    }
}
