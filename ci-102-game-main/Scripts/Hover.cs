using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Multiline()]
    public string content;
    
    public string header;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(content,header);
    }

    public void OnPointerExit(PointerEventData evenData)
    {
        TooltipSystem.Hide();
    }
}
