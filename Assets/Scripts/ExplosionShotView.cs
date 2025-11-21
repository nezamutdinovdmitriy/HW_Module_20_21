using UnityEngine;

public class ExplosionShotView : IShooterView
{
    private IShooter _explosionShotLogic;
    private ParticleSystem _explosionVFX;

    public ExplosionShotView(ParticleSystem particleSystem, IShooter explosionShotLogic)
    {
        _explosionVFX = particleSystem;
        _explosionShotLogic = explosionShotLogic;
    }

    public void PlayEffect(Vector3 position)
    {
        ParticleSystem explosion = Object.Instantiate(_explosionVFX, position, Quaternion.identity);
        explosion.Play();
    }
}
