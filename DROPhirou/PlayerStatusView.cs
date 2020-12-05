using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusView : MonoBehaviour
{
    [SerializeField] Text hpText;
    [SerializeField] Text atText;
    
    public void UpdateText(int hp, int maxHp, int at)
    {
        hpText.text = string.Format("HP:{0}/{1}", hp, maxHp);
        atText.text = string.Format("AT:{0}", at);
    }
}
