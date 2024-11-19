using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private float _startTime;
    private bool _hasAttacked;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Debug.Log($"상태 진입 : {ThisType}");
        _startTime = Time.time;
        _hasAttacked = false;
    }

    public override void OnUpdate()
    {
        // 공격을 실행했을 경우 리턴
        if (_hasAttacked) 
            return;

        if (Time.time - _startTime >= _delay)
        {
            Attack();
            _hasAttacked = true; 
            Exit();
        }
    }

    public override void Exit()
    {
        Debug.Log($"상태 탈출 : {ThisType}");
        Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
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
    }
}
