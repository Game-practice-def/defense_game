using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItemClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
            GameObject tower1 = Resources.Load("Tower01") as GameObject;
            GameObject tower2 = Resources.Load("Tower02") as GameObject;
            if (clickedObject.GetComponent<Image>().sprite == tower1.GetComponent<SpriteRenderer>().sprite)
            {
                TowerSpawner.towerPrefab = tower1;
                Debug.Log("1");
            }
            else if(clickedObject.GetComponent<Image>().sprite == tower2.GetComponent<SpriteRenderer>().sprite)
            {
                TowerSpawner.towerPrefab = tower2;
                Debug.Log("2");
            }
        }
    }
}
