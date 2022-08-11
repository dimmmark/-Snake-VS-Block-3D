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
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
        audioSource.Pause();

    }
    public void OnSnakeReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        LevelIndex++;
        CurrentState = State.Won;
        Snake.enabled = false;
        WinScreen.SetActive(true);
        textLevel.text = ($"Level {LevelIndex.ToString()} passed. ({Snake.tempCount} pt)");
        audioSource.Pause();

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
