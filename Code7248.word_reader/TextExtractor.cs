using System;
using System.IO;

namespace Code7248.word_reader
{
	public class TextExtractor
	{
		private string _path;

		public TextExtractor(string PathToWordDocument)
		{
			_path = PathToWordDocument;
		}

		public string ExtractText()
		{
			string text = "";
			if (Path.GetExtension(_path).Equals(".doc"))
			{
				doc_reader doc_reader = new doc_reader(_path);
				return doc_reader.ExtractText();
			}
			if (Path.GetExtension(_path).Equals(".docx"))
			{
				docx_reader docx_reader = new docx_reader(_path);
				return docx_reader.ExtractText();
			}
			throw new Exception("Input file not not valid.");
		}
	}
}
