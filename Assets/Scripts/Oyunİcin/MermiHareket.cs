using UnityEngine;

public class MermiHareket : MonoBehaviour
{
    public GameObject mermiPrefab; // Mermi prefab'ý
    public Transform firlatmaNoktasi; // Fýrlatma yapýlacak nokta
    public float firlatmaGucu = 10f; // Fýrlatma gücü
    public float atisArasiSure = 0.7f; // Mermi atýþý arasýndaki süre
    public float mermiOmru = 1f; // Mermi ömrü

    private bool firlatmaDurumu = false; // Fýrlatma durumu

    private float sonrakiAtisZamani = 0f; // Bir sonraki atýþ zamaný

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

        // Mermiyi belirli bir süre sonra yok etmek için Invoke fonksiyonunu kullanýn
        Destroy(yeniMermi, mermiOmru);
    }
}
