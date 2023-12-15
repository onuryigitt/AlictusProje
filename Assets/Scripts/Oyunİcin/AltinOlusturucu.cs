using UnityEngine;

public class AltinOlusturucu : MonoBehaviour
{
    public GameObject altinPrefab; // Altýn objesinin prefab'ini atamak için
    public AltinToplama altinToplamaScript; // AltinToplama script'ine referans

    private int maksimumAltin = 400; // Maksimum oluþturulacak altýn obje sayýsý
    private float alanGenislik = 75f; // Altýn objelerinin daðýtýlacaðý alanýn geniþliði
    private float alanUzunluk = 75f; // Altýn objelerinin daðýtýlacaðý alanýn uzunluðu

    private void Start()
    {
        // altinToplamaScript'in atanýp atanmadýðýný kontrol et
        if (altinToplamaScript != null)
        {
            AltinleriOlustur();
        }
        else
        {
            Debug.LogError("AltinToplama script'i atanmamýþ!");
        }
    }

    void AltinleriOlustur()
    {
        for (int i = 0; i < maksimumAltin; i++)
        {
            Vector3 pozisyon = new Vector3(Random.Range(-alanGenislik, alanGenislik), 2.87f, Random.Range(-alanUzunluk, alanUzunluk));
            Quaternion rotasyon = Quaternion.Euler(0f, 0f, 90f); // Rotasyonu sabitlemek için 90 derece

            GameObject yeniAltin = Instantiate(altinPrefab, pozisyon, rotasyon); // Altýn objesini oluþtur
        }
    }
}
