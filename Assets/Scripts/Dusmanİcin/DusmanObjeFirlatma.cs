using UnityEngine;

public class DusmanObjeFirlatma : MonoBehaviour
{
    public GameObject objePrefab; // Fýrlatýlacak objenin prefab'ini atamak için
    public float dusmanHizi = 10f; // Düþmanýn ilerleme hýzý
    public float firlatmaAraligi = 5f; // Objeyi fýrlatma aralýðý
    public float firlatmaGucu = 10f; // Fýrlatýlacak objenin baþlangýç gücü

    private float zamanSayaci = 0f;

    void Update()
    {
        zamanSayaci += Time.deltaTime;

        // Belirli bir aralýkta hareket eden düþman
        if (zamanSayaci >= firlatmaAraligi)
        {
            zamanSayaci = 0f;

            // Objeyi fýrlatma iþlemi
            FirlatObjeyi();
        }
    }

    void FirlatObjeyi()
    {
        // Fýrlatma pozisyonu ve rotasyonu
        Vector3 firlatmaPozisyonu = transform.position + transform.forward * 2f; // Düþmanýn önünde 2 birim ilerisine yerleþtir
        Quaternion firlatmaRotasyonu = transform.rotation;

        // Objeyi fýrlat
        GameObject yeniObje = Instantiate(objePrefab, firlatmaPozisyonu, firlatmaRotasyonu);
        Rigidbody objeRigidbody = yeniObje.GetComponent<Rigidbody>();

        // Fýrlatýlan objeye bir kuvvet uygula
        if (objeRigidbody != null)
        {
            objeRigidbody.AddForce(transform.forward * firlatmaGucu, ForceMode.Impulse); // Fýrlatma gücünü uygula

            // Objenin belirli bir süre sonra yok olmasý için zamanlayýcý ekle
            Destroy(yeniObje, 1.75f); // 1 saniye sonra objeyi yok et
        }
    }
}
