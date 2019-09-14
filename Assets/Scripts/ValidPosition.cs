using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidPosition : MonoBehaviour
{
    private bool _isGood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.parent == transform)
            _isGood = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _isGood = false;
    }

    public bool IsGood()
    {
        return _isGood;
    }
}
