using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public bool HasFlag = false; // Indica si el jugador tiene la bandera.
    public GameObject canvasWin;
    public int num;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BaseAliada") && HasFlag) // Verifica si llegó a la base aliada con la bandera.
        {
            Debug.Log("¡Has llevado la bandera a la base aliada!");
            StartCoroutine(SendPostRequest());
            canvasWin.SetActive(true);
            HasFlag = false;
            Time.timeScale = 0;
            // Resetea el estado del jugador.
            // Aquí puedes activar un evento de victoria o sumar puntos.
            Destroy(other.gameObject);
        }
    }
    public void IrAlMenuPrincipal()
    {
        PlayerPrefs.SetInt("mostrarObjeto", num);
        Time.timeScale = 1;
        SceneManager.LoadScene("Lobby");
    }

    public void IrALosCreditos()
    {
        PlayerPrefs.SetInt("mostrarObjeto", num);
        Time.timeScale = 1;
        SceneManager.LoadScene("Creditos");
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
            gameProgress = "Llevar Bandera",
            description = "El jugador ha llevado la bandera a la base.",
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
