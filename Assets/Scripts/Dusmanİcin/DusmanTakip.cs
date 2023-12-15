using UnityEngine;

public class DusmanTakip : MonoBehaviour
{
    public Transform hedef; // Takip edilecek hedef (örneðin ana karakterin Transform bileþeni)
    public float hareketHizi = 8f; // Düþmanýn hareket hýzý

    private void Update()
    {
        // Eðer hedef belirtilmemiþse veya hedef yoksa iþlemi durdur
        if (hedef == null)
        {
            return;
        }

        // Düþmanýn pozisyonunu hedefe doðru güncelle
        Vector3 hedefYon = (hedef.position - transform.position).normalized;
        Vector3 hareketMiktari = hedefYon * hareketHizi * Time.deltaTime;
        transform.Translate(hareketMiktari, Space.World);

        // Düþmanýn yüzünü hedefe doðru çevir
        Quaternion yeniRotasyon = Quaternion.LookRotation(hedefYon);
        transform.rotation = Quaternion.Slerp(transform.rotation, yeniRotasyon, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kilic")) // Eðer bu obje "Kilic" tag'ine sahipse
        {
            Debug.Log("Düþman, Kilic ile çarpýþtý!"); // Konsolda mesaj göster
            // Buraya çarpýþmanýn neden olduðu iþlemleri ekleyebilirsiniz
        }
    }
}
