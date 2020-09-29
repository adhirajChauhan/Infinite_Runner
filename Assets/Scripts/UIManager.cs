using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _liveSprite;

    [SerializeField]
    private Image _livesImg;

    public void Updatelives(int currentLives)
    {
        _livesImg.sprite = _liveSprite[currentLives];
    }
}
