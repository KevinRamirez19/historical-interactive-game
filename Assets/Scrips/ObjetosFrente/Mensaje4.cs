using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Mensaje4 : MonoBehaviour
{
    public string message = "La exclusión política del Frente Nacional afectó la democracia y marginó a muchos sectores, generando descontento social y conflictos que facilitaron el surgimiento de actores armados en los años siguientes.\r\nEn 1974, el Frente Nacional finalizó con la elección de un presidente sin alternancia. Aunque logró pacificar temporalmente al país, dejó un legado de exclusión política que impactó la democracia.\r\n";  // Mensaje a mostrar al colisionar
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
