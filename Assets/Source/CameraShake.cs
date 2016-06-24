using UnityEngine;

public class CameraShake : MonoBehaviour {
    public static CameraShake Instance;
    public Transform CamTransform;
    public float ShakeDuration = 0f;
    public float ShakeAmount = 0.7f;
    public float DecreaseFactor = 1.0f;
    Vector3 originalPos;

    void Awake(){
        if (Instance == null)
            Instance = this;
        if (CamTransform == null){
            CamTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void Start(){
        originalPos = CamTransform.localPosition;
    }

    void Update(){
        if (ShakeDuration > 0){
            CamTransform.localPosition = originalPos + Random.insideUnitSphere * ShakeAmount;

            ShakeDuration -= Time.deltaTime * DecreaseFactor;
        }
        else{
            ShakeDuration = 0f;
            CamTransform.localPosition = originalPos;
        }
    }
}