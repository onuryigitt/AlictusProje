using UnityEngine;

public class FirlatmaKontrol : MonoBehaviour
{
    public GameObject mermiPrefab; // Mermi prefab'ý
    public Transform firlatmaNoktasi; // Fýrlatma yapýlacak nokta

    // Bu fonksiyon, mermiyi fýrlatmak için çaðrýlabilir.
    public void MermiFirlat()
    {
        GameObject yeniMermi = Instantiate(mermiPrefab, firlatmaNoktasi.position, Quaternion.identity);
        Rigidbody mermiRigidbody = yeniMermi.GetComponent<Rigidbody>();

        if (mermiRigidbody != null)
        {
            // Karakterin yönüne doðru bir hýzda mermiyi fýrlatmak için aþaðýdaki satýrý kullanabilirsiniz.
            mermiRigidbody.velocity = transform.forward * 10f; // 10f yerine farklý bir hýz deðeri de kullanabilirsiniz.
        }
    }
}
