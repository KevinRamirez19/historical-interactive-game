using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mensaje2 : MonoBehaviour
{
    public string message = "El Frente Nacional buscaba poner fin a \"La Violencia\" entre partidos y restaurar el orden institucional. Su meta era un gobierno compartido con representación igualitaria de liberales y conservadores para reducir la competencia violenta y evitar el monopolio de poder.\r\nDurante 16 años, la presidencia alternó entre liberales y conservadores, y los cargos públicos se dividieron equitativamente entre ambos partidos. Se excluyeron otras fuerzas políticas de la administración estatal.\r\n";  // Mensaje a mostrar al colisionar
    public GameObject messageUI;  // Objeto de UI para mostrar el mensaje

    private void Start()
    {
        if (messageUI != null)
        {
            messageUI.SetActive(false);  // Asegúrate de que el mensaje esté oculto al inicio
        }
        else
        {
            Debug.LogWarning("messageUI no está asignado en el objeto " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowMessage();
        }
    }

    private void ShowMessage()
    {
        if (messageUI != null)
        {
            messageUI.SetActive(true);  // Muestra el mensaje
            messageUI.GetComponent<Text>().text = message;  // Cambia el texto del mensaje
            StartCoroutine(HideMessageAfterDelay(10f));  // Oculta el mensaje después de 10 segundos
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (messageUI != null)
        {
            messageUI.SetActive(false);  // Oculta el mensaje después del retraso
        }
    }
}
