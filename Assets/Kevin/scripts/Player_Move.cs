using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class Player_Move : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public Animator animator;

    private float x, y;

    // Variables para la vida del personaje
    public int maxHealth = 100;
    private int currentHealth;
    public int healAmount = 20; // Cantidad de salud que se recuperará al tocar la manzana

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

    // Ataque del personaje 
    public bool isAtack;
    public bool moveAlone;
    public float impulseAtack = 10f;

    private GameObject enemigoActual;  // Guardar el enemigo con el que colisiona

    public float detectionRange = 2f;
    public float damageDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo")) // Verifica que es el enemigo
        {
            enemigoActual = other.gameObject; // Guardar referencia del enemigo
        }
        else if (other.CompareTag("Apple")) // Verifica si toca la manzana
        {
            Heal(healAmount); // Llama al método para curar
            Destroy(other.gameObject); // Destruye la manzana
        }
    }

    public void Heal(int healAmount)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            enemigoActual = null; // El jugador ya no está en contacto con el enemigo
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        StartCoroutine(SendPostRequest());
    }

    private void FixedUpdate()
    {
        if (!isAtack)
        {
            rb.MovePosition(rb.position + transform.forward * y * runSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0, x * rotationSpeed * Time.deltaTime, 0));
        }


        if (moveAlone)
        {
            rb.velocity = transform.forward * impulseAtack; 
        }
    }

    void Update()
    {
        // Movimiento del personaje
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        /*if (Input.GetKeyDown(KeyCode.Return) && !isJumping && !isAtack && enemigoActual != null)
        {
            animator.SetTrigger("Puch"); 
           // isAtack = true;
            DetectarEnemigos();
        }*/
        if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetTrigger("Puch");
            DetectarEnemigos();
        }

        animator.SetFloat("Velx", x);
        animator.SetFloat("VelY", y);

        // Comprobar si el personaje está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Si está en el suelo y la velocidad vertical es baja, el jugador puede saltar de nuevo
        if (isGrounded && Mathf.Abs(rb.velocity.y) < fallSpeedThreshold)
        {
            isJumping = false; // Reiniciar el estado de salto cuando toca el suelo
        }

        if (!isAtack)
        {
            // Saltar cuando se presiona la barra espaciadora y el personaje está en el suelo
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

    void DetectarEnemigos()
    {
        // Buscar todos los enemigos en la escena con el tag "Enemigo"
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);

            // Si el enemigo está dentro del rango, aplicar daño
            if (distancia <= detectionRange)
            {
                Debug.Log("Golpe detectado. Aplicando daño en " + damageDelay + " segundos.");
                StartCoroutine(AplicarDanioConRetraso(enemigo));

            }
        }
    }

    IEnumerator AplicarDanioConRetraso(GameObject enemigo)
    {
        yield return new WaitForSeconds(damageDelay);  // Esperar el tiempo definido

        // Verificar si el enemigo aún existe antes de aplicar el daño
        if (enemigo != null)
        {
            enemigo.GetComponent<HealthBar>().TakeDamage(10);
            Debug.Log("Daño aplicado al enemigo: " + enemigo.name);
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
        // Busca el objeto que contiene el script con el método MostrarGameOver.
        GameOver gameOverManager = FindAnyObjectByType<GameOver>();

        if (gameOverManager != null)
        {
            gameOverManager.MostrarGameOver(); // Llama al método MostrarGameOver.
        }
        else
        {
            Debug.LogError("No se encontró el GameOverManager en la escena.");
        }
    }


    public void StopPuch()
    {
        isAtack = false; 
    }

    public void MoveAlone()
    {
        moveAlone = true; 
    }

    public void StopMove()
    {
        moveAlone = false; 
    }

//END Point 

[System.Serializable]
    public class GameState
    {
        public int gameStateId;
        public string gameState;
        public bool isDeleted;
    }

    public void StartLoginApp()
    {
        StartCoroutine(SendPostRequest());
    }

    public IEnumerator SendPostRequest()
    {
        string jsonData = JsonUtility.ToJson(new GameState
        {
            gameStateId = 0,
            gameState = "Partida en juego",
            isDeleted = false
        });

        Debug.Log("JSON Data: " + jsonData);

        UnityWebRequest www = new UnityWebRequest("https://nationalmuseum2.somee.com/api/GameState", "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonData);
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();

        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("POST exitoso: " + www.downloadHandler.text);
        }
    }
}
