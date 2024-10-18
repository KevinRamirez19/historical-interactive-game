using UnityEngine;

public class MissionBB : MonoBehaviour
{
    public int totalArtifacts = 6; // Total de artefactos a recolectar
    private int collectedArtifacts = 0; // Artefactos recolectados

    public void ArtifactCollected()
    {
        collectedArtifacts++;
        if (collectedArtifacts >= totalArtifacts)
        {
            CompleteMission();
        }
    }

    private void CompleteMission()
    {
        // Aquí puedes agregar la lógica para finalizar la misión, como mostrar un mensaje o cargar una nueva escena
        Debug.Log("¡Misión completada! Todos los artefactos han sido recolectados.");
        // Puedes añadir código aquí para cargar la pantalla de fin de juego o de victoria
    }
}