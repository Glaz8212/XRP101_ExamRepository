# 6번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### FPS 조작 구현
- 실행 시, 마우스 커서가 비활성화되며 마우스 회전으로 플레이어의 시야가 회전한다.
- 현재 바라보고 있는 방향 기준으로 W, A, S, D로 전, 후, 좌, 우 이동을 수행한다
- 마우스 좌클릭 시, 시야 정면 방향으로 레이를 발사하고 레이캐스트에 검출된 적의 이름을 콘솔에 로그로 출력한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- ### 레이캐스트에 검출된 적의 이름의 로그가 출력되지 않는 문제
  - playercontroller 인스펙터에서 Gun의 targetlayer => enemy로 설정.
- ### 카메라가 이동하지 않는 문제
  - cameracontroller 에서, transform 즉, 카메라가 아닌 _followTarget이 transform의 위치에 따라 setPositionAndRotation중.
  - transform(카메라)가 _followTarget(플레이어)의 위치에 따라 setpositionandrotation하게 설정.
- ### 레이캐스트를 Gun 스크립트에서 origin.position, vector3.forward로 설정해서, 한 방향으로만 나가는 문제
  - vector3.forward를 origin.forward로 수정해, muzzlePoint의 전방으로 발사하게 설정.
