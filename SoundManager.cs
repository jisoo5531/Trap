//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public class Sound
//{
//    public string soundName;
//    public AudioClip clip;
//}
//public class SoundManager : MonoBehaviour
//{
//    [Header("���� ���")]
//    [SerializeField] Sound[] bgmSounds;

//    [Header("��� �÷��̾�")]
//    [SerializeField] AudioSource bgmPlayer;

//    // Start is called before the first frame update
//    void Start()
//    {
//        PlayRandomBGM();
//    }

//    public void PlayRandomBGM()
//    {
//        int random = Random.Range(0, 2);
//        bgmPlayer.clip = bgmSounds[random].clip;
//        bgmPlayer.Play();
//    }
//}