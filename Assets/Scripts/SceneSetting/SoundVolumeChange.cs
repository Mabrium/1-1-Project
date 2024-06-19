using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeChange : MonoBehaviour
{

    public static SoundVolumeChange Instance;

    public Slider SoundVolume; //볼륨 슬라이더 바의 슬라이더 값 가져오기
    public AudioSource SoundSource; //볼륨 사운드 가져옴

    
    private void Start()
    {
        SoundVolume.onValueChanged.AddListener(x => SoundSource.volume = x); //슬라이더 바에 따라 사운드가 커지거나 줄어듦
    }

    public void Save() //바뀐 사운드의 값을 저장시켜줌
    {
        PlayerPrefs.SetFloat("musicVolume", SoundVolume.value);
    }

    public void Load() //바뀐 사운드의 값을 불러옴
    {
        SoundVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
