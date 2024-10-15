using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Clues : MonoBehaviour
{
    public GameObject _panelPressE;
    public GameObject _panelMision;
    public TextMeshProUGUI _textPanelMision;
    public bool _inTrigger;
    public int _conversationSteps;
    public float _time = 0f;
    public string _miTexto; 

    // Start is called before the first frame update
    void Start()
    {
        _panelPressE.GetComponent<Transform>();
        _textPanelMision.text = _miTexto;
        _inTrigger = false;
        _conversationSteps = 0;
        
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
            }
        }
    }
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            _panelPressE.SetActive(true);
            _inTrigger = true;


        }
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
}
