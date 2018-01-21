using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
	public class dictionary
	{
		private dictionary (char[] words)
		{
		}

		public static dictionary load()
		{
			HashSet<string> wordList = new HashSet<string> ();

			TextAsset asset = Resources.Load ("words") as TextAsset;
			TextReader src = new StringReader (asset.text);

			while (src.Peek() != -1)
			{
				
			}
		}

		public string next (int limit)
		{
			return "";
		}
	}
}

