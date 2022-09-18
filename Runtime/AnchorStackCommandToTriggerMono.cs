using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnchorStackCommandToTriggerMono : MonoBehaviour
{

    public bool m_autoPushOnStatic=true;
    public List<string> m_commands= new List<string>();


    public Eloi.PrimitiveUnityEvent_StringArray m_onCommandsPush;

    public void SetCommands( string command)
    {
        List<string> solo = new List<string>();
        solo.Add(command);
        m_commands = solo;
    }
    public void SetCommands(IEnumerable<string> commands)
    {
        m_commands = commands.ToList();
    }
    public void SetCommands(params string[] commands)
    {
        m_commands = commands.ToList();
    }
    public void AddCommands(params string[] commands)
    {
        m_commands.AddRange(commands);
    }
    public void ClearCommands() {
        m_commands.Clear();
    }

    [ContextMenu("Trigger Commands")]
    public void TriggerCommands() {

        m_onCommandsPush.Invoke(m_commands.ToArray());
        if (m_autoPushOnStatic)
            AnchorToCommandStatic.PushCommand(m_commands);
    }
}
