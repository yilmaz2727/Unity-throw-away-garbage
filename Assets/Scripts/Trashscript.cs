using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerTrashController player = other.GetComponentInParent<PlayerTrashController>();

        if (player != null)
        {
            player.SetNearBin(true);
            Debug.Log("Çöp kutusuna yaklaþtý");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerTrashController player = other.GetComponentInParent<PlayerTrashController>();

        if (player != null)
        {
            player.SetNearBin(false);
            Debug.Log("Çöp kutusundan uzaklaþtý");
        }
    }
}