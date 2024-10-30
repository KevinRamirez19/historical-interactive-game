using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Objeto : MonoBehaviour
{
    private MissionBB missionManager;

    public string mensaje = "Has recogido el objeto"; // Mensaje personalizado para cada objeto

    private void Start()
    {
        // Encontrar el MissionBB en la escena
        missionManager = FindObjectOfType<MissionBB>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SendPostRequest());
            // Llama al método de recogida en el MissionBB
            missionManager.RecogerObjeto(gameObject);
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
            gameProgressId = 1,
            gameProgress = "Primer objeto recojido",
            description = "El jugador ha recogido exitosamente el primer objeto, ahora se dirije al segundo",
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
