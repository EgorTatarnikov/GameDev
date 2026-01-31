using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region PrintInfiniteEvent
    static MainMenu mainMenuScriptInvoker;
    static UnityAction mainMenuScriptListener;

    public static void AddInvokerPrintInfiniteEvent(MainMenu script)
    {
        mainMenuScriptInvoker = script;
        if (mainMenuScriptListener != null)
        {
            mainMenuScriptInvoker.AddPrintInfiniteEvent(mainMenuScriptListener);
        }
    }

    public static void AddListenerPrintInfiniteEvent(UnityAction handler)
    {
        mainMenuScriptListener = handler;
        if (mainMenuScriptInvoker != null)
        {
            mainMenuScriptInvoker.AddPrintInfiniteEvent(mainMenuScriptListener);
        }
    }
    #endregion
}
