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

	private hangmanController hangman;
	private string word;
	private char[] revealed;
	private int score;
	private bool completed;

	// Use this for initialisation
	void Start()
	{
		InitialiseString ();
		hangman = GameObject.FindGameObjectWithTag ("Player").GetComponent <hangmanController>();

		reset ();
	}

	// Update is called once per frame
	void Update()
	{
		// Move to the next word
		if (completed)
		{
			if (Input.anyKeyDown)
			{
				next ();
			}
		}

		string s = Input.inputString;
		if (s.Length == 1 && textUtils.isAlpha (s[0]))
		{
			Debug.Log ("Have " + s);
			// Check for player failure
			if (!check(s.ToUpper()[0]))
			{
				hangman.punish ();

				if (hangman.isDead)
				{
					wordIndicator.text = word;
					completed = true;
				}
			}
		}
	}

	private bool check (char c)
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

			updateWordIndicator ();
			updateScoreIndicator ();
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

	public void selectDifficulty()
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

	public void updateWordIndicator()
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

	public void updateScoreIndicator()
	{
		scoreIndicator.text = "Score: " + score;
	}

	public void setWord(string word)
	{
		this.word = word.ToUpper ();
		revealed = new char[word.Length];

		updateWordIndicator ();
	}

	public void next()
	{
		selectDifficulty ();
		setWord (chosenWord);
		Debug.Log (difficulty);
		Debug.Log(chosenWord);
		Debug.Log(word);
	}

	public void reset()
	{
		score = 0;
		completed = false;
		hangman.reset ();
		updateScoreIndicator ();
		next ();

	}

}
