using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    private float timeLeft = 120;
    public int playerScore = 10;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

    public AudioSource Audio;
    public AudioClip audioCoin;
    public AudioClip audioEnd;


    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Power: " + (int)playerScore);

        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene(0);
        }

    }
    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name=="LevelEndBarrier")
        {
            Audio.clip = audioEnd;
            Audio.Play();
            CountScore();

        }
        if (trig.gameObject.name == "Coin")
        {
            Audio.clip=audioCoin;
            Audio.Play();

            playerScore += 10;
            
            Destroy(trig.gameObject);
        }
       
    }
    void CountScore()
    {
        int Score = playerScore;// + (int)(timeLeft*10);
        


        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(2);

        }
        SceneManager.LoadScene(0);
    }

}
