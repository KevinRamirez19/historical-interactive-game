using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FlagEnemy : MonoBehaviour
{
    public GameObject canvasCaptura; // Referencia al Canvas.

    private bool isCarried = false; // Bandera capturada o no.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCarried) // Si es el jugador y no est� capturada.
        {
            //Debug.Log("�Has capturado la bandera enemiga!");
            isCarried = true;
            StartCoroutine(SendPostRequest());

            // Muestra el Canvas.
            if (canvasCaptura != null)
            {
                canvasCaptura.SetActive(true);
            }
            else
            {
                Debug.LogError("No se asign� el CanvasCaptura.");
            }

            // Marca que el jugador tiene la bandera.
            other.GetComponent<PlayerController>().HasFlag = true;

            Destroy(this.gameObject);
        }
    }

    [System.Serializable]
    public class GameProgress
    {
        public int gameProgressId;
        public string gameProgress;
        public string description;
        public bool isDeleted;
    }

    public void StartLoginApp()
    {
        StartCoroutine(SendPostRequest());
    }
    public IEnumerator SendPostRequest()
    {
        string jsonData = JsonUtility.ToJson(new GameProgress
        {
            gameProgressId = 0,
            gameProgress = "Capturar bandera",
            description = "El jugador ha capturado la bandera liberal.",
            isDeleted = false
        });

        Debug.Log("JSON Data: " + jsonData);

        UnityWebRequest www = new UnityWebRequest("https://nationalmuseum2.somee.com/api/GameProgress", "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonData);
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();

        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("POST exitoso: " + www.downloadHandler.text);
        }
    }

}
