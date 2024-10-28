using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    public HandleScenes _handleScenes;
    void Start()
    {
        _handleScenes = GameObject.FindWithTag("Player").GetComponent<HandleScenes>();
    }

    
    void Update()
    {
        _handleScenes._firstScene= true;
    }
}