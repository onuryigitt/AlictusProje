using UnityEngine;

public class ElmaOlusturucu : MonoBehaviour
{
    public GameObject elmaPrefab;
    public int elmaSayisi = 80; 
    public float haritaGenislik = 100f;

    void Start()
    {
        ElmalariOlustur();
    }

    void ElmalariOlustur()
    {
        for (int i = 0; i < elmaSayisi; i++)
        {
            Vector3 pozisyon = new Vector3(Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f), 3.5f, Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f));
            GameObject yeniElma = Instantiate(elmaPrefab, pozisyon, Quaternion.identity);
            yeniElma.tag = "Elma";
        }
    }

    public void ElmaSilindi()
    {
        Vector3 pozisyon = new Vector3(Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f), 3.5f, Random.Range(-haritaGenislik / 2f, haritaGenislik / 2f));
        Instantiate(elmaPrefab, pozisyon, Quaternion.identity).tag = "Elma";
    }
}
