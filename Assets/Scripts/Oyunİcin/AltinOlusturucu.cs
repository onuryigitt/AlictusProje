using UnityEngine;

public class AltinOlusturucu : MonoBehaviour
{
    public GameObject altinPrefab; // Alt�n objesinin prefab'ini atamak i�in
    public AltinToplama altinToplamaScript; // AltinToplama script'ine referans

    private int maksimumAltin = 400; // Maksimum olu�turulacak alt�n obje say�s�
    private float alanGenislik = 75f; // Alt�n objelerinin da��t�laca�� alan�n geni�li�i
    private float alanUzunluk = 75f; // Alt�n objelerinin da��t�laca�� alan�n uzunlu�u

    private void Start()
    {
        // altinToplamaScript'in atan�p atanmad���n� kontrol et
        if (altinToplamaScript != null)
        {
            AltinleriOlustur();
        }
        else
        {
            Debug.LogError("AltinToplama script'i atanmam��!");
        }
    }

    void AltinleriOlustur()
    {
        for (int i = 0; i < maksimumAltin; i++)
        {
            Vector3 pozisyon = new Vector3(Random.Range(-alanGenislik, alanGenislik), 2.87f, Random.Range(-alanUzunluk, alanUzunluk));
            Quaternion rotasyon = Quaternion.Euler(0f, 0f, 90f); // Rotasyonu sabitlemek i�in 90 derece

            GameObject yeniAltin = Instantiate(altinPrefab, pozisyon, rotasyon); // Alt�n objesini olu�tur
        }
    }
}
