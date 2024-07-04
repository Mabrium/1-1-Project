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
        if(SM.MoveX == 0) //왼쪽 끝까지 오면 왼쪽 화살표 없어지기
        {
            Left_SR1.color = Color.clear;
            Left_SR2.color = Color.clear;
        }
        else
        {
            Left_SR1.color = Color.black;
            Left_SR2.color = Color.black;
        }
        if(SM.MoveX == 4) //오른쪽 끝까지 오면 오른쪽 화살표 없어지기
        {
            Right_SR1.color = Color.clear;
            Right_SR2.color = Color.clear;
        }
        else //아니면 나타나기
        {
            Right_SR1.color = Color.black;
            Right_SR2.color = Color.black;
        }
    }
}
