using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private PlatformManager _platformManager;

    private void OnEnable()
    {
        _platformManager = GameObject.FindObjectOfType<PlatformManager>();
    }

}
