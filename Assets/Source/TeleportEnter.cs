using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/Teleport Enter")]
public class TeleportEnter : MonoBehaviour {

    public GameObject Exit;

    private void Awake() {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0, this.transform.localPosition.z);
        if (Exit == null) {
            Exit = GameObject.FindObjectOfType<TeleportExit>().gameObject;
        }
    }

}
