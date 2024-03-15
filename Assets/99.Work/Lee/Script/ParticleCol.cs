using UnityEngine;

public class ParticleCol : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        //_particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, );
    }
}
