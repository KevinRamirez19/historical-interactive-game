using UnityEngine;
using TMPro; // Asegúrate de importar el espacio de nombres de TextMeshPro

public class MessageManager : MonoBehaviour
{
    public TMP_Text messageText; // Cambiado a TMP_Text

    private void Start()
    {
        // Al inicio, oculta el texto
        messageText.gameObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message; // Cambia el texto
        messageText.gameObject.SetActive(true); // Muestra el texto
        Invoke("HideMessage", 6f); // Oculta el texto después de 6 segundos
    }

    private void HideMessage()
    {
        messageText.gameObject.SetActive(false); // Oculta el texto
    }
}