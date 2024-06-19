using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class FadeBloom : MonoBehaviour
{
    PostProcessVolume PPV;
    Bloom bloom;
    int BLOOM = 60;
    
    private void Awake()
    {
        var PPV = GetComponent<PostProcessVolume>();
        PPV.profile.TryGetSettings(out bloom);
    }
    void Start()
    {
        StartCoroutine(BloomFade());
    }


    void Update()
    {
        
    }

    private IEnumerator BloomFade()
    {
        bloom.intensity.value = BLOOM;
        if(BLOOM > 6)
        {
            BLOOM -= 1;
            yield return new WaitForSeconds(Time.deltaTime * 4);
            StartCoroutine(BloomFade());
        }
    }
}
