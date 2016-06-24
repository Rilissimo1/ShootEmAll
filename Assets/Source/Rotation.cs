using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/Rotation")]
public class Rotation : MonoBehaviour {

    public Vector3 RotationVector;
    public float Speed;

    void Update() {
        this.transform.Rotate(RotationVector * Speed);
    }
}
