using UnityEngine;

public class Agac: MonoBehaviour
{
    public GameObject[] kaktusPrefabs; // Kaktüs prefab'larý
    public int klonlamaSayisi = 50; // Klonlanacak kaktüs sayýsý
    public float haritaGenislik = 100f; // Harita geniþliði
    public float buyutmeFaktoru = 15f; // Klonlanacak kaktüsün boyutu için büyütme faktörü

    void Start()
    {
        KaktusleriOlustur();
    }

    void KaktusleriOlustur()
    {
        for (int i = 0; i < klonlamaSayisi; i++)
        {
            int rastgeleIndex = Random.Range(0, kaktusPrefabs.Length); // Rastgele bir kaktüs prefab'ý seç
            Vector3 pozisyon = new Vector3(Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f), 2.5f, Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f));

            // Kaktüsü klonlayýn ve boyutunu ayarlayýn
            GameObject klonlananKaktus = Instantiate(kaktusPrefabs[rastgeleIndex], pozisyon, Quaternion.identity);
            klonlananKaktus.transform.localScale *= buyutmeFaktoru;


        }
    }
}
