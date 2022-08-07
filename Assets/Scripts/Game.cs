using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Snake Snake;
    public GameObject LoseScreen;
    public GameObject WinScreen;
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
    }
    public void OnSnakeReachedFinish()
    {
        if (CurrentState != State.Playing) return;
        LevelIndex++;
        CurrentState= State.Won;
        Snake.enabled = false;
        WinScreen.SetActive(true);

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
