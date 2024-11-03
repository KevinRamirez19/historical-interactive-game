using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainTools;

public class HandleScenes : MonoBehaviour
{
    public bool _firstScene = false, _secondScene = false;

    public GameObject _block1, _block2, _book, _paint;
    void Start()
    {
        _block1 = GameObject.Find("Bloqueo1");
        _block2 = GameObject.Find("Bloqueo2");
        _book = GameObject.FindWithTag("LibroBogotazo");
        _paint = GameObject.FindWithTag("PaintBogotazo"); 
        _book.SetActive(false);
    }

    void Update()
    {
        int mostrarObjeto = PlayerPrefs.GetInt("mostrarObjeto", 0); 

        if (mostrarObjeto == 1)
        {
            _paint.GetComponent<Animator>().enabled = false; 

            _block1.SetActive(false); 
            _book.SetActive(true);
        }
        else
        {
            _block1.SetActive(true);
        }

        if (mostrarObjeto == 2)
        {
            _block2.SetActive(false); 
        }
        else
        {
            _block2.SetActive(true);
        }


        /*
       if (_firstScene)
       {
        _block1.SetActive(false);
        _book.SetActive(true);
       }
       if (_secondScene)
       {
        _block2.SetActive(false);
       }
       
    }*/


    }
}