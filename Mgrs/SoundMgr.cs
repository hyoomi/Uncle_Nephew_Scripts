using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : SingletonBehaviour<SoundMgr>
{
    // 음악 기본 볼륨
    const float BGMVOL = 1f;
    const float EFFECTVOL = 1f;

    // 사운드 소스
    [SerializeField] AudioSource bgmSource;   // 배경음악
    [SerializeField] AudioSource popupSource;    // 팝업 음악
    [SerializeField] AudioSource buttonSource;  // 버튼 음악
    [SerializeField] AudioSource effectSource;  // 각종 효과음악

    // 배경음악 오디오 클립
    [SerializeField] AudioClip mainBGM;

    // 팝업음악 오디오 클립
    [SerializeField] AudioClip popupEffect; // 구겨진 종이가 펴지는 소리: 팝업

    // 버튼소리 오디오 클립
    [SerializeField] AudioClip touchButton; // 뿅: 인게임1245
    [SerializeField] AudioClip inputButton; // 버튼입력소리: 대기실
    [SerializeField] AudioClip prologueButton; // 종이 넘기는 소리: 프롤로그

    // 효과음악 오디오 클립
    [SerializeField] AudioClip joinRoomEffect; // 대기실 찾는 소리: 대기실
    [SerializeField] AudioClip intro1Effect; // 구겨진 종이가 펴지는 소리: 인트로1
    [SerializeField] AudioClip intro2Effect; // 뿅: 인트로2
    [SerializeField] AudioClip capEffect; // 뚜껑 미끌어지는 소리: 인게임1
    [SerializeField] AudioClip capFallEffect; // 뚜껑 떨어지는 소리
    [SerializeField] AudioClip bagInEffect; // 부스럭_비닐봉투: 인게임2
    [SerializeField] AudioClip bagOutEffect; // 부스럭_과자봉지
    [SerializeField] AudioClip wrongEffect; // 비빅-에러: 인게임2, 5
    [SerializeField] AudioClip runEffect; // 발자국소리: 인게임3   
    [SerializeField] AudioClip microEffect; // 전자레인지전체: 인게임4
    [SerializeField] AudioClip tabletEffect; // 비타민: 인게임5

    private new void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        bgmSource.clip = mainBGM;
        bgmSource.volume = BGMVOL;
        bgmSource.loop = true;

        popupSource.clip = popupEffect;
        popupSource.volume = EFFECTVOL;
        popupSource.loop = false;

        buttonSource.clip = touchButton;
        buttonSource.volume = EFFECTVOL;
        buttonSource.loop = false;

        effectSource.clip = capEffect;
        effectSource.volume = EFFECTVOL;
        effectSource.loop = false;

        MainBGMPlay();
    }

    // 배경음악
    public void MainBGMPlay()
    {
        bgmSource.clip = mainBGM;       
        bgmSource.Play();       
    }    

    // 팝업음악
    public void PopupPlay()
    {
        popupSource.clip = popupEffect;
        popupSource.Play();
    }        
    
    // 버튼음악
    public void TouchButtonPlay()
    {
        buttonSource.clip = touchButton;
        buttonSource.Play();
    } 
    public void InputButtonPlay()
    {
        buttonSource.clip = inputButton;
        buttonSource.Play();
    }
    public void PrologueButtonPlay()
    {
        buttonSource.clip = prologueButton;
        buttonSource.Play();
    }

    // 효과음악
    public void JoinRoomEffectPlay()
    {
        effectSource.clip = joinRoomEffect;
        effectSource.Play();
    }
    public void Intro1EffectPlay()
    {
        effectSource.clip = intro1Effect;
        effectSource.Play();
    }
    public void Intro2EffectPlay()
    {
        effectSource.clip = intro2Effect;
        effectSource.Play();
    }
    public void CapEffectPlay()
    {
        effectSource.clip = capEffect;
        effectSource.Play();
    }
    public void CapFallEffectPlay()
    {
        effectSource.clip = capFallEffect;
        effectSource.Play();
    }
    public void BagInEffectPlay()
    {
        effectSource.clip = bagInEffect;
        effectSource.Play();
    }
    public void BagOutEffectPlay()
    {
        effectSource.clip = bagOutEffect;
        effectSource.Play();
    }
    public void WrongEffectPlay()
    {
        effectSource.clip = wrongEffect;
        effectSource.Play();
    }
    public void RunEffectPlay()
    {
        effectSource.clip = runEffect;
        effectSource.Play();
    }
    public void MicroEffectPlay()
    {
        effectSource.clip = microEffect;
        effectSource.Play();
    }
    public void TabletEffectPlay()
    {
        effectSource.clip = touchButton;       
        effectSource.Play();
        StartCoroutine(OtherNetworkMainPage());
    }

    private IEnumerator OtherNetworkMainPage()
    {
        Debug.Log("사운드 코루틴 시작");
        yield return new WaitUntil(() => !effectSource.isPlaying); // 뿅이 끝날때까지 기다린 후
        buttonSource.clip = tabletEffect;
        buttonSource.Play();    // 비타민 소리 재생    
        Debug.Log("사운드 코루틴 종료");
    }

    public void MuteOrPlayAllSound()
    {
        if(bgmSource.volume == 0)
        {
            bgmSource.volume = BGMVOL;
            popupSource.volume = EFFECTVOL;
            buttonSource.volume = EFFECTVOL;
            effectSource.volume = EFFECTVOL;
        }
        else
        {
            bgmSource.volume = 0;
            popupSource.volume = 0;
            buttonSource.volume = 0;
            effectSource.volume = 0;
        }       
    }

    public int IsMute()
    {
        if (bgmSource.volume == 0)
            return 1;
        return 0;
    }
}
