using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleScenes : MonoBehaviour
{
    public bool _firstScene = false, _secondScene = false;

    public GameObject _block1, _block2, _book;
    void Start()
    {
        _block1 = GameObject.Find("Bloqueo1");
        _block2 = GameObject.Find("Bloqueo2");
        _book = GameObject.FindWithTag("LibroBogotazo");
        _book.SetActive(false);

    }

    void Update()
    {
       if (_firstScene)
       {
        _block1.SetActive(false);
        _book.SetActive(true);
       }
       if (_secondScene)
       {
        _block2.SetActive(false);
       }
    }
    
    
}