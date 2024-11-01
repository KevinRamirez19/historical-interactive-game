using UnityEngine;
using UnityEngine.UI;

public class Mensaje1 : MonoBehaviour
{
    public string message = "En los años 50, Colombia sufría violencia extrema entre liberales y conservadores...";
    public GameObject messageUI;
    public float displayDuration = 10f;  // Duración en segundos para mostrar el mensaje

    private float timer = 0f;
    private bool isMessageActive = false;
    private bool hasMessageBeenShown = false; // Para mostrar el mensaje solo una vez

    private void Start()
    {
        if (messageUI != null)
        {
            messageUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("messageUI no está asignado en el objeto " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasMessageBeenShown)
        {
            ShowMessage();
        }
    }

    private void Update()
    {
        if (isMessageActive)
        {
            timer += Time.deltaTime;

            if (timer >= displayDuration)
            {
                HideMessage();
            }
        }
    }

    private void ShowMessage()
    {
        if (messageUI != null)
        {
            messageUI.SetActive(true);
            Text uiText = messageUI.GetComponent<Text>();

            if (uiText != null)
            {
                uiText.text = message;
            }

            timer = 0f;
            isMessageActive = true;
            hasMessageBeenShown = true;
        }
    }

    private void HideMessage()
    {
        if (messageUI != null)
        {
            messageUI.SetActive(false);
            isMessageActive = false;
            timer = 0f; // Reinicia el temporizador para la próxima vez
        }
    }
}
