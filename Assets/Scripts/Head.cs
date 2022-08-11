using UnityEngine;
using UnityEngine.Events;

public class Head : MonoBehaviour
{
    public event UnityAction CubeCollided;
    public event UnityAction<int> BonusCollected;
    public Snake Snake;
    public Game Game;
    AudioSource audioSourceNyam;



    private void Start()
    {
        audioSourceNyam = GetComponent<AudioSource>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Cube cube))
        {


            if (Snake._tail.Count == 0)
            {
                // Debug.Log("Game Over");
                Snake.enabled = false;
                Game.OnSnakeDied();
            }
            else
            {
                CubeCollided?.Invoke();
                cube.Fill();
            }



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bonus bonus))
        {
            audioSourceNyam.Play();
            BonusCollected?.Invoke(bonus.Collect());

        }
    }

    public void ReachFinish()
    {
        Game.OnSnakeReachedFinish();
    }

}
