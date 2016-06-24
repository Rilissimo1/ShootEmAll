using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/Magnet")]
public class Magnet : MonoBehaviour {

    public float Range = 1f;
    public float Force;
    public Transform Arrows;

    void Start() {
        MagnetForce force = GetComponentInChildren<MagnetForce>();
        force.gameObject.transform.localScale = new Vector3(Range, Range, Range);
        force.Force = Force;
        if (Force > 0) {
            Arrows.localScale = new Vector3(1,1,-1);
        }
    }

}
