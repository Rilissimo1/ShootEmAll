using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public Text LevelText;
    public AudioClip ButtonEffect;

    private const string appleId = "";
    private const string androidId = "";

    private void Awake() {
        Instance = this;
        if (PlayerPrefs.GetInt("PlayedLevels") % 8 == 0) {
            MobileNativeRateUs ratePopUp = new MobileNativeRateUs("Like this game?", "Please rate to support future updates!");
            ratePopUp.SetAppleId(appleId);
            ratePopUp.SetAndroidAppUrl(androidId);
            ratePopUp.Start();
        }
    }

    void Start() {
        LevelText.text = "Level: " + SceneManager.GetActiveScene().buildIndex;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            BackToMainMenu();
        }
    }

    public void Win() {
        if (SceneManager.GetActiveScene().buildIndex >= SceneManager.sceneCountInBuildSettings - 1) {
            StartCoroutine(LoadLevel(0, 1));
            return;
        }
        PlayerPrefs.SetInt("PlayedLevels", PlayerPrefs.GetInt("PlayedLevels") + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, 2));
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("Level") -1)
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    public void Lose() {
        PlayerPrefs.SetInt("PlayedLevels", PlayerPrefs.GetInt("PlayedLevels") + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex, 1));
    }

    public void BackToMainMenu() {
        CustomExtensions.Play2DClipAtPoint(ButtonEffect, this.transform.position);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadLevel(int level, float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(level);
    }
}
