using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBogotazo : MonoBehaviour
{
    public string nameScene; 
    private void  OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nameScene);
    }
}
