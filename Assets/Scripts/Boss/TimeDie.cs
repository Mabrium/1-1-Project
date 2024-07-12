using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDie : MonoBehaviour
{
    public BossHP BH;
    public ShotPoint SP;
    public float timeRemaining = 100f;
    public TextMeshProUGUI timerText;
    private int seconds;

    [SerializeField] private bool Starting = false;

    private void Start()
    {
        StartCoroutine(TIME());
        
    }


    public IEnumerator TIME()
    {
        yield return new WaitForSeconds(3f);
        Starting = true;
        StartCoroutine(dd());
        while (true)
        {
            BH.Damage();
            yield return new WaitForSeconds(1f);
        }
    }


    IEnumerator dd()
    {
        if (Starting)
        {
            while (timeRemaining > 0)
            {
                timeRemaining -= 1;
                Check();
                UpdateTimerDisplay();
                yield return new WaitForSeconds(1f);
            }
            
        }
        
    }

    void UpdateTimerDisplay()
    {
        seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{00}", seconds);
    }

    

    private void Check()
    {
        if (seconds >= 59)
        {
            SP.ShotOk1 = true;
            SP.patten = 0;
            StartCoroutine(SP.PointChange());
        }
        if (seconds == 40)
        {
            SP.ShotOk1 = false;
            SP.ShotOk2 = true;
            SP.patten = 1;
            StartCoroutine(SP.PointChange());
        }
        if (seconds == 20)
        {
            SP.ShotOk2 = false;
            SP.ShotOk3 = true;
            SP.patten = 2;
            StartCoroutine(SP.PointChange());
        }
    }
}
