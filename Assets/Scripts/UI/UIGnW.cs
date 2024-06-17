using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIGnW : MonoBehaviour
{
    public Image image;
    public Sprite[] sprite;
    private RectTransform RT;
    private int SceneNumber = 0;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
    }
    void Start()
    {
        StartCoroutine(ChangeSprige());
    }
    private void Update()
    {
        GnWMove();
        
    }

    private IEnumerator ChangeSprige()
    {
        image.sprite = sprite[0];
        yield return new WaitForSeconds(0.3f);
        image.sprite = sprite[1];
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(ChangeSprige());
    }

    private void GnWMove()
    {
        if(Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            RT.localPosition = new Vector2(190, 80);
            SceneNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
        {
            RT.localPosition = new Vector2(190, -270);
            SceneNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (SceneNumber) 
            { 
                case 0: SceneManager.LoadScene("Test");
                    break;
                case 1: SceneManager.LoadScene("Library");
                        break;
            }
        }
    }
}
