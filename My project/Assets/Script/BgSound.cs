using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSound : MonoBehaviour
{
    public AudioSource[] mysounds;
  
    private AudioSource tapSound;
    private AudioSource jumpSound;
    private AudioSource windSound;
    private AudioSource dieSound;
    private AudioSource hitSound;
    
    public AudioSource musicSource;
    void Start()
    {
        musicSource.Play();
        tapSound = mysounds[0];
        jumpSound = mysounds[1];
        windSound = mysounds[2];
        dieSound = mysounds[3];
        hitSound = mysounds[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static BgSound instance = null;
    public static BgSound Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake() {
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }
        else{
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayMusic(){
            musicSource.Play();
       }
    public void PlayTap(){
            tapSound.Play();
    }
    public void PlayWind(){    
            windSound.Play();
    }
    public void PlayJump(){
            jumpSound.Play();
    }
    public void PlayHit(){
        hitSound.Play();
    }
    public void PlayDie(){
        dieSound.Play();
    }
}
