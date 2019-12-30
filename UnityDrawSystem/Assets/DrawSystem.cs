using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DrawSystem : MonoBehaviour
{
    [Header("所有道具圖片")]
    public Sprite[] spriteProps;
    [Header("速度"), Range(0.0001f, 1f)]
    public float speed = 0.01f;
    [Header("次數"), Range(1, 30)]
    public int count = 7;
    [Header("抽牌音效")]
    public AudioClip soundDraw;
    public AudioClip soundGetProp;

    private AudioSource aud;
    private Image imgProp;
    private Button btn;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
        imgProp = GameObject.Find("道具圖片").GetComponent<Image>();
        btn = GameObject.Find("抽牌按鈕").GetComponent<Button>();
    }

    public void StartDraw()
    {
        StartCoroutine(DrawEffect());
    }

    public IEnumerator DrawEffect()
    {
        btn.interactable = false;

        for (int j = 0; j < count; j++)
        {
            for (int i = 0; i < spriteProps.Length; i++)
            {
                imgProp.sprite = spriteProps[i];
                aud.PlayOneShot(soundDraw, 0.1f);
                yield return new WaitForSeconds(speed);
            }
        }

        int r = Random.Range(0, spriteProps.Length);
        imgProp.sprite = spriteProps[r];
        aud.PlayOneShot(soundGetProp, 0.6f);
        btn.interactable = true;
    }
}
