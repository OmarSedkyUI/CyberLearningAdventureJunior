using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectLevelButton : MonoBehaviour
{
    public GameData gameData;
    public GameLevelData levelData;
    public Text levelText;
    public Image progressBarFilling;
    public TextMeshProUGUI levelName;

    private string gameSceneName = "GameScene";

    private bool _levelLocked;

    void Start()
    {
        _levelLocked = false;
        var Button = GetComponent<Button>();
        Button.onClick.AddListener(OnButtonClick);
        UpdateButtonInformation();

        if (_levelLocked)
        {
            Button.interactable = false;
        }
        else
        {
            Button.interactable = true;
        }
    }

    void Update()
    {
        ;
    }

    public void UpdateButtonInformation()
    {
        var currentIndex = -1;
        var totalLevels = 0;

        foreach (var data in levelData.data)
        {
            if (data.levelName == gameObject.name)
            {
                currentIndex = DataSaver.ReadLevelCurrentIndexValues(gameObject.name);
                totalLevels = data.levelData.Count;

                if (levelData.data[0].levelName == gameObject.name && currentIndex < 0)
                {
                    DataSaver.SaveLevelData(levelData.data[0].levelName, 0);
                    currentIndex = DataSaver.ReadLevelCurrentIndexValues(gameObject.name);
                    totalLevels = data.levelData.Count;
                }
            }
        }

        if (currentIndex == -1)
        {
            _levelLocked = true;
        }

        levelText.text = _levelLocked ? string.Empty : (currentIndex.ToString() + "/" + totalLevels.ToString());
        progressBarFilling.fillAmount = (currentIndex > 0 && totalLevels > 0) ? ((float)currentIndex / (float)totalLevels) : 0f;
    }

    public void OnButtonClick()
    {
        gameData.selectedLevelName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);
    }
}
