using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_options : MonoBehaviour 
{
    public void IniciarJuego(string NombreNivel)
    {
        PlayerPrefs.SetInt("mostrarObjeto", 0);
        SceneManager.LoadScene(NombreNivel);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Adios :v");
    }

    public void MostrarCreditos()
    {
        SceneManager.LoadScene("Creditos"); // Asegúrate de que la escena de créditos se llame "Creditos" en Unity
    }
}
