using UnityEngine;
using System.Collections;

public class MagnetForce : MonoBehaviour {

    public float Force;
    public AudioSource ElectroSource;

    private void Awake() {
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

    void OnTriggerStay(Collider col) {
        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        if (rb != null) {
            ElectroSource.enabled = true;
            Vector3 dir = this.transform.position - rb.transform.position;
            rb.AddForce(dir.normalized * Force);
        }
    }

    void OnTriggerExit(Collider col) {
        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        if (rb != null) {
            StartCoroutine(DisableSound());
        }
    }

    IEnumerator DisableSound() {
        yield return new WaitForSeconds(0.2f);
        ElectroSource.enabled = false;
    }
}
