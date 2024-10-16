using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima
    private int currentHealth; // Salud actual
    public MissionManager missionManager; // Referencia al MissionManager

    private void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Resta salud
        if (currentHealth <= 0)
        {
            Die(); // Llama a la función de muerte si la salud es cero o menos
        }
    }

    private void Die()
    {
        // Aquí puedes agregar lógica adicional al morir (animaciones, sonidos, etc.)
        Debug.Log("El jugador ha muerto.");
        RestartMission(); // Reinicia la misión
    }

    private void RestartMission()
    {
        if (missionManager != null)
        {
            missionManager.Restart(); // Llama al método de reinicio en MissionManager
        }
    }
}
