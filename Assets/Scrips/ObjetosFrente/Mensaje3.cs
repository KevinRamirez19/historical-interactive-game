using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mensaje3 : MonoBehaviour
{
    public string message = "El Frente Nacional trajo paz política y redujo la violencia bipartidista. Facilitó reformas sociales y económicas que avanzaron en salud, educación e infraestructura, dando al país un periodo de calma institucional.\r\nEl carácter excluyente del Frente Nacional impidió la participación de nuevos movimientos políticos, generando tensiones. Esta falta de representatividad impulsó la creación de grupos guerrilleros y movimientos sociales que se oponían al pacto.\r\n";  // Mensaje a mostrar al colisionar
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
