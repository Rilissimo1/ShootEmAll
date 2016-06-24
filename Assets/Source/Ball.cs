using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("Custom/Ball")]
public class Ball : MonoBehaviour {

    private int bounce;
    private Rigidbody Rb;
    private float speed;
    public GameObject DestroyParticles;
    public GameObject InpactParticles;
    private Text bounceText;
    private TrailRenderer trail;
    public AudioClip BounceSound;
    public AudioClip VicotrySound;
    public AudioClip TeleportSound;

    private void Awake() {
        trail = GetComponentInChildren<TrailRenderer>();
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        Rb = GetComponent<Rigidbody>();
    }

    void Update() {
        bounceText.text = bounce.ToString();
    }

    public void Shoot(float ballSpeed, int ballBouncing, Text text) {
        speed = ballSpeed;
        bounce = ballBouncing;
        bounceText = text;
        Rb.AddForce(transform.forward * ballSpeed, ForceMode.Impulse);
    }
    
    private void OnCollisionEnter(Collision col) {
        CameraShake.Instance.ShakeDuration = 0.2f;
        TeleportEnter enter = col.transform.root.gameObject.GetComponent<TeleportEnter>();
        WinHole hole = col.transform.root.gameObject.GetComponent<WinHole>();   
        GameObject particles = Instantiate(InpactParticles);
        particles.transform.position = this.transform.position;

        if (hole != null) {
            CustomExtensions.Play2DClipAtPoint(VicotrySound, this.transform.position);
            Debug.Log("Win!");
            hole.Destroy();
            Destroy(this.gameObject);
            GameManager.Instance.Win();
            return;
        }

        if (enter != null) {
            CustomExtensions.Play2DClipAtPoint(TeleportSound, this.transform.position);
            trail.time = 0;
            this.transform.position = enter.Exit.transform.position;
            this.transform.rotation = enter.Exit.transform.rotation;
            Rb.velocity = enter.Exit.transform.forward * speed;
            StartCoroutine(EnableTrail());
            return;
        }

        bounce--;
        if (bounce <= 0) {
            CustomExtensions.Play2DClipAtPoint(BounceSound, this.transform.position);
            bounceText.text = "X";
            GameObject deathParticles = Instantiate(DestroyParticles);
            deathParticles.transform.position = this.transform.position;
            GameManager.Instance.Lose();
            Destroy(this.gameObject);
            return;
        }
        CustomExtensions.Play2DClipAtPoint(BounceSound, this.transform.position);
    }

    void OnTriggerEnter(Collider col) {
        BounceBonus bonus = col.transform.root.gameObject.GetComponent<BounceBonus>();
        if (bonus != null) {
            bounce += bonus.BonusAmount;
            Destroy(bonus.gameObject);
        }
    }

    IEnumerator EnableTrail() {
        yield return new WaitForSeconds(0.1f);
        trail.time = 0.5f;
    }
}
