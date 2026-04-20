using UnityEngine;

public class TrashItem : MonoBehaviour
{
    [Header("Eþya Ayarlarý")]
    public string itemTag = "Trash"; // Inventory'deki isimle ayný olmalý

    // Oyuncu bu çöpü aldýðýnda sahneden silinmesi için bir referans
    public void OnPickedUp()
    {
        Debug.Log(gameObject.name + " baþarýyla toplandý.");
        Destroy(gameObject); // Yerdeki objeyi yok et
    }
}