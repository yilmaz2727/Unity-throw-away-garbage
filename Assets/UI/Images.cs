using UnityEngine;
using UnityEngine.UI;

public class AlphaButton : MonoBehaviour
{
    void Start()
    {
        // 0.1f deðeri, %10'dan daha fazla opak olan yerlerin týklanabilir olmasýný saðlar.
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }
}