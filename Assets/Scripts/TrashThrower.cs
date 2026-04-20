using UnityEngine;
using UnityEngine.UI;

public class TrashThrower : MonoBehaviour
{
    private PlayerInventory inventory;
    private TrajectoryPredictor predictor;

    [Header("Atýþ Ayarlarý")]
    public GameObject trashProjectilePrefab; // Assets'teki Rigidbody'li çöp
    public Transform throwPoint;             // sachuso'nun elindeki nokta
    public Vector3 throwAngle = new Vector3(0, 1.5f, 1f); // Yay açýsý (Y yukarý, Z ileri)
    public float maxThrowForce = 25f;

    [Header("Güç Barý UI")]
    public Slider powerSlider;
    public float powerSpeed = 2f;

    private float currentPower;
    private bool isAiming = false;

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
        predictor = GetComponent<TrajectoryPredictor>();

        if (powerSlider != null) powerSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        // Sadece elimizde "Trash" varken atýþ yapabiliriz
        if (!inventory.isCarryingSomething || inventory.currentItemTag != "Trash") return;

        // Sol týk basýlý tutulduðunda niþan almayý baþlat
        if (Input.GetMouseButtonDown(0))
        {
            isAiming = true;
            if (powerSlider != null) powerSlider.gameObject.SetActive(true);
        }

        if (isAiming)
        {
            // Gücü 0-100 arasý git-gel yaptýr (Ping-Pong)
            currentPower = Mathf.PingPong(Time.time * powerSpeed * 50f, 100f);
            if (powerSlider != null) powerSlider.value = currentPower;

            // Tahmini hýzý hesapla ve yayý çizdir
            Vector3 velocity = CalculateVelocity();
            predictor.RenderTrajectory(throwPoint.position, velocity);
        }

        // Tuþ býrakýldýðýnda fýrlat!
        if (Input.GetMouseButtonUp(0) && isAiming)
        {
            Launch();
        }
    }

    Vector3 CalculateVelocity()
    {
        // Karakterin baktýðý yöne göre fýrlatma kuvvetini hesaplar
        return transform.TransformDirection(throwAngle).normalized * (currentPower / 100f) * maxThrowForce;
    }

    void Launch()
    {
        isAiming = false;
        if (powerSlider != null) powerSlider.gameObject.SetActive(false);
        predictor.ClearTrajectory();

        // 1. Eldeki görsel çöpü gizle ve envanteri sýfýrla
        inventory.ResetVisuals();

        // 2. Fiziksel çöpü Instantiate et ve fýrlat
        GameObject projectile = Instantiate(trashProjectilePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false; // Fiziði aktif et
            rb.AddForce(CalculateVelocity(), ForceMode.Impulse);
        }
    }
}