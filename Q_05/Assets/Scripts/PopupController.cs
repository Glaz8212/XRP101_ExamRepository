using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSeconds _wait;
    private Button _popupButton;

    [SerializeField] private GameObject _popup;
    private float _originalScore;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactiveTime);
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);

        _originalScore = GameManager.Instance.Score;
        GameManager.Instance.Score = 0;

        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        GameManager.Instance.Score = _originalScore;
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        Deactivate();
    }
}
