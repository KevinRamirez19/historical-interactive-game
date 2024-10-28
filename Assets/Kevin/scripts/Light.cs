using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Light : MonoBehaviour
{
    internal float shadowStrength;
    internal float shadowBias;
    internal float intensity;

    void Start()
    {
        
        
    }

        void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }
}
