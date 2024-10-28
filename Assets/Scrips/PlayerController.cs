using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool HasFlag = false; // Indica si el jugador tiene la bandera.
    public GameObject canvasWin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BaseAliada") && HasFlag) // Verifica si llegó a la base aliada con la bandera.
        {
            Debug.Log("¡Has llevado la bandera a la base aliada!");
            canvasWin.SetActive(true);
            HasFlag = false;
            Time.timeScale = 0;
             // Resetea el estado del jugador.
            // Aquí puedes activar un evento de victoria o sumar puntos.
        }
    }
    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }
}
