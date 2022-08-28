using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Snake Snake;
    public Text LevelText;
    public GameObject WinScreen;
    public GameObject GameScreen;
    public GameObject LoseScreen;

    private const string LevelIndexKey = "LevelIndex";

    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CurrentState { get; private set; }

    public void Update()
    {
        LevelText.text = "Уровень: " + (LevelIndex + 1).ToString();
    }

    public void OnSnakeDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Snake.enabled = false;
        GameScreen.SetActive(false);
        LoseScreen.SetActive(true);
    }

    public void OnSnakeRichedFinish()
    {
        if (CurrentState != State.Playing) return;

        GameScreen.SetActive(false);
        WinScreen.SetActive(true);
        CurrentState = State.Won;
        Snake.enabled = false;
        LevelIndex++;
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        WinScreen.SetActive(false);

        if ((SceneManager.GetActiveScene().buildIndex) == 3)
            SceneManager.LoadScene("Level 1");
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}