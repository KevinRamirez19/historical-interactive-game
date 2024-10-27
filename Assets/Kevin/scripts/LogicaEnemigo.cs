using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LogicaEnemigo : MonoBehaviour
{
    private GameObject target; // Referencia al jugador
    private NavMeshAgent agente; // Componente de navegación
    public float detectionRange = 10f; // Rango de detección para perseguir
    public float attackRange = 2f; // Rango para atacar
    public int attackDamage = 10; // Daño por ataque
    public float attackCooldown = 2f; // Tiempo entre ataques

    private Animator animator; // Controlador de animaciones
    private bool canAttack = true; // Control del tiempo de ataque

    void Start()
    {
        target = GameObject.Find("Player"); // Asegúrate de que el objeto del jugador se llame "Player"
        agente = GetComponent<NavMeshAgent>(); // Obtén el componente NavMeshAgent
        animator = GetComponent<Animator>(); // Obtén el componente Animator
    }

    void Update()
    {
        if (target != null)
        {
            Perseguir();
        }
        else
        {
            Debug.LogWarning("El jugador no se encontró en la escena.");
        }
    }

    void Perseguir()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance <= attackRange) // Si está en rango de ataque
        {
            agente.ResetPath(); // Detener al enemigo
            if (canAttack)
            {
                StartCoroutine(Atacar());
            }
        }
        else if (distance < detectionRange) // Si está dentro del rango de detección
        {
            agente.SetDestination(target.transform.position); // Persigue al jugador
        }
        else
        {
            agente.ResetPath(); // Fuera de rango, detiene al enemigo
        }
    }

    IEnumerator Atacar()
    {
        canAttack = false; // Deshabilitar ataque hasta que pase el cooldown
        animator.SetTrigger("Attack"); // Activar la animación de ataque
        yield return new WaitForSeconds(0.5f); // Espera antes de aplicar el daño (sincronizar con la animación)

        // Aplicar daño si el jugador aún está cerca
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackRange)
        {
            target.GetComponent<Player_Move>().TakeDamage(attackDamage); // Llamar al método para reducir la vida del jugador
            Debug.Log("El jugador recibió " + attackDamage + " puntos de daño.");
        }

        yield return new WaitForSeconds(attackCooldown); // Esperar el cooldown antes del próximo ataque
        canAttack = true; // Permitir atacar de nuevo
    }
}
