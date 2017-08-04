using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlayButtonScript : Button {

    private Image i;

    protected override void Start()
    {
        i = GetComponent<Image>();
        base.Start();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {

        Debug.Log("pointer entered play button");
        base.OnPointerEnter(eventData);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("pointer clicked in play button");

        base.OnPointerClick(eventData);
    }

    private void SetColors()
    {

        ColorBlock c = new ColorBlock() { 
            normalColor = this.colors.normalColor,
            highlightedColor = this.colors.highlightedColor,
            pressedColor = this.colors.pressedColor,
            disabledColor = this.colors.disabledColor,
            colorMultiplier = 5f,
            fadeDuration = this.colors.fadeDuration
        };

        this.colors = c;
    }
}
