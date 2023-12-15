using UnityEngine;

public class DusmanOlusturucu : MonoBehaviour
{
    public GameObject dusmanPrefab; // D��man prefab'i
    private int dusmanSayisi = 150; // Olu�turulacak d��man say�s�
    private float alanGenislik = 75f; // Alan geni�li�i

    void Start()
    {
        DusmanlariOlustur();
    }

    void DusmanlariOlustur()
    {
        for (int i = 0; i < dusmanSayisi; i++)
        {
            Vector3 pozisyon = new Vector3(Random.Range(-alanGenislik, alanGenislik), 2.87f, Random.Range(-alanGenislik, alanGenislik));
            Quaternion rotasyon = Quaternion.identity;

            GameObject yeniDusman = Instantiate(dusmanPrefab, pozisyon, rotasyon);
        }
    }
}
