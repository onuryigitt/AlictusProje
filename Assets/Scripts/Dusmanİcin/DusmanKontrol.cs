using UnityEngine;
using UnityEngine.UI;

public class DusmanKontrol : MonoBehaviour
{
    public Text mevcutDusmanText; // Mevcut d��man say�s�n� g�steren metin nesnesi
    public Text enYuksekDusmanText; // En y�ksek d��man say�s�n� g�steren metin nesnesi
    private string enYuksekDusmanSayisiPrefsKey = "EnYuksekDusmanSayisi";

    private void Start()
    {
        // Oyun ba�lad���nda en y�ksek d��man say�s�n� y�kleyerek g�ster
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
                mevcutDusmanSayisi++; // D��man say�s�n� bir artt�r
                mevcutDusmanText.text = mevcutDusmanSayisi.ToString();

                // Y�ksek skoru kontrol et ve g�ncelle
                if (mevcutDusmanSayisi > PlayerPrefs.GetInt(enYuksekDusmanSayisiPrefsKey, 0))
                {
                    PlayerPrefs.SetInt(enYuksekDusmanSayisiPrefsKey, mevcutDusmanSayisi);
                    PlayerPrefs.Save(); // PlayerPrefs verilerinin diske kaydedilmesi
                    enYuksekDusmanText.text = " " + mevcutDusmanSayisi.ToString();
                }
            }

            Destroy(other.gameObject); // �arp�lan d��man� yok et
        }
    }
}
