using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChooseScreen : MonoBehaviour
{
    public Button levelButtonPrefab; // Prefab for level buttons
    public Transform buttonContainer; // Parent for level buttons

    [SerializeField]
    private int levelCount = 20;

    void Start()
    {
        PopulateLevelButtons();
    }

    void PopulateLevelButtons()
    {
        for (int i = 1; i <= levelCount; i++)
        {
            string levelName = "Level" + i;

            Button levelButton = Instantiate(levelButtonPrefab, buttonContainer);
            levelButton.GetComponentInChildren<Text>().text = i.ToString(); // Display level name on the button

            levelButton.onClick.AddListener(() => LoadLevel(levelName));
            
        }
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
