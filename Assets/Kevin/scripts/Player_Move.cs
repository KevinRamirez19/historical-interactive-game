using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Necesario para la barra de vida

public class Player_Move : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public Animator animator;

    private float x, y;

    // Variables para la vida del personaje
    public int maxHealth = 100; // Vida máxima del personaje
    private int currentHealth; // Vida actual del personaje

    // Barra de vida (debe conectarse en el Inspector)
    public Slider healthBar;

    // Variables para el salto
    public float jumpForce = 5f; // Fuerza del salto
    public Transform groundCheck; // Transform para comprobar si está en el suelo
    public float groundDistance = 0.2f; // Distancia desde el personaje al suelo
    public LayerMask groundMask; // Capa que identifica el suelo
    private bool isGrounded; // Si el personaje está en el suelo
    public Rigidbody rb; // Rigidbody del personaje

    void Start()
    {
        // Inicializamos la vida del personaje
        currentHealth = maxHealth;

        // Inicializamos la barra de vida
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        // Movimiento del personaje
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        animator.SetFloat("Velx", x);
        animator.SetFloat("VelY", y);

        // Comprobar si el personaje está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Saltar cuando se presiona la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Aplicar la fuerza del salto
            animator.SetTrigger("Jump"); // Reproducir animación de salto (si existe)
        }

        // Simulamos que el personaje recibe daño (presionando la tecla H)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10); // Recibe 10 de daño
        }
    }

    // Método para que el personaje reciba daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Actualizar la barra de vida
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die(); // Si la vida llega a 0, el personaje muere
        }
    }

    // Método que simula la muerte del personaje
    void Die()
    {
        Debug.Log("El personaje ha muerto");
        // Aquí puedes añadir lógica adicional como reiniciar el nivel, etc.
    }
}