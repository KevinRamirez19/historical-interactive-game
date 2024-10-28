using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textPuntos;
    public GameObject gameOverPanel;
    public Canvas canvasPuntaje; // Canvas de puntaje y vida

    public void MostrarGameOver()
    {
        Time.timeScale = 0; 
        gameOverPanel.SetActive(true);

        Puntaje puntajeScript = FindObjectOfType<Puntaje>();
        textPuntos.text = "Puntaje: " + puntajeScript.Puntos.ToString("0");
        
        canvasPuntaje.gameObject.SetActive(false);
    }
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void IrAlMenuPrincipal()
    {
        SceneManager.LoadScene("Menu Principal"); 
    }
}
