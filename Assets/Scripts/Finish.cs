using UnityEngine;

public class Finish : MonoBehaviour
{
    AudioSource m_AudioSource;
    [SerializeField] ParticleSystem finishParticlSys;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.collider.TryGetComponent(out Head head))
        {
            finishParticlSys.Play();
            m_AudioSource.Play();
            head.ReachFinish();
        }
    }
}
