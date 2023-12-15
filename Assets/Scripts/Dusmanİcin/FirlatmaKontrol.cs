using UnityEngine;

public class FirlatmaKontrol : MonoBehaviour
{
    public GameObject mermiPrefab; // Mermi prefab'�
    public Transform firlatmaNoktasi; // F�rlatma yap�lacak nokta

    // Bu fonksiyon, mermiyi f�rlatmak i�in �a�r�labilir.
    public void MermiFirlat()
    {
        GameObject yeniMermi = Instantiate(mermiPrefab, firlatmaNoktasi.position, Quaternion.identity);
        Rigidbody mermiRigidbody = yeniMermi.GetComponent<Rigidbody>();

        if (mermiRigidbody != null)
        {
            // Karakterin y�n�ne do�ru bir h�zda mermiyi f�rlatmak i�in a�a��daki sat�r� kullanabilirsiniz.
            mermiRigidbody.velocity = transform.forward * 10f; // 10f yerine farkl� bir h�z de�eri de kullanabilirsiniz.
        }
    }
}
