using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Art5 : MonoBehaviour
{
    public int gameProgressId = 1; // ID único para cada artefacto
    public string gameProgressMessage = "Quinto objeto recogido"; // Mensaje específico para este artefacto
    public string descriptionMessage = "El jugador ha recogido exitosamente el quinto objeto, ahora se dirige al ultimo."; // Descripción específica
    public string apiUrl = "https://nationalmuseum2.somee.com/api/GameProgress"; // URL del endpoint API

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Usa el CoroutineManager para iniciar el Coroutine
            CoroutineManager.Instance.StartArtifactCoroutine(SendPostRequest());
            Destroy(gameObject); // Opcional: destruye el artefacto después de recogerlo
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

    public IEnumerator SendPostRequest()
    {
        string jsonData = JsonUtility.ToJson(new GameProgress
        {
            gameProgressId = gameProgressId,
            gameProgress = gameProgressMessage,
            description = descriptionMessage,
            isDeleted = false
        });

        Debug.Log("JSON Data: " + jsonData);

        UnityWebRequest www = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonData);
        www.uploadHandler = new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = new DownloadHandlerBuffer();

        www.SetRequestHeader("Content-Type", "application/json");

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error en el POST: " + www.error);
        }
        else
        {
            Debug.Log("POST exitoso: " + www.downloadHandler.text);
        }
    }
}
