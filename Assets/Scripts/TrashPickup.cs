using UnityEngine;

public class TrashPickupItem : MonoBehaviour
{
    public GameObject pickupButton;
    private PlayerTrashController currentPlayer;

    void Start()
    {
        if (pickupButton != null)
            pickupButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerTrashController player = other.GetComponentInParent<PlayerTrashController>();

        if (player != null && !player.isCarryingTrash)
        {
            currentPlayer = player;

            if (pickupButton != null)
                pickupButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerTrashController player = other.GetComponentInParent<PlayerTrashController>();

        if (player != null)
        {
            currentPlayer = null;

            if (pickupButton != null)
                pickupButton.SetActive(false);
        }
    }

    public void PickThisTrash()
    {
        if (currentPlayer == null) return;

        currentPlayer.PickTrash(gameObject);

        if (pickupButton != null)
            pickupButton.SetActive(false);
    }
}