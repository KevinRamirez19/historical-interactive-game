using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public Inventario inventario;
    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                inventario.cantidad = inventario.cantidad + 1;
            Destroy(gameObject);
            }
         }
 }
