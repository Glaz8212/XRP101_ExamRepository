using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            DieSound();
        }
    }

    public void DieSound()
    {
        Debug.Log($"{_audio.clip.name} Àç»ý");
        _audio.PlayOneShot(_audio.clip);
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(_audio.clip.length);
        gameObject.SetActive(false);
    }
}
