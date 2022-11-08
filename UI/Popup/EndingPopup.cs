using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Winner
{   
    UNCLE,  // 삼촌 승
    NEPHEW,  // 조카 승
    NONE,   // 무승부
}

public class EndingPopup : UI_Popup
{
    [SerializeField] GameObject uncleImage;
    [SerializeField] GameObject nephewImage;
    [SerializeField] GameObject GameEndImage;
    [SerializeField] public Text winText;   // 테스트 중

    public void SetWinner(Winner winner)
    {
        if (winner == Winner.NONE)       // 무승부
        {
            return;
        }
        else if(winner == Winner.UNCLE) // 삼촌 승
        {
            if (NetworkMgr.Instance.IsMasterClient())   // 삼촌이 이겼고 삼촌인 경우 위너 설정
                NetworkMgr.Instance.IamTheWinner();

            Invoke("UncleDelay", 2f);
        }
        else                            // 조카 승
        {
            if (!NetworkMgr.Instance.IsMasterClient())  // 조카가 이겼고 조카인 경우 위너 설정
                NetworkMgr.Instance.IamTheWinner();

            Invoke("NephewDelay", 2f);
        }
    }

    void UncleDelay()
    {
        SoundMgr.Instance.PopupPlay();
        GameEndImage.SetActive(false);
        uncleImage.SetActive(true);
    }

    void NephewDelay()
    {
        SoundMgr.Instance.PopupPlay();
        GameEndImage.SetActive(false);
        nephewImage.SetActive(true);
    }
}
