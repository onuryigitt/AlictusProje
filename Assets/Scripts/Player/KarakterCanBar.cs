using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KarakterCanBar : MonoBehaviour
{
    public float Health;
    float maxHealth = 100;
    public Slider HealthSlider;
    public GameObject deathMenu; // �l�m men�s� oyun nesnesi

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
            Health += 20; // Elma temas�nda can� 20 art�r
            Health = Mathf.Clamp(Health, 0, maxHealth); // Sa�l�k de�erini maksimum sa�l�kla s�n�rla
            HealthSlider.value = Health; // Sa�l�k �ubu�unu g�ncelle
            Destroy(other.gameObject);
        }
    }

    public void GetDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Debug.Log("�ld�n");
            Time.timeScale = 0f; // Oyunu duraklat
            deathMenu.SetActive(true); // �l�m men�s�n� aktif hale getir
        }
    }

    // �l�m men�s�ndeki "Yeniden Ba�lat" butonu i�in bir metot
    /* public void RestartGame()
    {
        Time.timeScale = 1f; // Oyunu tekrar ba�lat
        SceneManager.LoadScene("0"); // Oyun sahnesini yeniden y�kle (SceneAdi yerine kendi sahne ad�n�z� yaz�n)
    }*/
}
