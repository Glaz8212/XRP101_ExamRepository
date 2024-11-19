# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- ### 공격(Q)를 실행하면, StateAttack.cs:49에 NullReferenceException오류 발생.
  - 설정 제한 필요 (NormalMonster일 경우에 실행), null이 아닐 경우 실행
  - ```
            foreach (Collider col in cols)
        {
            if (col.CompareTag("NormalMonster"))
            {
                damagable = col.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.TakeHit(Controller.AttackValue);
                }
            }
        }
    ```
    이렇게 변경한 후 실행 -> stack overflow발생
  - stack overflow가 생기는 이유 추측.
  - 공격을 실행한 후 exit을 했음에도 delayroutine이 실행되고 있는 상태 같음.
    - bool  변수 추가 후 , enter와 exit에서 관리 => 계속 stack overflow 발생
  - 코루틴 제거 시도
    - 시간 기록 후, 2초 후에 공격 실행하도록 변경 => 계속 stack overflow 발생
  - 상태 진입과 탈출에 디버그 로그를 찍어본 결과, 계속 상태 enter와 exit을 반복하여 발생하는 것을 발견.
    - 상태 전환 쿨타임 추가 (statemachine.cs에 상태전환 쿨타임 추가) => 계속 stack overflow 발생

  ---
  일단 패스
