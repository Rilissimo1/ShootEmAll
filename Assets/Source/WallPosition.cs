using UnityEngine;
using System.Collections;

public class WallPosition : MonoBehaviour {

    public Transform UpWall;
    public Transform DownWall;
    public Transform LeftWall;
    public Transform RightWall;

    void Start() {
        Positioning();
    }

    void Positioning() {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        UpWall.position = new Vector3(0, 0, stageDimensions.z);
        DownWall.position = new Vector3(0, 0, -stageDimensions.z);
        LeftWall.position = new Vector3(-stageDimensions.x, 0, 0);
        RightWall.position = new Vector3(stageDimensions.x, 0, 0);
        Debug.Log(stageDimensions);
    }
}
