using UnityEngine;
using UnityEngine.UI;

public class AltinToplama : MonoBehaviour
{
    public Text altinSayisiText;
    public GameObject altinPrefab;


    private int altinSayisi = 0;
    private string altinSayisiPrefsKey = "AltinSayisi";

    private void Start()
    {
        // Oyun ba�lad���nda kaydedilmi� alt�n say�s�n� y�kleyerek g�ster
        if (PlayerPrefs.HasKey(altinSayisiPrefsKey))
        {
            altinSayisi = PlayerPrefs.GetInt(altinSayisiPrefsKey);
            UpdateAltinSayisiUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Altin"))
        {
            altinSayisi++;
            Destroy(other.gameObject);
            UpdateAltinSayisiUI();
            OlusturYeniAltin();

            // Alt�n say�s�n� PlayerPrefs �zerine kaydet
            PlayerPrefs.SetInt(altinSayisiPrefsKey, altinSayisi);
            PlayerPrefs.Save(); // PlayerPrefs verilerinin diske kaydedilmesi
        }
    }

    void UpdateAltinSayisiUI()
    {
        altinSayisiText.text = "  " + altinSayisi.ToString();
    }

    void OlusturYeniAltin()
    {
        Vector3 pozisyon = new Vector3(Random.Range(-10f, 10f), 2.87f, Random.Range(-10f, 10f));
        Instantiate(altinPrefab, pozisyon, Quaternion.identity);
    }
}
