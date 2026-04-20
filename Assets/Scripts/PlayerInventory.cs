using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Envanter Durumu")]
    public bool isCarryingSomething = false;
    public string currentItemTag = "";

    [Header("Eldeki Görsel Referanslarý")]
    // Buraya elinde görünecek olan objeleri (handTrash vb.) Inspector'dan sürükleyeceðiz
    public GameObject handTrashVisual;

    // Gelecekte baþka eþyalar eklemek istersen buraya ekleyebilirsin
    // public GameObject handFireExtinguisherVisual; 

    void Start()
    {
        // Baþlangýçta eldeki her þeyi gizle
        ResetVisuals();
    }

    // Elimizdeki görselleri sýfýrlayan yardýmcý fonksiyon
    public void ResetVisuals()
    {
        if (handTrashVisual != null) handTrashVisual.SetActive(false);
        isCarryingSomething = false;
        currentItemTag = "";
    }

    // Eþyayý "Envantere Al" komutu
    public void EquipItem(string itemTag)
    {
        ResetVisuals(); // Önce temizle

        isCarryingSomething = true;
        currentItemTag = itemTag;

        // Tag'e göre hangi görselin açýlacaðýna karar ver
        if (itemTag == "Trash")
        {
            if (handTrashVisual != null) handTrashVisual.SetActive(true);
        }

        Debug.Log("Envantere eklendi: " + itemTag);
    }
}