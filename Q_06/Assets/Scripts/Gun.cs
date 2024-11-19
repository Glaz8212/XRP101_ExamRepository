using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;
    
    public void Fire(Transform origin)
    {
        Ray ray = new(origin.position, origin.forward);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Vector3 hitPosition = new Vector3(hit.transform.position.x, 0, 0);
            Debug.Log($"{hit.transform.name} Hit!!");
            Debug.Log($"{hitPosition}");
        }
    }
    
}
