using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBtn : UIComponent
{
    [SerializeField] Sprite[] image = new Sprite[2];
    int mute; // 0 : 소리 , 1: 음소거

    void Start()
    {
        mute = 0;
    }

    public void MuteButton()
    {
        SoundMgr.Instance.MuteOrPlayAllSound();
        GetComponent<Image>().sprite = image[SoundMgr.Instance.IsMute()];
    }
}
