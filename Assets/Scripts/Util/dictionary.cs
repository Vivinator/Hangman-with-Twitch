using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
	public class dictionary
	{
		/*private static dictionary s_instance;
		private string[] words

		public static dictionary instance 
		{
			get {return s_instance == null ? load () : s_instance;}
		}

		private dictionary (char[] words)
		{
		}

		private static bool isWordOk()
		{
			if (word.Length < 1)
			{
				return false;
			}

			foreach (char c in word)
			{
				if (!textUtils.isAlpha (c))
				{
					return false;
				}
			}
		}

		public static dictionary load()
		{
			if (s_instance != null)
			{
				return s_instance;
			}

			// Loaded the word list
			HashSet<string> wordList = new HashSet<string> ();

			TextAsset asset = Resources.Load ("words") as TextAsset;
			TextReader src = new StringReader (asset.text);
			// Read all the lines until the end of the file is reached
			while (src.Peek() != -1)
			{
				string word = src.ReadLine ();

				if (isWordOk (word))
				{
					wordList.Add (word);
				}
			}
			// Unloaded word list
			Resources.UnloadAsset (asset);

			// Set up the dictionary
			string[] words = new string [wordList.Count];
			wordList.CopyTo (words);

			s_instance = new dictionary (words);
			return s_instance;
		}

		public string next (int limit)
		{

			int index = (int)(Random.value * (words.Length-1));
			return words[index];
		}*/
	}
}

