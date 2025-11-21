using UnityEngine;

public class ExplosionShotView : IShooterView
{
    private const float ReferenceParticleRadius = 5f; 
    private ParticleSystem _explosionVFX;

    public ExplosionShotView(ParticleSystem particleSystem)
    {
        _explosionVFX = particleSystem;
    }

    public void PlayEffect(Vector3 position, float actualRadius)
    {
        ParticleSystem explosion = Object.Instantiate(_explosionVFX, position, Quaternion.identity);

        float scaleValue = actualRadius / ReferenceParticleRadius;

        explosion.transform.localScale = Vector3.one * scaleValue;
        explosion.Play();
    }
}
