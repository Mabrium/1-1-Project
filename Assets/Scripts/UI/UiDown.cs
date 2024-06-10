using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDown : MonoBehaviour
{
    private RectTransform RT;

    [Header("속도, 길이")]

    [SerializeField] [Range(0f, 10f)] private float speed = 1f;
    private float length = 320f;

    private float runningTime = 1.75f;
    private float xPos = 0f;
    private float yPos = 1100f;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
    }
    void Start()
    {
        xPos = this.RT.anchoredPosition.x;
        yPos = this.RT.anchoredPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        UIDOWN();
    }

    private void UIDOWN()
    {
        if(yPos > 0)
        {
            runningTime += Time.deltaTime * speed;
            yPos = Mathf.Tan(runningTime) * length * -1;
        }
        this.RT.anchoredPosition = new Vector2(xPos, yPos);
    }
}
