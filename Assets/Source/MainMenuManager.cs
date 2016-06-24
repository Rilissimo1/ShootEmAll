using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public float AnimationSpeed = 0.1f;
    private int currentLevel = 1;
    private int totalLevels = 1;
    public Text LevelText;

    public RectTransform Levels;
    public RectTransform Menu;
    public RectTransform NewGame;
    private bool showLevels;
    public AudioClip ButtonSound;

    public RectTransform Content;
    public RectTransform LevelPanel;
    public GameObject ButtonPrefab;

    void Awake() {
        if (PlayerPrefs.HasKey("Level")) {
            totalLevels = PlayerPrefs.GetInt("Level");
            NewGame.gameObject.SetActive(false);
            Menu.gameObject.SetActive(true);
            Debug.Log(totalLevels);
        }
        RefreshLevels();
    }

    public void Continue() {
        LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public void LoadScene(int index) {
        CustomExtensions.Play2DClipAtPoint(ButtonSound, this.transform.position);
        SceneManager.LoadScene(index);
    }

    void RefreshLevels() {
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings -1; i++) {
            int d = i;
            Button button = Instantiate(ButtonPrefab).GetComponent<Button>();
            button.transform.SetParent(LevelPanel);
            button.onClick.AddListener(() => LoadScene(d));
            button.GetComponentInChildren<Text>().text = i.ToString();
            button.transform.localScale = new Vector3(1,1,1);
            if (i-1 > totalLevels)
                button.GetComponent<Button>().interactable = false;
        }
    }

    private void Update() {
        if(Content.localPosition.y < 300)
            Content.localPosition = new Vector3(0, 300, 0);
        LevelText.text = "Level " + currentLevel;
        if (showLevels) {
            Menu.localPosition = Vector3.Lerp(Menu.localPosition, new Vector3(-1000, Menu.localPosition.y, Menu.localPosition.z), AnimationSpeed);
            Levels.localPosition = Vector3.Lerp(Levels.localPosition, new Vector3(0, Levels.localPosition.y, Levels.localPosition.z),
                AnimationSpeed);
        }
        else {            
            Menu.localPosition = Vector3.Lerp(Menu.localPosition, new Vector3(0, Menu.localPosition.y, Menu.localPosition.z), AnimationSpeed);
            Levels.localPosition = Vector3.Lerp(Levels.localPosition, new Vector3(1000, Levels.localPosition.y, Levels.localPosition.z),
                AnimationSpeed);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(showLevels)
                ShowLevels();
            else 
                Application.Quit(); 
        }
    }

    public void ShowLevels() {
        CustomExtensions.Play2DClipAtPoint(ButtonSound, this.transform.position);
        showLevels = !showLevels;
    }

    public void IncreaseLevel() {
        CustomExtensions.Play2DClipAtPoint(ButtonSound, this.transform.position);
        if (currentLevel >= totalLevels)
            return;
        currentLevel++;
    }

    public void DecreaseLevel() {
        CustomExtensions.Play2DClipAtPoint(ButtonSound, this.transform.position);
        if (currentLevel <= 1)
            return;
        currentLevel--;
    }

    public void Accept() {
        LoadScene(currentLevel);
    }
}
