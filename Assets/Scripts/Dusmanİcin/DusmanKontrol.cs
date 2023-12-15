using UnityEngine;
using UnityEngine.UI;

public class DusmanKontrol : MonoBehaviour
{
    public Text mevcutDusmanText; // Mevcut düþman sayýsýný gösteren metin nesnesi
    public Text enYuksekDusmanText; // En yüksek düþman sayýsýný gösteren metin nesnesi
    private string enYuksekDusmanSayisiPrefsKey = "EnYuksekDusmanSayisi";

    private void Start()
    {
        // Oyun baþladýðýnda en yüksek düþman sayýsýný yükleyerek göster
        if (PlayerPrefs.HasKey(enYuksekDusmanSayisiPrefsKey))
        {
            int enYuksekDusmanSayisi = PlayerPrefs.GetInt(enYuksekDusmanSayisiPrefsKey);
            enYuksekDusmanText.text = " " + enYuksekDusmanSayisi.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dusman"))
        {
            if (mevcutDusmanText != null)
            {
                int mevcutDusmanSayisi = int.Parse(mevcutDusmanText.text);
                mevcutDusmanSayisi++; // Düþman sayýsýný bir arttýr
                mevcutDusmanText.text = mevcutDusmanSayisi.ToString();

                // Yüksek skoru kontrol et ve güncelle
                if (mevcutDusmanSayisi > PlayerPrefs.GetInt(enYuksekDusmanSayisiPrefsKey, 0))
                {
                    PlayerPrefs.SetInt(enYuksekDusmanSayisiPrefsKey, mevcutDusmanSayisi);
                    PlayerPrefs.Save(); // PlayerPrefs verilerinin diske kaydedilmesi
                    enYuksekDusmanText.text = " " + mevcutDusmanSayisi.ToString();
                }
            }

            Destroy(other.gameObject); // Çarpýlan düþmaný yok et
        }
    }
}
