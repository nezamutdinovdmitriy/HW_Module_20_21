using UnityEngine;

public class ExplosionShooterView : IShooterView
{
    private const float ReferenceParticleRadius = 5f;
    private ParticleSystem _explosionVFX;
    private ExplosionShooter _shooter;

    public ExplosionShooterView(ParticleSystem particleSystem, ExplosionShooter shooter)
    {
        _explosionVFX = particleSystem;
        _shooter = shooter;
    }

    public void PlayEffect(Vector3 position)
    {
        ParticleSystem explosion = Object.Instantiate(_explosionVFX, position, Quaternion.identity);

        float scaleValue = _shooter.Radius / ReferenceParticleRadius;

        explosion.transform.localScale = Vector3.one * scaleValue;
        explosion.Play();
    }
}
