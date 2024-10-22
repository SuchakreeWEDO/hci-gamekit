using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class DataUIUpdater : GameKitObject
{
    public TextMeshProUGUI textUI;
    public CustomData<float> data;

    public override void Update()
    {
        base.Update();
        if(data && textUI){
            textUI.text = data.ToText();
        }
    }
}
