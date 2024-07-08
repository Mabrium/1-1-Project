using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class FadeBloom : MonoBehaviour
{
    PostProcessVolume PPV;
    Bloom bloom;
    int STARTBLOOM;
    int BLOOM;


    private void Awake()
    {
        var PPV = GetComponent<PostProcessVolume>();
        PPV.profile.TryGetSettings(out bloom);
    }
    void Start()
    {
        //StartCoroutine(bloom_fade());.
        //StartCoroutine(start_fade());
    }


    void Update()
    {
        
    }
    public void BloomFade()
    {
        BLOOM = 60;
        StartCoroutine(bloom_fade());
    }

    public void StartFade()
    {
        STARTBLOOM = 17;
        StartCoroutine(start_fade());
    }
    private IEnumerator bloom_fade()
    {
        
        bloom.intensity.value = BLOOM;
        if(BLOOM > 6)
        {
            BLOOM -= 1;
            yield return new WaitForSeconds(Time.deltaTime * 4);
            StartCoroutine(bloom_fade());
        }
    }
    private IEnumerator start_fade()
    {
        bloom.intensity.value = STARTBLOOM;
        if (STARTBLOOM < 60)
        {
            STARTBLOOM += 1;
            yield return new WaitForSeconds(Time.deltaTime * 30);
            StartCoroutine(start_fade());
        }
    }
}
