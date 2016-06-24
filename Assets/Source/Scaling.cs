using System;
using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/Scaling")]
internal class Scaling : MonoBehaviour {

    [Range(0.01f,10)]
    public float Speed;
    public Scale[] ScalePoints;
    private int index;

    void Awake() {
        this.gameObject.isStatic = false;
    }

    private void Update() {
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, ScalePoints[index].Destination, Speed / 10);
        if (Mathf.Abs(this.transform.localScale.magnitude - ScalePoints[index].Destination.magnitude) <= 0.1f) {
            if (index >= ScalePoints.Length - 1)
                index = 0;
            else
                index++;
        }
    }
}

[Serializable]
internal class Scale {
    public Vector3 Destination = Vector3.one;
}
