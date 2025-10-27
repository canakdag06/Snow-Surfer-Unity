using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem snowParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        snowParticles.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        snowParticles.Stop();
    }
}
