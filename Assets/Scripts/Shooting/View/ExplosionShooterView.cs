using UnityEngine;

public class ExplosionShooterView : IShooterView
{
    private const float ReferenceParticleRadius = 5f;
    private float _radius;
    private ParticleSystem _explosionVFX;

    public ExplosionShooterView(ParticleSystem particleSystem, float radius)
    {
        _explosionVFX = particleSystem;
        _radius = radius;
    }

    public void PlayEffect(Vector3 position)
    {
        ParticleSystem explosion = Object.Instantiate(_explosionVFX, position, Quaternion.identity);

        float scaleValue = _radius / ReferenceParticleRadius;

        explosion.transform.localScale = Vector3.one * scaleValue;
        explosion.Play();
    }
}
