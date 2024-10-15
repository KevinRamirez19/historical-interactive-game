using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_options : MonoBehaviour 
{
    public void IniciarJuego(String NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
    public void  Salir()
    
    {
            Application.Quit();
            Debug.Log("Adios :v");
    }

}
