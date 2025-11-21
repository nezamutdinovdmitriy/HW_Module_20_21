using UnityEngine;

public interface IShooterView
{
    public ParticleSystem ParticleSystem { get; }
    public void ShowEffect();
}
