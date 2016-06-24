using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/WinHole")]
public class WinHole : MonoBehaviour {

    public GameObject ParticlesPrefab;

    private void Awake() {
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

    public void Destroy() {
        GameObject obj = Instantiate(ParticlesPrefab);
        obj.transform.position = this.transform.position;
        GameManager.Instance.Win();
        Destroy(this.gameObject);
    }
}
