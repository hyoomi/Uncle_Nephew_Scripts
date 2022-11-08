using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Popup : UI_Popup
{
    private void Start()
    {
        SoundMgr.Instance.PopupPlay();
    }

}
