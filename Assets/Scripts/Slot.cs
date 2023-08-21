using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; // Image Component를 담는 곳

    private Item _item;
    
    public Item item
    {
        get { return _item; } // 슬롯의 item의 정보를 넘겨줄 때 사용
        set // Inventory.cs에서 사용되는 부분
        {
            _item = value; // item에 들어오는 값은 _item에 저장됨
            if (_item != null) // List<item> items에 등록된 무엇인가가 있다면
            {
                image.sprite = item.itemImage; // 스프라이트에 이미지 저장
                image.color = new Color(1, 1, 1, 1); // 알파값을 1로 하여 이미지 표시
            }
            else
            {
                image.color = new Color(1, 1, 1, 0); // 빈슬롯이면 화면에 표시 x
            }
        }
    }
}