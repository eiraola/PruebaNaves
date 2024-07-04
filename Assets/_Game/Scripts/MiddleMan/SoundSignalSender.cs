using UnityEngine;

public class SoundSignalSender : MonoBehaviour
{
    [SerializeField] private SoundSignalSO _soundSignalSO;
    [SerializeField] private EClip _clip = EClip.Impact;

    public void SendClipSignal()
    {
        _soundSignalSO.PlayClipSound(_clip);
    }

}
