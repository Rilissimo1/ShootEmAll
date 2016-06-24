using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

    public float Timer;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        Destroy(this.gameObject, Timer);
    }

}
