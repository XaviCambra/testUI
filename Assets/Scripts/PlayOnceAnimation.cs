using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class PlayOnceAnimation : MonoBehaviour
{
    Animation m_Animation;

    [SerializeField] AnimationClip m_IntroClip;

    private void Start()
    {
        m_Animation = GetComponent<Animation>();
        PlayOnce(m_IntroClip);
    }
    
    public void PlayOnce(AnimationClip l_Animation)
    {
        l_Animation.legacy = true;
        
        if (m_Animation.GetClip(l_Animation.name) == null)
            m_Animation.AddClip(l_Animation, l_Animation.name);

        m_Animation.clip = l_Animation;
        m_Animation.Play();
    }
}
