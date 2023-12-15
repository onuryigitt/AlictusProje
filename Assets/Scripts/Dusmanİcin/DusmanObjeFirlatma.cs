using UnityEngine;

public class DusmanObjeFirlatma : MonoBehaviour
{
    public GameObject objePrefab; // F�rlat�lacak objenin prefab'ini atamak i�in
    public float dusmanHizi = 10f; // D��man�n ilerleme h�z�
    public float firlatmaAraligi = 5f; // Objeyi f�rlatma aral���
    public float firlatmaGucu = 10f; // F�rlat�lacak objenin ba�lang�� g�c�

    private float zamanSayaci = 0f;

    void Update()
    {
        zamanSayaci += Time.deltaTime;

        // Belirli bir aral�kta hareket eden d��man
        if (zamanSayaci >= firlatmaAraligi)
        {
            zamanSayaci = 0f;

            // Objeyi f�rlatma i�lemi
            FirlatObjeyi();
        }
    }

    void FirlatObjeyi()
    {
        // F�rlatma pozisyonu ve rotasyonu
        Vector3 firlatmaPozisyonu = transform.position + transform.forward * 2f; // D��man�n �n�nde 2 birim ilerisine yerle�tir
        Quaternion firlatmaRotasyonu = transform.rotation;

        // Objeyi f�rlat
        GameObject yeniObje = Instantiate(objePrefab, firlatmaPozisyonu, firlatmaRotasyonu);
        Rigidbody objeRigidbody = yeniObje.GetComponent<Rigidbody>();

        // F�rlat�lan objeye bir kuvvet uygula
        if (objeRigidbody != null)
        {
            objeRigidbody.AddForce(transform.forward * firlatmaGucu, ForceMode.Impulse); // F�rlatma g�c�n� uygula

            // Objenin belirli bir s�re sonra yok olmas� i�in zamanlay�c� ekle
            Destroy(yeniObje, 1.75f); // 1 saniye sonra objeyi yok et
        }
    }
}
