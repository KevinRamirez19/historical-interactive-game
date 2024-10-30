using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Clues : MonoBehaviour
{
    public GameObject _panelPressE;
    public GameObject _panelMision;
    public TextMeshProUGUI _textPanelMision;
    public bool _inTrigger;
    public int _conversationSteps;
    public float _time = 0f;
    public string _miTexto; 
    public Positions? _positions;


    // Start is called before the first frame update
    void Start()
    {
        _panelPressE.GetComponent<Transform>();
        _textPanelMision.text = _miTexto;
        _inTrigger = false;
        _conversationSteps = 0;
        _positions = GameObject.Find("People_Obstacles")?.GetComponent<Positions>()?? null;        
    }

    // Update is called once per frame
    void Update()
    {
        _textPanelMision.text = _miTexto;
        if (_panelPressE.activeSelf)
        {
            if (Input.GetKeyUp(KeyCode.E) && _inTrigger)
            {
                _panelPressE.SetActive(false);
                _panelMision.SetActive(true);
                _time += Time.deltaTime;
            }
        }

        if (_panelMision.activeSelf && _time >=1f)
        {

            if (Input.GetKeyUp(KeyCode.E) && _inTrigger)
            {
                _panelMision.SetActive(false);
                _panelPressE.SetActive(true);
                _time = 0f;
                if (_positions)
                {
                _positions._animator.SetBool("Block", true);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider _other)
    {
        
        if (_other.CompareTag("Player"))
        {
            StartCoroutine(SendPostRequest());
            Debug.Log("Hola");
            _panelPressE.SetActive(true);
            _inTrigger = true;

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
    private void OnTriggerStay()
    {
    if (_panelMision.activeSelf )
    {
         _time += Time.deltaTime;
    }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            _panelPressE.SetActive(false);
            _panelMision.SetActive(false);
            _inTrigger = false;
            _time = 0f;
        }

    }
    public IEnumerator SendPostRequest()
{
    string jsonData = JsonUtility.ToJson(new GameProgress
    {
        gameProgressId = 1,
        gameProgress = "Primera interaccion existosa",
        description = "El jugador ha comenzado con las pistas",
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

