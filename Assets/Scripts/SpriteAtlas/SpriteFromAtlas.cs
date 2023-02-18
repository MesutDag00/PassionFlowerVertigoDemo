using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class SpriteFromAtlas : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _gameUi;
    public string GameUiName;

    void Start() => GetComponent<Image>().sprite = _gameUi.GetSprite(GameUiName);
}