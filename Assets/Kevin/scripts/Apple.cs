using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esta línea para poder trabajar con UI

public class Apple : MonoBehaviour
{
    public int healAmount = 20; // Cantidad de salud que la manzana otorgará
    public Slider healthSlider; // Referencia al Slider de salud

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerHealth = other.GetComponent<Player_Move>();

            if (playerHealth != null)
            {
                // Desactiva temporalmente la interacción del slider
                healthSlider.interactable = false;

                playerHealth.Heal(healAmount); // Llama a la función Heal
                Destroy(gameObject); // Destruye la manzana después de curar

                // Reactivar el slider después de un breve retraso
                StartCoroutine(ReactivateSlider());
            }
        }
    }

    private IEnumerator ReactivateSlider()
    {
        yield return new WaitForSeconds(0.5f); 
        healthSlider.interactable = true; 
    }
}
