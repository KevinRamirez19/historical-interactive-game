using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EndPointScenary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SendPostRequest());
    }

    // Update is called once per frame

    [System.Serializable]
    public class Scenary
    {
        public int scenaryId;
        public string scenaryName;
        public string description;
        public int order;
        public int achievementsobtained;
        public bool isDeleted;
    }

    public void StartLoginApp()
    {
        StartCoroutine(SendPostRequest());
    }

    public IEnumerator SendPostRequest()
    {
        string jsonData = JsonUtility.ToJson(new Scenary
        {
            scenaryId = 0,
            scenaryName = "Guerra de los mil dias",
            description = "La Guerra de los Mil Días fue un conflicto civil de Colombia disputado entre el 17 de octubre de 1899 y el 21 de noviembre de 1902, por inconformidades ante políticas y resultados anteriores de la política de la Regeneración apoyada por el Partido Nacional",
            order = 1,
            achievementsobtained = 0,
            isDeleted = false
        });

        Debug.Log("JSON Data: " + jsonData);

        UnityWebRequest www = new UnityWebRequest("https://nationalmuseum2.somee.com/api/Scenary", "POST");
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
