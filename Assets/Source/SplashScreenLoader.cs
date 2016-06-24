using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenLoader : MonoBehaviour {

    public Image SplashImage;
    public float Timer = 5;

    AsyncOperation async;
    float m_fAlpha = 0.01f;

	void Start () {
        async = SceneManager.LoadSceneAsync("MainMenu");
        async.allowSceneActivation = false;
	}

	void Update () {
        SplashImage.color = new Color(255, 255, 255, m_fAlpha);
        if (m_fAlpha < 1 && Timer > 0)
            m_fAlpha += 1 * Time.deltaTime;
        if(m_fAlpha >= 1) {
            Timer -= 1 * Time.deltaTime;
        }
        if (Timer <= 0)
            m_fAlpha -= 1 * Time.deltaTime;
        if (m_fAlpha <= 0)
            async.allowSceneActivation = true;
	}
}
