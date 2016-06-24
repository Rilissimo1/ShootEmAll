using System;
using UnityEngine;
using System.Collections;

[AddComponentMenu("Custom/Movement")]
internal class Movement : MonoBehaviour {

    [Range(0.01f,10)]
    public float Speed = 1;
    public bool StartHere;
    public WayPoint[] WayPoints;
    private int index = 0;

    private void Awake() {
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        this.gameObject.isStatic = false;
    }

    void Start() {
        if (StartHere) {
            if (WayPoints != null && WayPoints[0] != null)
                WayPoints[0].Destination = this.transform.position;
        }
    }

    private void Update() {
        this.transform.position = Vector3.Lerp(this.transform.position, WayPoints[index].Destination, Speed / 10);
        if (Vector3.Distance(this.transform.position, WayPoints[index].Destination) <= 0.1f) {
            if (index >= WayPoints.Length - 1)
                index = 0;
            else
                index++;
        }
    }
}

[Serializable]
internal class WayPoint {
    public Vector3 Destination;
}