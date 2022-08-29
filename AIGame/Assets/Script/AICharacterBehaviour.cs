using UnityEngine;
using System.Collections;

public class AICharacterBehaviour : MonoBehaviour
{
    public GameObject target; // target yang dikejar
    public float movingSpeed = 2f; // kecepatan berpindah
    public float turnSpeed = 0.05f; // kecepatan berbelok

    // Update is called once per frame
    void Update()
    {
        Vector3 gapPosition = target.transform.position - this.transform.position; // Gap antara posisi AI dengan target
        gapPosition = new Vector3(gapPosition.x, 0, gapPosition.z);
        // nilai gap y dibuat 0 agar AI mengabaikan posisi atas dan bawah (Y) dari target dan hanya mengikuti arah ke kanan dan ke kiri (X dan Z)

        Quaternion lookRotation = Quaternion.LookRotation(gapPosition);
        // Rotasi untuk look atau melihat target

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, lookRotation, turnSpeed);
        // Membuat rotasi berubah secara smooth menggunakan fungsi lerp dari rotasi awal ke rotasi tujuan lookRotation

        this.transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
        // Bergerak maju
    }
}
