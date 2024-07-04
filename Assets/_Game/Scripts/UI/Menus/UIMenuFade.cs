using UnityEngine;
using UnityEngine.Events;

public class UIMenuFade : MonoBehaviour
{
    const string MENU_ANIM_FADE_IN = "FadeInMenu";
    const string MENU_ANIM_FADE_OUT = "FadeOutMenu";

    [SerializeField] private UnityEvent _onFadeInBegin = new UnityEvent();
    [SerializeField] private UnityEvent _onFadeInEnd = new UnityEvent();
    [SerializeField] private UnityEvent _onFadeOutBegin = new UnityEvent();
    [SerializeField] private UnityEvent _onFadeOutEnd = new UnityEvent();
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayFadeIn()
    {
        _animator.Play(MENU_ANIM_FADE_IN);
    }

    public void PlayFadeOut()
    {
        _animator.Play(MENU_ANIM_FADE_OUT);
    }

    public void OnFadeInbegin()
    {
        _onFadeInBegin?.Invoke();
    }

    public void OnFadeInEnd() 
    { 
        _onFadeInEnd?.Invoke();
    }

    public void OnFadeOutBegin()
    {
        _onFadeOutBegin?.Invoke();
    }

    public void OnFadeOutEnd()
    {
        _onFadeOutEnd.Invoke();
    }
}
