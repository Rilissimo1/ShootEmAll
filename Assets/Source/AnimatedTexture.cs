using UnityEngine;
using System.Collections;

class AnimatedTexture : MonoBehaviour {
    private Renderer hRend;
    public float xDirection;
    public float yDirection;
    public float Speed;

    void Awake() {
        hRend = this.GetComponent<Renderer>();
    }

    void Update() {
        xDirection += Speed * Time.deltaTime;
        //yDirection += Speed * Time.deltaTime;
        hRend.material.mainTextureOffset = new Vector2(xDirection, yDirection);
    }
}