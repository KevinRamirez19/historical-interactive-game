using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionLibro : MonoBehaviour
{
    public GameObject libro;
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            libro.SetActive(true);
        }
    }
}
