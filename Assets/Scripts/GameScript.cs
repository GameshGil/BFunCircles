using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour 
{
    public GameObject player;
    public Text scoreText;
    public Text looseText;
    public int maxScore;
    private HeroScript heroscript;

	void Start () 
	{
        heroscript = player.GetComponent<HeroScript>();
	}
	
	void Update () 
	{
        scoreText.text = heroscript.scores.ToString() + " / " + maxScore.ToString();

        if (heroscript.scores >= maxScore)
        {
            looseText.text = "Ты победил!";
            SceneManager.LoadScene(0);
        }
	}
}
