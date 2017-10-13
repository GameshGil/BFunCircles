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
    private HeroScript heroScript;

	void Start () 
	{
        heroScript = player.GetComponent<HeroScript>();
	}
	
	void Update () 
	{
        scoreText.text = heroScript.scores.ToString() + " / " + maxScore.ToString();

        if (heroScript.scores >= maxScore && !heroScript.isDead)
        {
            looseText.text = "Ты победил!";
            SceneManager.LoadScene(0);
        }
        if (heroScript.isDead)
        {
            looseText.text = "Ты проиграл!";
            looseText.color = new Color(1f, 0.2f, 0);
            StartCoroutine(Restart());
        }
	}

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
