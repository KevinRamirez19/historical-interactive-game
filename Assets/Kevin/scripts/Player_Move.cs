using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public Animator animator;

    private float x, y;

    public float fuerzaDeSalto = 8f;

    // Variables para la vida del personaje
    public int maxHealth = 100;
    private int currentHealth;

    // Barra de vida
    public Slider healthBar;

    // Variables para el salto
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    private bool isGrounded;
    private bool isJumping = false;
    public Rigidbody rb;

    // Velocidad mínima para considerar que el jugador está cayendo
    public float fallSpeedThreshold = 0.1f;

    //Ataque 
    public bool IsAtack;
    public bool IsMove;
    public float puchForce = 10f; 


    void Start()
    {
        
        
        // Inicializamos la vida del personaje
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    private void FixedUpdate()
    {
        if (!IsAtack)
        {
            transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
            transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
        }

        if (IsMove)
        {
            rb.velocity = transform.forward * puchForce;
        }
    }

    void Update()
    {
        // Movimiento del personaje
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Return) && isGrounded && !IsAtack)
        {
            animator.SetTrigger("Puch");
            IsAtack = true;
        }
        
        animator.SetFloat("Velx", x);
        animator.SetFloat("VelY", y);

        // Comprobar si el personaje está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Si está en el suelo y la velocidad vertical es baja, el jugador puede saltar de nuevo
        if (isGrounded && Mathf.Abs(rb.velocity.y) < fallSpeedThreshold)
        {
            
        }

        if (!IsAtack)
        {
            // Saltar cuando se presiona la barra espaciadora y el personaje está en el suelo
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
            {

                animator.SetTrigger("Jump");
                isJumping = true; // Marcar que el jugador ha saltado
            }
        }


        // Simulación de daño
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    // Método para que el personaje reciba daño
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
        Debug.Log("El personaje ha muerto");
        // Aquí puedes añadir lógica adicional como reiniciar el nivel, etc.
        
    }
    
    public void StopPuch()
    {
        IsAtack = false;
    }

    public void MoveAlone()
    {
        IsMove = true;
    }

    public void StopMove()
    {
        IsMove = false; 
    }
}
