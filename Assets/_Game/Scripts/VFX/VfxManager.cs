using UnityEngine;

public class VfxManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _playerOneVFX;
    [SerializeField] private ParticleSystem _playerTwoVFX;
    [SerializeField] private VFXSignalSenderSO _vfxSignalsenderSO;
    private ParticleSystem _currentParticleSystem;

    private void OnEnable()
    {
        _vfxSignalsenderSO.onVFXPlay += PlayVfxAtPlace;
    }

    private void OnDisable()
    {
        _vfxSignalsenderSO.onVFXPlay -= PlayVfxAtPlace;
    }

    private void PlayVfxAtPlace(ETeam team, Transform transformToPlay)
    {
        _currentParticleSystem = (team == ETeam.TeamOne)? _playerOneVFX : _playerTwoVFX;
        _currentParticleSystem.transform.position = transformToPlay.position;
        _currentParticleSystem.transform.rotation = transformToPlay.rotation;
        _currentParticleSystem.Play();
    }
}
