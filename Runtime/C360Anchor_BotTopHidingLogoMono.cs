using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C360Anchor_BotTopHidingLogoMono : MonoBehaviour
{
    public Eloi.ClassicUnityEvent_Texture m_onImageChangeRequest;
    public Set360LocalTransformPositionMono m_position;
    public Set360LocalRotationMono m_localRotation;
    public Transform m_objectToScale;

    public void Push(Texture texture)
    {
        m_onImageChangeRequest.Invoke(texture);
    }

    public void SetScale(float unityScaleRadius) {
        m_objectToScale.localScale = Vector3.one * unityScaleRadius;
    }
    public float m_defaultDistance=3;
    public Item360Angle m_top = new Item360Angle() { m_verticalDownTop = 90 };
    public Item360Angle m_down = new Item360Angle() { m_verticalDownTop = -90 };

    [ContextMenu("SetTopDefault")]
    public void SetTopDefault() { SetTop(0, m_defaultDistance); }
    public void SetTop(float horizontaLeftRightRotation, float distance)
    {
        m_position.SetPosition(m_top, distance); 
        m_position.m_localAnglePosition.m_horizontalLeftRight = horizontaLeftRightRotation;
        m_position.RefreshPosition();
    }
    [ContextMenu("SetDownDefault")]
    public void SetDownDefault() { SetDown(0, m_defaultDistance); }
    public void SetDown(float horizontaLeftRightRotation, float distance)
    {
        m_position.SetPosition(m_down, distance);
        m_position.m_localAnglePosition.m_horizontalLeftRight = horizontaLeftRightRotation;
        m_position.RefreshPosition();
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
