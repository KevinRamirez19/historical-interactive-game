using UnityEngine;
using TMPro; // Asegúrate de importar el espacio de nombres de TextMeshPro

public class MessageManager : MonoBehaviour
{
    public GameObject messagePanel; // Referencia al panel completo
    public TMP_Text messageText; // Referencia al texto dentro del panel

    private void Start()
    {
        // Al inicio, oculta el panel completo
        messagePanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message; // Cambia el texto del mensaje
        messagePanel.SetActive(true); // Muestra el panel completo
        Invoke("HideMessage", 6f); // Oculta el panel después de 6 segundos
    }

    private void HideMessage()
    {
        messagePanel.SetActive(false); // Oculta el panel completo
    }
}
