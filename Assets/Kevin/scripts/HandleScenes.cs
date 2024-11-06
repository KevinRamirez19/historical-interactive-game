using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TerrainTools;

public class HandleScenes : MonoBehaviour
{
    public bool _firstScene = false, _secondScene = false;

    public GameObject _block1, _block2, _book, _paint1, _paint2, _paint3, _paint4;
    void Start()
    {
        _block1 = GameObject.Find("Bloqueo1");
        _block2 = GameObject.Find("Bloqueo2");
        _book = GameObject.FindWithTag("LibroBogotazo");
        _paint1 = GameObject.FindWithTag("PaintBogotazo");
        _paint2 = GameObject.FindWithTag("PaintBatalladeBoyacá");
        _paint3 = GameObject.FindWithTag("PaintFrenteNacional");
        _paint4 = GameObject.FindWithTag("PaintGuerraMilDias");
        //_book.SetActive(false);
        _paint2.GetComponent<Animator>().enabled = false;
        _paint4.GetComponent<Animator>().enabled = false;
        _paint1.GetComponent<Animator>().enabled = false;
        _paint3.GetComponent<Animator>().enabled = false;
    }

    void Update()
    {
        int mostrarObjeto = PlayerPrefs.GetInt("mostrarObjeto", 0);

        if (mostrarObjeto == 0)
        {
            _paint2.GetComponent<Animator>().enabled = true;
        }


        if (mostrarObjeto == 1)
        {
            _paint4.GetComponent<Animator>().enabled = true;
        }


        if (mostrarObjeto == 2)
        {
            _paint1.GetComponent<Animator>().enabled = true; 
        }
        

        if (mostrarObjeto == 3)
        {
            _paint3.GetComponent<Animator>().enabled = true;
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