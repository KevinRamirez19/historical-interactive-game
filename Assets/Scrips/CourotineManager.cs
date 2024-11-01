using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CoroutineManager : MonoBehaviour
{
    public static CoroutineManager Instance;

    private void Awake()
    {
        // Configura el objeto como singleton para facilitar el acceso
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartArtifactCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
