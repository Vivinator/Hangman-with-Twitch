using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

public class hangmanGame : MonoBehaviour {

	int difficulty; // creates a random number between 1 and 4 to select difficulty
	int wordNumber; // create a random number between 0 and 4 to select a word

	string[] words = new string[20];
	string chosenWord;
		
	public Text wordIndicator;
	public Text scoreIndicator;
    public TwitchChat chatScript;

	private hangmanController hangman;
	private string word;
	private char[] revealed;
    private char s;
	private int score;
	private bool completed;
    private float timeLeft = 10.0f;

	// Use this for initialisation
	void Start()
	{
		InitialiseString ();
		hangman = GameObject.FindGameObjectWithTag ("Player").GetComponent <hangmanController>();

		Reset ();
	}

	// Update is called once per frame
	void Update()
	{
		// Move to the next word
		if (completed)
		{
			//string tmp = Input.inputString;
			if (Input.anyKeyDown)
			{
				Next ();
			}

            timeLeft -= Time.deltaTime;
            Debug.Log("Time Left: " + timeLeft);
            if (timeLeft <= 0)
            {
                Next();
            }
		}

		/*if (!Input.anyKeyDown)
		{
			return;
		}*/
             
	}

    public void CheckLetter()
    {
        //s = Input.inputString;
        s = chatScript.letter;
        s = char.ToUpper(s);
        if (textUtils.isAlpha(s))
        {
            Debug.Log("Have " + s);
            // Check for player failure
            if (!Check(char.ToUpper(s)))
            {
                hangman.punish();

                if (hangman.isDead)
                {
                    wordIndicator.text = word;
                    completed = true;
                }
            }
        }
    }

	private bool Check (char c)
	{
		bool ret = false;
		int complete = 0;
		int score = 0;

		for (int i = 0; i < revealed.Length; i++)
		{
			if (c == word[i])
			{
				ret = true;
				if (revealed[i] == 0)
				{
					revealed [i] = c;
					score++;
				}
			}

			if (revealed[i] != 0)
			{
				complete++;
			}
		
		}

		// Score Manipulation
		if (score != 0)
		{
			this.score += score;
			if (complete == revealed.Length)
			{
				this.completed = true;
				this.score += revealed.Length;
			}

			UpdateWordIndicator ();
			UpdateScoreIndicator ();
		}

		return ret;
	}

	public void InitialiseString()
	{
		words [0] = "cat"; //3 EASY
		words [1] = "happy"; //5 EASSY
		words [2] = "game"; //4 EASY
		words [3] = "easy"; //4 EASY
		words [4] = "house"; //5 EASY
		words [5] = "animator"; //8 MEDIUM
		words [6] = "sparkles"; //8 MEDIUM
		words [7] = "toilet"; //6 MEDIUM
		words [8] = "juggler"; //7 MEDIUM
		words [9] = "monster"; //7 MEDIUM
		words [10] = "dictionary"; //10 HARD
		words [11] = "developer"; //9 HARD
		words [12] = "ebullient"; //9 HARD 
		words [13] = "bellweather"; //11 HARD
		words [14] = "nidificate"; //10 HARD
		words [15] = "onomatopoeia"; //12 SUPER HARD
		words [16] = "sesquipedalian"; //14 SUPER HARD
		words [17] = "circumlocution"; // 14 SUPER HARD
		words [18] = "conviviality"; //12 SUPER HARD
		words [19] = "acknowledgement"; //15 SUPER HARD
	}

	public void SelectDifficulty()
	{
		difficulty = Random.Range (1, 4);
		switch (difficulty)
		{
		case 1:
			wordNumber = Random.Range (0, 4);
			chosenWord = words [wordNumber];
			break;
		case 2:
			wordNumber = Random.Range (5, 9);
			chosenWord = words [wordNumber];
			break;
		case 3:
			wordNumber = Random.Range (10, 14);
			chosenWord = words [wordNumber];
			break;
		case 4:
			wordNumber = Random.Range (15, 19);
			chosenWord = words [wordNumber];
			break;
		}
	}

	public void UpdateWordIndicator()
	{
		string displayed = "";

		// Build up the display string
		for (int i = 0; i < revealed.Length; i++)
		{
			char c = revealed [i];
			if (c == 0)
			{
				c = '_';
			}
			displayed += ' ';
			displayed += c;
		}

		wordIndicator.text = displayed;
	}

	public void UpdateScoreIndicator()
	{
		scoreIndicator.text = "Score: " + score;
	}

	public void SetWord(string word)
	{
		this.word = word.ToUpper ();
		revealed = new char[word.Length];

		UpdateWordIndicator ();
	}

	public void Next()
	{
		completed = false;
		hangman.reset ();
		SelectDifficulty ();
        timeLeft = 10.0f;
        SetWord (chosenWord);
		Debug.Log (difficulty);
		Debug.Log(chosenWord);
		Debug.Log(word);
	}

	public void Reset()
	{
		score = 0;
		UpdateScoreIndicator ();
		Next ();

	}

}
