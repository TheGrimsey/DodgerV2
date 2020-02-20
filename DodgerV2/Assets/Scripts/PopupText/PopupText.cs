using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
[RequireComponent(typeof(Animator))]
public class PopupText : MonoBehaviour
{
    public Animator animator;
    private Text damageText;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);

        damageText = GetComponent<Text>();
    }

    public void SetText(string Text, Color TextColor)
    {
        damageText.text = Text;
        damageText.color = TextColor;
    }
}
