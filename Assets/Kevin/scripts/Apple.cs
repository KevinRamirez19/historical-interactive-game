using UnityEngine;

public class Apple : MonoBehaviour
{
    public int healAmount = 20; // Cantidad de salud que la manzana otorgará

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto con el que colisiona es el personaje y tiene el componente de salud
        var playerHealth = other.GetComponent<Player_Move>(); // Cambiar PlayerHealth a Player_Move

        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount); // Llama a la función Heal de tu script de salud
            Destroy(gameObject); // Destruye la manzana después de curar
        }
    }
}
