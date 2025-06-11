# Unity-2D-Inventroy-System
[![동영상 설명](https://img.youtube.com/vi/feiWQlQ1I5c/0.jpg)](https://www.youtube.com/watch?v=feiWQlQ1I5c)

Unity 2D로 제작한 Inventroy System입니다. ScriptableObject을 사용하여 아이템 생성과 장착 및 해제 기능을 구현하였습니다.


[ 사용 기술 요약 ] 

ScriptableObject 를 사용한 아이템 데이터화


  [ 스크립트 구조 ]


<pre><code> 
  GameManager 
  ├── Character 
  │  └── 플레이어 정보, 장비 장착과 해제 등 관리
  │
  ├── Item 
  │  └── 아이템 기본 데이터 (이름, 설명, 아이콘, 타입 등) 
  │
  ├── EquipItem : Item 상속 
  │  └── 장비 전용 데이터 (추가 공격력, 방어력 등) 
  │
  ├── UIManager 
  │  └── 전체 UI 관련 컨트롤 
  │
  ├── UIInventory 
  │  └── 인벤토리 UI 구성 및 슬롯 관리 
  │
  │── InventoryManager 
  │  └── 인벤토리 관리
  │
  ├── UISlot 
  │  └── 인벤토리/장비 슬롯 UI 
  │  └── 슬롯 내부 아이템 표시 및 변경 처리 
  │
  ├── UIStatus 
  │  └── 플레이어 상태창 (공격력, 방어력, 능력치 등) 표시 
  │
  ├── SlotEvent 
  │  └── 슬롯 관련 이벤트 정의 (슬롯 클릭 등) 
  │
  └── UIMainMenu 
     └── 메인 메뉴 UI 처리 (플레이어 정보 표시 등) </code></pre>
