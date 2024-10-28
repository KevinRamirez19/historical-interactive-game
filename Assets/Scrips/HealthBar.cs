using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider healthBar;

    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método que simula la muerte del personaje
    void Die()
    {
        puntaje.sumarPuntos(cantidadPuntos); 
        Destroy(gameObject);
        Debug.Log("El enemigo ha muerto");
    }
}
