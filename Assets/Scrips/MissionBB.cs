using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MissionBB : MonoBehaviour
{
    public int totalArtifacts = 6; // Total de artefactos a recolectar
    private int collectedArtifacts = 0; // Artefactos recolectados
    public TMP_Text messageText; // Campo para mostrar mensajes en la UI
    public GameObject finalZone; // Referencia a la zona final que se debe ocultar inicialmente
    public string hiddenLayerName = "FinalZoneHidden"; // Nombre de la capa para ocultar el plano en el mapa
    private int defaultLayer; // Almacena la capa original del plano

    void Start()
    {
        // Guarda la capa original del FinalZone
        if (finalZone != null)
        {
            defaultLayer = finalZone.layer;
            finalZone.layer = LayerMask.NameToLayer(hiddenLayerName); // Cambia la capa para que no se vea en el mapa
            finalZone.SetActive(false); // Oculta la zona final
        }
    }

    // Método llamado cuando se recoja un artefacto
    public void ArtifactCollected()
    {
        collectedArtifacts++;

        if (collectedArtifacts < totalArtifacts)
        {
            ShowMessage($"Has recogido un artefacto. Te faltan {totalArtifacts - collectedArtifacts} artefactos.", 5f);
        }
        else
        {
            CompleteMission();
        }
    }

    // Método para finalizar la misión
    public void CompleteMission()
    {
        ShowMessage("¡Misión completada! Todos los artefactos han sido recolectados.", 5f);
        Debug.Log("¡Misión completada! Todos los artefactos han sido recolectados.");

        // Haz visible la zona final y cambia la capa para que aparezca en el mapa
        if (finalZone != null)
        {
            finalZone.SetActive(true);
            finalZone.layer = defaultLayer; // Cambia la capa de vuelta a la original
        }
    }

    // Método para mostrar mensajes y hacer que desaparezcan después de un tiempo
    private void ShowMessage(string message, float duration)
    {
        if (messageText != null)
        {
            messageText.text = message;
            StartCoroutine(HideMessageAfterTime(duration));
        }
        else
        {
            Debug.Log(message);
        }
    }

    // Corrutina para ocultar el mensaje después de un tiempo
    private IEnumerator HideMessageAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        messageText.text = "";
    }
}
