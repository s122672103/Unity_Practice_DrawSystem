using UnityEngine.UI;
using UnityEngine;

using System.Collections;

public class RandomSystem : MonoBehaviour
{
    #region

    public Sprite[] sprites;

    [Header("間隔時間"), Range(0f, 1f)]
    public float speed = 0.1f;
    [Header("次數"), Range(1, 10)]
    public int count = 1;
    public AudioClip soundRandom;
    public AudioClip soundStop;
    private int randomIndex;
    [Header("技能圖片")]
    private Image imgSkill;
    private AudioSource aud;
    private Button btn;

    #endregion


    private void Start()
    {
        aud = GetComponent<AudioSource>();
        btn = GameObject.Find("抽牌按鈕").GetComponent<Button>();
        imgSkill = GetComponent<Image>();
       
    }



    public IEnumerator StartRandom()
    {
        btn.interactable = false;
        for (int j = 0; j < count; j++)
        {

        for (int i = 0; i < sprites.Length; i++)
        {
            imgSkill.sprite = sprites[i];
            aud.PlayOneShot(soundRandom, 1f);
            yield return new WaitForSeconds(speed);

        }
        }
        randomIndex = Random.Range(0,sprites.Length);
        imgSkill.sprite = sprites[randomIndex];
        aud.PlayOneShot(soundStop, 1f);
        btn.interactable = true;
    
    }

}
