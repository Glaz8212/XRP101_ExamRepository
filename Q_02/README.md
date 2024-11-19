# 2번 문제

주어진 프로젝트 내에서 제공된 스크립트(클래스)는 다음의 책임을 가진다
- PlayerStatus : 플레이어 캐릭터가 가지는 기본 능력치를 보관하고, 객체 생성 시 초기화한다
- PlayerMovement : 유저의 입력을 받고 플레이어 캐릭터를 이동시킨다.

프로젝트에는 현재 2가지 문제가 있다.
- 유니티 에디터에서 Run 실행 시 윈도우에서는 Stack Overflow가 발생하고, MacOS의 유니티에서는 에디터가 강제종료된다.
- 플레이어 캐릭터가 X, Z축의 입력을 동시입력 받아서 대각선으로 이동 시 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르다.

두 가지 문제가 발생한 원인과 해결 방법을 모두 서술하시오.

## 답안

- 2-1. Run 실행 시, Stack Overfloaw가 발생하는 스크립트 PlayerStatus.cs10
  - ```
    public float MoveSpeed
    {
        get => MoveSpeed;
        private set => MoveSpeed = value;
    }
    ```
    get과 set에 같은 변수가 사용되어, 계속 재귀 호출이 진행되어 stack overflow를 발생시킴.

####     public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }로 수정

- 2-2. Transform의 Vector3 이동방향이 정규화(normalized)되어있지 않아서,
대각선으로 이동 시 1.41배 빠르게 움직임.

####         transform.Translate(_status.MoveSpeed * Time.deltaTime * direction.normalized);
direction에 normalized를 추가해, 방향벡터로 변경
