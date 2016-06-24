using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/Teleport Exit")]
public class TeleportExit : MonoBehaviour {

    private void Awake() {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0, this.transform.localPosition.z);
    }
}
