using UnityEngine;

public class ExplosionShotView : IShooterView
{
    private IShooter _explosionShotLogic;

    public ExplosionShotView(ParticleSystem particleSystem, IShooter explosionShotLogic)
    {
        ParticleSystem = particleSystem;
        _explosionShotLogic = explosionShotLogic;
    }
    public ParticleSystem ParticleSystem { get; private set; }

    public void ShowEffect()
    {
        ParticleSystem.Play();
        _explosionShotLogic.ResetShot();
    }
}
