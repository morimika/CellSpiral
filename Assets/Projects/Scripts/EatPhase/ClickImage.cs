using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickImage : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerData)
    {
        Debug.Log(this.gameObject.name+"‚ª‰Ÿ‚³‚ê‚½");

        
        Destroy(this.gameObject);
    }
}
