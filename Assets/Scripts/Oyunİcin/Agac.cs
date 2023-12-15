using UnityEngine;

public class Agac: MonoBehaviour
{
    public GameObject[] kaktusPrefabs; // Kakt�s prefab'lar�
    public int klonlamaSayisi = 50; // Klonlanacak kakt�s say�s�
    public float haritaGenislik = 100f; // Harita geni�li�i
    public float buyutmeFaktoru = 15f; // Klonlanacak kakt�s�n boyutu i�in b�y�tme fakt�r�

    void Start()
    {
        KaktusleriOlustur();
    }

    void KaktusleriOlustur()
    {
        for (int i = 0; i < klonlamaSayisi; i++)
        {
            int rastgeleIndex = Random.Range(0, kaktusPrefabs.Length); // Rastgele bir kakt�s prefab'� se�
            Vector3 pozisyon = new Vector3(Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f), 2.5f, Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f));

            // Kakt�s� klonlay�n ve boyutunu ayarlay�n
            GameObject klonlananKaktus = Instantiate(kaktusPrefabs[rastgeleIndex], pozisyon, Quaternion.identity);
            klonlananKaktus.transform.localScale *= buyutmeFaktoru;


        }
    }
}
