using UnityEngine;

public class PlayerTrashController : MonoBehaviour
{
    [Header("Carry")]
    public bool isCarryingTrash = false;
    public GameObject handTrash;
    private GameObject currentTrash;

    [Header("UI")]
    public GameObject throwButton;

    private bool isNearBin = false;

    void Start()
    {
        if (handTrash != null)
            handTrash.SetActive(false);

        if (throwButton != null)
            throwButton.SetActive(false);
    }

    void Update()
    {
        if (throwButton != null)
        {
            throwButton.SetActive(isCarryingTrash && isNearBin);
        }
    }

    public void PickTrash(GameObject trashObject)
    {
        if (isCarryingTrash) return;

        isCarryingTrash = true;
        currentTrash = trashObject;

        if (currentTrash != null)
            currentTrash.SetActive(false);

        if (handTrash != null)
            handTrash.SetActive(true);

        Debug.Log("Çöp alýndý");
    }

    public void ThrowTrash()
    {
        if (!isCarryingTrash) return;
        if (!isNearBin) return;

        isCarryingTrash = false;

        if (handTrash != null)
            handTrash.SetActive(false);

        if (currentTrash != null)
            Destroy(currentTrash);

        currentTrash = null;

        if (throwButton != null)
            throwButton.SetActive(false);

        Debug.Log("Çöp kutusuna atýldý");
    }

    public void SetNearBin(bool value)
    {
        isNearBin = value;
    }
}