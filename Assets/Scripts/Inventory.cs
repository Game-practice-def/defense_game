using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items; // 아이템을 담을 리스트 (인벤토리에 여러개가 들어가므로)

    [SerializeField]
    private Transform slotParent; // Slot의 부모가 될 Stash를 담는 곳
    [SerializeField]
    private Slot[] slots; // Slot을 담는 곳

    private void OnValidate() // OnValidate -> 유니티 에디터에서 바로 작동하도록 하는 역할. 
    {
        slots = slotParent.GetComponentsInChildren<Slot>(); // Stash를 넣어주면 slots에 Slot들이 자동으로 등록됩니다.
    }

    void Awake()
    {
        FreshSlot(); // 게임이 시작되면 items에 들어있는 아이템을 인벤토리에 넣어줌
    }

    public void FreshSlot() // Slot의 내용을 정리하여 화면에 보여주는 기능
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++) // items에 들어있는 수만큼 slots에 차례대로 item을 넣어줌 
        { // i가 items와 slots의 값보다 작아야만 돌아감 (items의 수가 slots의 수보다 많으면 안되기 때문)
            slots[i].item = items[i]; // slot에 아이템이 들어가면 Slot.cs에 선언된 item의 set이 실행되어 슬롯에 이미지 표시
        }
        for (; i < slots.Length; i++) // slot에 아이템을 다 저장하고 난 후에 slot이 남아있다면 빈 슬롯들은 null처리
        { // i가 첫번째 돌고 그 이후 값부터 시작 (i가 슬롯의 순서)
            slots[i].item = null; // null의 값은 Slot.cs에서 이미지의 알파값을 0으로 두어 숨김
        }
    }

    public void AddItem(Item _item) // 아이템의 추가인 경우 해당 함수를 불러서 넣어주면 됨 -> 시간마다 획득하도록 코루틴 작성
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("인벤토리가 가득 찼습니다.");
        }
    }
}