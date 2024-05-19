using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIGnW : MonoBehaviour
{
    public RectTransform RT;
    private int SceneNumber = 0;

    private void Awake()
    {
        RT = GetComponent<RectTransform>();
    }
    void Start()
    {
        StartCoroutine(ChangeX());
    }
    private void Update()
    {
        GnWMove();
        
    }

    private IEnumerator ChangeX()
    {
        RT.Rotate(0, 180, 0);
        yield return new WaitForSeconds(0.3f);
        RT.Rotate(0, 0, 0);
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(ChangeX());
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
