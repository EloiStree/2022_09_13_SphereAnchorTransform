using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C360Anchor_JustImageMono : MonoBehaviour
{
    public Eloi.ClassicUnityEvent_Texture m_onImageChangeRequest;
    public Set360LocalTransformPositionMono m_position;
    public Set360LocalRotationMono m_localRotation;

    public void Push(Texture texture) {

        m_onImageChangeRequest.Invoke(texture);
    }

    public void SetPosition(in Item360Angle angle, in float distance)
    {
        m_position.SetPosition(angle, distance);
    }
    public void SetLocalRotation(in Item360Angle angle)
    {
        m_localRotation.SetRotation(angle);
    }

}
