# 1번 문제

주어진 프로젝트 내에서 CubeManager 객체는 다음의 책임을 가진다
- 해당 객체 생성 시 Cube프리팹의 인스턴스를 생성한다
- Cube 인스턴스의 컨트롤러를 참조해 위치를 변경한다.

제시된 소스코드에서는 큐브 인스턴스 생성 후 아래의 좌표로 이동시키는 것을 목표로 하였다
- x : 3
- y : 0
- z : 3

제시된 소스코드에서 문제가 발생하는 `원인을 모두 서술`하시오.

## 답안
- 1-1. 프로그램 진행 시 'NullReferenceException' 오류가 발생하는 것을 발견 (CubeManager.cs:27)
  - CubeManager.cs:27 = _cubeController.SetPosition()
  - => 참조 오류가 발생함 => _cubeController가 설정되어있지 않다.
  - 설정되어있지 않은 이유.
  - SetCubePosition은 Awake()에서 실행하지만,
  - CreateCube는 Start()에서 실행한다.
  - 
  - 유니티 이벤트 함수의 호출 순서 상 Awake가 Start보다 먼저 호출되기 때문에,
  - SetCubePosition이 호출되었을 때 참조할 _cubeController 가 없다.

#### SetCubePosition과 CreateCube의 호출 순서 변경 => 실행은 정상적으로 되나, 위치를 이동하지 않는다.


- 1-2. CubeController의 스크립트를 보면, SetPoint의 Vector 3값이 private set으로 설정되어 있어서,
  - 외부에서 setposition을 호출해도 변경된 SetPoint의 값이 전달되고 있지 않다.
  - 또한, cubeSetPoint의 xyz를 설정 한 후, SetPoint에 전달하지 않고 SetPosition을 진행한다.

#### SetPoint의 프로퍼티 변경 및 _cubeSetPoint 설정,전달
