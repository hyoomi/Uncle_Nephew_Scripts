using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreditBtn : UIComponent
{
    Image t;

    public void OnClickCredit()
    {
        /*if (!t.isActiveAndEnabled)
            t.gameObject.SetActive(true);
        else
            t.gameObject.SetActive(false);*/

        UIMgr.Instance.TurnOnPopup("ProducerPopup", this.gameObject);
    }

}
