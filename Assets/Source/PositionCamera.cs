using UnityEngine;

public class PositionCamera : MonoBehaviour
{

    public float FWidth = 9.0f;  // Desired width 
    private void Awake() {
        float fT = FWidth / Screen.width * Screen.height;
        fT = fT / (2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
        Vector3 v3T = Camera.main.transform.position;
        v3T.y = fT;
        transform.position = v3T;
    }
}