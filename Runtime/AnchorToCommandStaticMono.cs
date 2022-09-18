using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnchorToCommandStaticMono : MonoBehaviour
{
    public Eloi.PrimitiveUnityEvent_String m_onCommandReceived;
    private void Awake()
    {
        AnchorToCommandStatic.AddCommandListener(ListenToMessage);
    }
    private void OnEnable()
    {
        AnchorToCommandStatic.RemoveCommandListener(ListenToMessage);
        AnchorToCommandStatic.AddCommandListener(ListenToMessage);
    }
    private void OnDisable()
    {
        AnchorToCommandStatic.RemoveCommandListener(ListenToMessage);
    }

    private void OnDestroy()
    {
        AnchorToCommandStatic.RemoveCommandListener(ListenToMessage);
    }

    private void ListenToMessage(string commandSent)
    {
        m_onCommandReceived.Invoke(commandSent);
    }
}
public class AnchorToCommandStatic 
{

    public delegate void CommandReceived(string commandSent);
    public static CommandReceived m_onCommandReceived;

    public static void PushCommand(string command) { if (m_onCommandReceived != null) m_onCommandReceived(command); }
    public static void AddCommandListener(CommandReceived commandListener) { m_onCommandReceived += commandListener; }
    public static void RemoveCommandListener(CommandReceived commandListener) { m_onCommandReceived -= commandListener; }

    public static void PushCommand(IEnumerable<string> commands)
    {
        foreach (var item in commands)
        {
            PushCommand(item);
        }
    }
}
