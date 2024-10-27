using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject ObjectKey;
    public GameObject ColliderDoor;
  
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderDoor.gameObject.SetActive(true);
            Destroy(ObjectKey);
        }
    }

}