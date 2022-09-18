using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C360Anchor_SoundSourceMono : MonoBehaviour
{
    public AudioSource m_audioSource;
    public Set360LocalTransformPositionMono m_position;


    public void SetPosition(Item360Angle angle, float distance) {
        m_position.SetPosition(angle, distance);
    }
    public void GetAudioSource(out AudioSource source) { source = m_audioSource; }
    public AudioSource GetAudioSource() { return m_audioSource; }

    public void Play(AudioClip clip, bool loop) {
        m_audioSource.clip = clip;
        m_audioSource.loop = loop;
        m_audioSource.Stop();
        m_audioSource.Play();
    }
}
