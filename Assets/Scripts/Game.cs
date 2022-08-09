using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Snake Snake;
    public GameObject LoseScreen;
    public GameObject WinScreen;
    public Text textLevel;
    public Text scoreText;
    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }

    public void OnSnakeDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Debug.Log("Game Over");
        LoseScreen.SetActive(true);
        scoreText.text = Snake.tempCount.ToString();

    }
    public void OnSnakeReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        LevelIndex++;
        CurrentState = State.Won;
        Snake.enabled = false;
        WinScreen.SetActive(true);
        textLevel.text = ($"Level {LevelIndex.ToString()} passed. ({Snake.tempCount} pt)");

    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private const string LevelIndexKey = "LevelIndex";

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }


}
