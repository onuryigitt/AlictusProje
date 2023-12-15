using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KarakterCanBar : MonoBehaviour
{
    public float Health;
    float maxHealth = 100;
    public Slider HealthSlider;
    public GameObject deathMenu; // Ölüm menüsü oyun nesnesi

    private void OnTriggerEnter(Collider other)
    {
        if (Health >= 100)
        {
            Health = 100;
        }
        HealthSlider.value = Health;

        if (other.CompareTag("Dusman"))
        {
            GetDamage(25);
        }
        else if (other.CompareTag("Elma"))
        {
            Health += 20; // Elma temasýnda caný 20 artýr
            Health = Mathf.Clamp(Health, 0, maxHealth); // Saðlýk deðerini maksimum saðlýkla sýnýrla
            HealthSlider.value = Health; // Saðlýk çubuðunu güncelle
            Destroy(other.gameObject);
        }
    }

    public void GetDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Debug.Log("Öldün");
            Time.timeScale = 0f; // Oyunu duraklat
            deathMenu.SetActive(true); // Ölüm menüsünü aktif hale getir
        }
    }

    // Ölüm menüsündeki "Yeniden Baþlat" butonu için bir metot
    /* public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar baþlat
        SceneManager.LoadScene("0"); // Oyun sahnesini yeniden yükle (SceneAdi yerine kendi sahne adýnýzý yazýn)
    }*/
}
