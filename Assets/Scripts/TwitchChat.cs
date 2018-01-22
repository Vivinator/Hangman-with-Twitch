﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;
using UnityEngine.UI;

public class TwitchChat : MonoBehaviour {

	private TcpClient twitchClient;
	private StreamReader reader;
	private StreamWriter writer;

	public string username, password, channelName; // Get the password from https://twitchapps.com/tmi
	public Text chatBox;

	// Use this for initialization
	void Start () {
		Connect ();
	}
	
	// Update is called once per frame
	void Update () {
		// if client is not connected...
		if (!twitchClient.Connected)
		{
			// call connect funciton to connect again
			Connect ();
		}

		ReadChat ();
	}

	private void Connect()
	{
		twitchClient = new TcpClient ("irc.chat.twitch.tv", 6667);
		reader = new StreamReader (twitchClient.GetStream ());
		writer = new StreamWriter (twitchClient.GetStream ());

		writer.WriteLine ("PASS " + password);
		writer.WriteLine ("NICK " + username);
		writer.WriteLine ("USER "  + username + " 8 * :" + username);
		writer.WriteLine ("JOIN #" + channelName);
		writer.Flush (); 
	}

	private void ReadChat()
	{
		if(twitchClient.Available > 0)
		{
			// Read the current message
			var message = reader.ReadLine ();

			if (message.Contains("PRIVMSG"))
			{
				// Get the user's name by splitting it from the string
				var splitPoint = message.IndexOf("!", 1);
				var chatName = message.Substring(0, splitPoint);
				chatName = chatName.Substring(1);

				// Get the user's message by splitting it from the string
				splitPoint = message.IndexOf (":", 1);
				message = message.Substring(splitPoint + 1);
				print (String.Format("{0}: {1}", chatName, message));
				// Print message in chat box
				chatBox.text = chatBox.text + "\n" + String.Format ("{0}: {1}", chatName, message);
			}
		}
	}

	private void GameInputs(string ChatInputs)
	{
		
	}
}
