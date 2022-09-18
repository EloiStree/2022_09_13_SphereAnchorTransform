using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C360Anchor_GoToMono : MonoBehaviour
{
    public AnchorStackCommandToTriggerMono m_commandsToSent;
    public Set360LocalTransformPositionMono m_position;
    public Set360LocalRotationMono m_localRotation;


    public void SetCommandsToSentIfTrigger(string cmd)
    {
        m_commandsToSent.SetCommands(cmd);
    }
    public void SetCommandsToSentIfTrigger(params string[] cmd)
    {
        m_commandsToSent.SetCommands(cmd);
    }
    public void SetCommandsToSentIfTrigger(IEnumerable<string> cmd)
    {
        m_commandsToSent.SetCommands(cmd);
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
