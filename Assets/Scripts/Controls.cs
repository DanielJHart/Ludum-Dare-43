using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Player player;

    [HideInInspector]
    public KeyCode Right, Left, Jump;

    // Use this for initialization
    void Start()
    {
        if (gameObject.name.GetHashCode() == "Player1".GetHashCode()) player = Player.One;
        else if (gameObject.name.GetHashCode() == "Player2".GetHashCode()) player = Player.Two;
        LoadControls();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadControls()
    {
        switch (player)
        {
            case Player.One:
                Right = KeyCode.D;
                Left = KeyCode.A;
                Jump = KeyCode.Space;
                break;
            case Player.Two:
                Right = KeyCode.RightArrow;
                Left = KeyCode.LeftArrow;
                Jump = KeyCode.RightShift;
                break;
            default:
                break;
        }
    }
}

public enum Player
{
    One = 0,
    Two = 1
}