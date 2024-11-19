# 5번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 01. Main Scene
- 실행 시, Start 버튼을 누르면 게임매니저를 통해 게임 씬이 로드된다.

### 02. Game Scene
- Go to Main을 누르면 메인 씬으로 이동한다
- `+`버튼을 누르면 큐브 오브젝트의 회전 속도가 증가한다
- `-`버튼을 누르면 큐브 오브젝트의 회전 속도가 감소한다 (-가 될 경우 역방향으로 회전한다)
- Popup 버튼을 누르면 게임 오브젝트가 정지(큐브의 회전이 정지)하며, Popup창을 출력한다. 이 때 출력된 팝업창은 2초 후 자동으로 닫힌다.

### 공통 사항
- 게임 실행 중 씬 전환 시에도 큐브 오브젝트의 회전 속도는 저장되어 있어야 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- ### 모든 버튼들이 작동을 하지 않음
  - => EventSystem의 부재 -> EventSystem각 씬에 추가 후 해결
- ### Popup 버튼을 눌러도 게임 오브젝트가 정지하지 않음
  -  지금 GameManager의 Pause (timescale = 0)을 호출해서 사용하고 있지만, 큐브의 회전이 time을 사용하지 않으므로 실행이 안되는 것 같음.
  -  Pause 메서드 제거 후, popupcontroller에서 직접 gamemanager의 score를 0으로 만듦.
  -  그 후에, 팝업창이 사라지면 다시 score에 원래 값 할당 -> 해결
- ### 씬 전환 시 회전 속도 저장 문제
  - 싱글톤이 제대로 적용 되지 않는 것 같음.
  - Gamemanager의 awake에서 singletoninit을 호출하는데, _instance가 null이 아닌 경우에도 score를 초기화 함.
  - ```
            if (Instance == null)
        {
            SingletonInit();
            Score = 0.1f;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    ```
    로 수정
