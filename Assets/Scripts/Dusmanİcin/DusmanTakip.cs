using UnityEngine;

public class DusmanTakip : MonoBehaviour
{
    public Transform hedef; // Takip edilecek hedef (�rne�in ana karakterin Transform bile�eni)
    public float hareketHizi = 8f; // D��man�n hareket h�z�

    private void Update()
    {
        // E�er hedef belirtilmemi�se veya hedef yoksa i�lemi durdur
        if (hedef == null)
        {
            return;
        }

        // D��man�n pozisyonunu hedefe do�ru g�ncelle
        Vector3 hedefYon = (hedef.position - transform.position).normalized;
        Vector3 hareketMiktari = hedefYon * hareketHizi * Time.deltaTime;
        transform.Translate(hareketMiktari, Space.World);

        // D��man�n y�z�n� hedefe do�ru �evir
        Quaternion yeniRotasyon = Quaternion.LookRotation(hedefYon);
        transform.rotation = Quaternion.Slerp(transform.rotation, yeniRotasyon, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kilic")) // E�er bu obje "Kilic" tag'ine sahipse
        {
            Debug.Log("D��man, Kilic ile �arp��t�!"); // Konsolda mesaj g�ster
            // Buraya �arp��man�n neden oldu�u i�lemleri ekleyebilirsiniz
        }
    }
}
