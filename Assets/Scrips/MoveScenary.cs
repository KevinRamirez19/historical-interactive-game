using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenary : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el objeto tiene la etiqueta "Player".
        {
            Debug.Log("Colisión detectada con PaintGuerraMilDias. Cambiando de escena...");
            SceneManager.LoadScene("GuerraDeLosMilDias"); // Cambia a la escena especificada.
        }
    }
}
