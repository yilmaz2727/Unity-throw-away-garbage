using UnityEngine;

public class TrashProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // ARTIK BURADA Destroy KULLANMIYORUZ.
        // Çöp yere veya duvara çarpýnca dünyada fiziksel bir obje olarak kalmaya devam eder.
        Debug.Log("Çöp hedefi ýskaladý, yerde kalýyor.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sadece basket olursa silinsin
        if (other.CompareTag("Bin"))
        {
            Debug.Log("<color=green>BASKET! Çöp kutuya girdi ve imha ediliyor.</color>");

            // Sepete girdiði için artýk bu objeye ihtiyacýmýz yok
            Destroy(gameObject);
        }
    }
}