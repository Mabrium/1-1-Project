using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeChange : MonoBehaviour
{

    public static SoundVolumeChange Instance;

    public Slider SoundVolume; //���� �����̴� ���� �����̴� �� ��������
    public AudioSource SoundSource; //���� ���� ������

    
    private void Start()
    {
        SoundVolume.onValueChanged.AddListener(x => SoundSource.volume = x); //�����̴� �ٿ� ���� ���尡 Ŀ���ų� �پ��
    }

    public void Save() //�ٲ� ������ ���� ���������
    {
        PlayerPrefs.SetFloat("musicVolume", SoundVolume.value);
    }

    public void Load() //�ٲ� ������ ���� �ҷ���
    {
        SoundVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
