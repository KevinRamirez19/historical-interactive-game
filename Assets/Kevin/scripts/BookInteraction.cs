using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteraccionLibro : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("mostrarObjeto", 1);
            SceneManager.LoadScene(1);  // Asegúrate de que "Lobby" es el nombre correcto de la escena
        }
    }
}
