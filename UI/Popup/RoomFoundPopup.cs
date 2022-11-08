using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFoundPopup : UI_Popup
{    
    void Start()
    {
        SoundMgr.Instance.JoinRoomEffectPlay();
    }
}
