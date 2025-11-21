using UnityEngine;

public class ExplosionShotView : IShooterView
{
    private ParticleSystem _explosionVFX;

    public ExplosionShotView(ParticleSystem particleSystem)
    {
        _explosionVFX = particleSystem;
    }

    public void PlayEffect(Vector3 position)
    {
        ParticleSystem explosion = Object.Instantiate(_explosionVFX, position, Quaternion.identity);
        explosion.Play();
    }
}
