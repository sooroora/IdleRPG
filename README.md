# 🤖 3D 방치형 게임

## 1. 프로젝트 개요
플레이어의 자동 전투로 진행되는 3D 방치형 RPG입니다


## 2. 주요 기능

#### ⚙️ **StateMachine**
각 캐릭터(Player, Monster)가 가지는 행동 흐름을 제어하는 구조입니다.

Idle, Move, Attack 같은 상태를 독립된 클래스로 관리하고, 현재 상황에 따라 상태 전환을 자동으로 처리합니다.

상태별 로직이 분리되어 있어서 디버깅과 확장이 쉽고, 캐릭터별 전투·이동 로직을 안정적으로 관리할 수 있습니다.


#### 🗺️ **StageSystem**
방치형 구조에 맞춘 스테이지 진행 시스템입니다.

스테이지는 자동으로 다음 단계로 넘어가며, 사용자가 직접 선택해서 이동할 수도 있습니다.


#### 🔎 **RayDetectror**
특정 타이밍에 원하는 타입의 컴포넌트가 붙은 오브젝트를 찾기 위한 도구입니다.

제너릭 기반으로 만들어져 있어서 필요에 맞게 확장하거나 다른 타입을 쉽게 검색할 수 있습니다.

몬스터 탐지, 플레이어 상호작용, 타겟팅 등 여러 곳에서 공통적으로 사용할 수 있는 구조입니다.


## 3. 개발 기간
2025.11.24 ~

## 4. 스크린샷
<img width="392" height="701" alt="image" src="https://github.com/user-attachments/assets/afdbb28b-9b7d-492d-b21a-4ea8dedecf05" />


## 5. 사용 스택
언어 (Language): C#

개발 환경 (Engine & Tools): Unity 2022, Rider

핵심 기능 (Core Features): NavMesh, StateMachine


## 6. 프로젝트 스트립트 구조

```
Assets
└── 📂 01_Scripts
    │
    ├── 📂 00_Game                                   # 게임 로직
    │   ├── GameCommon.cs
    │   ├── MonsterWavePoint.cs
    │   └── Stage.cs
    │
    ├── 📂 00_Managers                               # 매니저
    │   ├── CameraManager.cs
    │   ├── GameManager.cs
    │   ├── PoolManager.cs
    │   ├── PoolObject.cs
    │   ├── SceneSingletonManager.cs
    │   ├── 📂 DontDestroy
    │   │   ├── SceneTransferManager.cs
    │   │   ├── ScreenManager.cs
    │   │   ├── SingletonManager.cs
    │   │   └── 📂 SoundManager
    │   │       ├── AudioClipGroup.cs
    │   │       ├── SoundManager.cs
    │   │       ├── 📂 Enum
    │   │       │   ├── ESoundClipName.cs
    │   │       │   └── ESoundSettingName.cs
    │   │       └── (sound-related files)
    │   └── (etc)
    │
    ├── 📂 01_Characters                              # 캐릭터 및 전투 로직
    │   ├── Character.cs
    │   ├── Monster.cs
    │   ├── Player.cs
    │   │
    │   ├── 📂 StateMachine                           # 스테이트 머신 구조
    │   │   ├── BaseState.cs
    │   │   ├── CharacterStateMachine.cs
    │   │   ├── MonsterStateMachine.cs
    │   │   ├── PlayerStateMachine.cs
    │   │   ├── StateMachine.cs
    │   │   └── 📂 CharacterState
    │   │       ├── AttackState.cs
    │   │       ├── ChaseState.cs
    │   │       ├── ControllableState.cs
    │   │       ├── DieState.cs
    │   │       ├── HitState.cs
    │   │       ├── IdleState.cs
    │   │       ├── MoveToState.cs
    │   │       └── WalkState.cs
    │   │
    │   └── 📂 Status                                  # 캐릭터 스테이터스 및 UI
    │       ├── CharacterStatus.cs
    │       ├── 📂 Condition
    │       │   ├── Condition.cs
    │       │   └── ConditionUI.cs
    │
    ├── 📂 02_Inventory                               # 인벤토리 / 아이템
    │   ├── ConsumableItem.cs
    │   ├── EquipItem.cs
    │   ├── Inventory.cs
    │   ├── Item.cs
    │   └── 📂 Data
    │       ├── BaseObjectData.cs
    │       ├── ConsumableEffect.cs
    │       ├── ConsumableItemData.cs
    │       ├── EquipItemData.cs
    │       └── ItemData.cs
    │
    ├── 📂 03_UI                                      # UI 스크립트
    │   ├── BottomMenuUI.cs
    │   └── HudUI.cs
    │
    ├── 📂 90_ScriptableObjects                       # SO 데이터
    │   ├── CharacterStatusData.cs
    │   ├── MonsterRewardData.cs
    │   └── StageData.cs
    │
    ├── 📂 99_Enums                                   # Enum 모음
    │   ├── CommonEnums.cs
    │   └── GameEnums.cs
    │
    └── 📂 99_Utilities                               # 유틸리티 도구
        ├── Billboard.cs
        ├── CustomExtensions.cs
        ├── PositionMark.cs
        ├── SimplePool.cs
        ├── Utility.cs
        └── 📂 RayDetector
            ├── MonsterRayDetector.cs
            ├── PlayerRayDetector.cs
            └── RayDetector.cs

```
