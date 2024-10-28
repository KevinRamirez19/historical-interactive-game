using UnityEngine;

public class DeliveryZone : MonoBehaviour
{
    public MissionBB missionBB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes agregar lógica para finalizar la misión
            if (missionBB != null)
            {
                missionBB.CompleteMission();
                // Puedes agregar más lógica, como cargar una nueva escena o mostrar un mensaje
            }
        }
    }
}