using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Snake Snake;
    public GameObject LoseScreen;
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
        CurrentState= State.Won;
        Snake.enabled = false;
        Debug.Log("You won");

    }
    
}
