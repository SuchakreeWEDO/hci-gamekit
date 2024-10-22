using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum KeyboardActionType{
    down,
    up,
    hold,
}

[Serializable]
public class KeyboardEventInfo {
    public KeyCode code = KeyCode.None;
    public KeyboardActionType actionType = KeyboardActionType.down;
    public UnityEvent action;
}

public class KeyboardEvent : GameKitObject
{
    public List<KeyboardEventInfo> info = new List<KeyboardEventInfo>();
    public override void Update()
    {
        base.Update();

        var text = "";
        for (int i = 0; i < info.Count; i++)
        {
            var keyboardEvent = info[i];
            switch (keyboardEvent.actionType)
            {
                case KeyboardActionType.down:
                    if(Input.GetKeyDown(keyboardEvent.code)){
                        keyboardEvent.action?.Invoke();
                        text += keyboardEvent.code + ", ";
                    }
                    break;
                case KeyboardActionType.up:
                    if(Input.GetKeyUp(keyboardEvent.code)){
                        keyboardEvent.action?.Invoke();
                    text += keyboardEvent.code + ", ";
                    }
                    break;
                case KeyboardActionType.hold:
                    if(Input.GetKey(keyboardEvent.code)){
                        keyboardEvent.action?.Invoke();
                    text += keyboardEvent.code + ", ";
                    }
                    break;
            }
        }
    }
}
