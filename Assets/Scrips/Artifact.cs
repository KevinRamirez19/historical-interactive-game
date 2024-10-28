using UnityEngine;

public class Artifact : MonoBehaviour
{
    public MissionBB missionBB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Al recoger el artefacto, notificar al MissionManager
            missionBB.ArtifactCollected();
            Destroy(gameObject); // Elimina el artefacto del juego
        }
    }
}