using UnityEngine;

public class MermiHareket : MonoBehaviour
{
    public GameObject mermiPrefab; // Mermi prefab'�
    public Transform firlatmaNoktasi; // F�rlatma yap�lacak nokta
    public float firlatmaGucu = 10f; // F�rlatma g�c�
    public float atisArasiSure = 0.7f; // Mermi at��� aras�ndaki s�re
    public float mermiOmru = 1f; // Mermi �mr�

    private bool firlatmaDurumu = false; // F�rlatma durumu

    private float sonrakiAtisZamani = 0f; // Bir sonraki at�� zaman�

    void Update()
    {
        if (firlatmaDurumu || Input.GetButton("Fire1"))
        {
            if (Time.time >= sonrakiAtisZamani)
            {
                MermiFirlat();
                sonrakiAtisZamani = Time.time + atisArasiSure;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            firlatmaDurumu = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            firlatmaDurumu = false;
        }
    }

    void MermiFirlat()
    {
        GameObject yeniMermi = Instantiate(mermiPrefab, firlatmaNoktasi.position, firlatmaNoktasi.rotation);
        Rigidbody mermiRigidbody = yeniMermi.GetComponent<Rigidbody>();

        if (mermiRigidbody != null)
        {
            mermiRigidbody.velocity = firlatmaNoktasi.forward * firlatmaGucu;
        }

        // Mermiyi belirli bir s�re sonra yok etmek i�in Invoke fonksiyonunu kullan�n
        Destroy(yeniMermi, mermiOmru);
    }
}
