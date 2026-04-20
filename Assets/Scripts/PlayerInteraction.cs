using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInventory inventory;

    [Header("UI Ayarlarý")]
    public GameObject pickupButton; // Ekranda çýkan "Al" butonu

    private TrashItem detectedTrash; // Yakýnýmýzdaki çöpün referansý

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        if (pickupButton != null) pickupButton.SetActive(false);
    }

    // Çöpün menziline girince
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            TrashItem trash = other.GetComponent<TrashItem>();
            if (trash != null && !inventory.isCarryingSomething)
            {
                detectedTrash = trash;
                if (pickupButton != null) pickupButton.SetActive(true);
            }
        }
    }

    // Çöpün menzilinden çýkýnca
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            detectedTrash = null;
            if (pickupButton != null) pickupButton.SetActive(false);
        }
    }

    // "Al" butonuna týklandýðýnda çalýþacak fonksiyon
    public void OnPickupClicked()
    {
        if (detectedTrash != null && !inventory.isCarryingSomething)
        {
            // 1. Envantere iþle
            inventory.EquipItem(detectedTrash.itemTag);

            // 2. Yerdeki objeyi sil
            detectedTrash.OnPickedUp();

            // 3. UI'ý kapat
            detectedTrash = null;
            if (pickupButton != null) pickupButton.SetActive(false);
        }
    }
}