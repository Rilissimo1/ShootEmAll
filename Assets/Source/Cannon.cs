using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
[AddComponentMenu("Custom/Cannon")]
public class Cannon : MonoBehaviour {

    [Header("Semicircle Settings")]
    public bool Semicircle;
    public float Start;
    public float End;
    [Space(10)]
    public float RotationSpeed;
    public float BallSpeed;
    public int BallBouncing;
    public Text BouncingText;
    private GameObject ballPrefab;
    private Transform shootLocator;
    private int counter = 1;
    private bool direction;
    public AudioClip ShotEffect;

    void Awake() {
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        ballPrefab = Resources.Load("Ball") as GameObject;
        shootLocator = GetComponentInChildren<BallSpawner>().transform;
        BouncingText.text = BallBouncing.ToString();
    }

	private void Update () {
	    if (Semicircle) {
	        if (!direction) {
	            float angle = Quaternion.Angle(transform.localRotation, Quaternion.Euler(0, Start, 0));
	            this.transform.Rotate(Vector3.up*RotationSpeed);
	            if (angle <= 10)
	                direction = true;
	        }
	        else {
	            float angle = Quaternion.Angle(transform.localRotation, Quaternion.Euler(0, End, 0));
	            this.transform.Rotate(Vector3.up*(-RotationSpeed));
	            if (angle <= 10)
	                direction = false;
	        }
	    }
	    else {
	        this.transform.Rotate(Vector3.up*RotationSpeed);
	    }
	    if (Input.GetMouseButtonDown(0)) {
            if (counter == 0)
                return;
            CustomExtensions.Play2DClipAtPoint(ShotEffect, this.transform.position);
	        CameraShake.Instance.ShakeDuration = 0.2f;
            counter--;
            Ball ball = (Instantiate(ballPrefab, shootLocator.transform.position,
                shootLocator.transform.rotation) as GameObject).GetComponent<Ball>();
            ball.Shoot(BallSpeed, BallBouncing, BouncingText);
        }
	}

    private void OnMouseDown() {

    }
}

/*
[CustomEditor(typeof(Cannon))]
public class CannonEditor : Editor {

    private Cannon _evCtrl = null;

    void OnEnable() {
        _evCtrl = (Cannon)target;
    }

    public override void OnInspectorGUI() {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Semicircle Movement", GUILayout.Width(170));
        _evCtrl.Semicircle = EditorGUILayout.Toggle(_evCtrl.Semicircle);
        GUILayout.EndHorizontal();
        if (_evCtrl.Semicircle) {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Start Angle", GUILayout.Width(170));
            _evCtrl.start = EditorGUILayout.FloatField(_evCtrl.start);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("End Angle", GUILayout.Width(170));
            _evCtrl.end = EditorGUILayout.FloatField(_evCtrl.end);
            GUILayout.EndHorizontal();
        }
        GUILayout.BeginHorizontal();
        GUILayout.Label("Speed", GUILayout.Width(170));
        _evCtrl.RotationSpeed = EditorGUILayout.FloatField(_evCtrl.RotationSpeed);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Ball Speed", GUILayout.Width(170));
        _evCtrl.BallSpeed = EditorGUILayout.FloatField(_evCtrl.BallSpeed);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("Ball Max Bounce", GUILayout.Width(170));
        _evCtrl.BallBouncing = EditorGUILayout.IntField(_evCtrl.BallBouncing);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        _evCtrl.BouncingText = (Text)EditorGUILayout.ObjectField("Bounce Text", _evCtrl.BouncingText, typeof(Text), false);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        _evCtrl.ShotEffect = (AudioClip)EditorGUILayout.ObjectField("Bounce Text", _evCtrl.ShotEffect, typeof(AudioClip), false);
        GUILayout.EndHorizontal();
    }
}
*/