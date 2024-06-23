using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuArrow : MonoBehaviour
{
    public SceneMove SM;
    public SpriteRenderer Left_SR1;
    public SpriteRenderer Left_SR2;
    public SpriteRenderer Right_SR1;
    public SpriteRenderer Right_SR2;

    // Update is called once per frame
    void Update()
    {
        if(SM.MoveX == 0)
        {
            Left_SR1.color = Color.clear;
            Left_SR2.color = Color.clear;
        }
        else
        {
            Left_SR1.color = Color.black;
            Left_SR2.color = Color.black;
        }
        if(SM.MoveX == 4)
        {
            Right_SR1.color = Color.clear;
            Right_SR2.color = Color.clear;
        }
        else
        {
            Right_SR1.color = Color.black;
            Right_SR2.color = Color.black;
        }
    }
}
