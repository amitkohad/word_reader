using ICSharpCode.SharpZipLib.Zip;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Code7248.word_reader
{
	internal class docx_reader
	{
		private const string ContentTypeNamespace = "http://schemas.openxmlformats.org/package/2006/content-types";

		private const string WordprocessingMlNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

		private const string DocumentXmlXPath = "/t:Types/t:Override[@ContentType=\"application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml\"]";

		private const string BodyXPath = "/w:document/w:body";

		private string docxFile = "";

		private string docxFileLocation = "";

		public docx_reader(string fileName)
		{
			docxFile = fileName;
		}

		public string ExtractText()
		{
			if (string.IsNullOrEmpty(docxFile))
			{
				throw new Exception("Input file not specified.");
			}
			docxFileLocation = FindDocumentXmlLocation();
			if (string.IsNullOrEmpty(docxFileLocation))
			{
				throw new Exception("It is not a valid Docx file.");
			}
			return ReadDocumentXml();
		}

		private string FindDocumentXmlLocation()
		{
			ZipFile zipFile = new ZipFile(docxFile);
			foreach (ZipEntry item in zipFile)
			{
				if (string.Compare(item.Name, "[Content_Types].xml", ignoreCase: true) == 0)
				{
					Stream inputStream = zipFile.GetInputStream(item);
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.PreserveWhitespace = true;
					xmlDocument.Load(inputStream);
					inputStream.Close();
					XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
					xmlNamespaceManager.AddNamespace("t", "http://schemas.openxmlformats.org/package/2006/content-types");
					XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("/t:Types/t:Override[@ContentType=\"application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml\"]", xmlNamespaceManager);
					if (xmlNode == null)
					{
						break;
					}
					string attribute = ((XmlElement)xmlNode).GetAttribute("PartName");
					return attribute.TrimStart('/');
				}
			}
			zipFile.Close();
			return null;
		}

		private string ReadDocumentXml()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ZipFile zipFile = new ZipFile(docxFile);
			foreach (ZipEntry item in zipFile)
			{
				if (string.Compare(item.Name, docxFileLocation, ignoreCase: true) == 0)
				{
					Stream inputStream = zipFile.GetInputStream(item);
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.PreserveWhitespace = true;
					xmlDocument.Load(inputStream);
					inputStream.Close();
					XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
					xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
					XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("/w:document/w:body", xmlNamespaceManager);
					if (xmlNode != null)
					{
						stringBuilder.Append(ReadNode(xmlNode));
						break;
					}
					return string.Empty;
				}
			}
			zipFile.Close();
			return stringBuilder.ToString();
		}

		private string ReadNode(XmlNode node)
		{
			if (node == null || node.NodeType != XmlNodeType.Element)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.NodeType == XmlNodeType.Element)
				{
					switch (childNode.LocalName)
					{
					case "t":
					{
						stringBuilder.Append(childNode.InnerText.TrimEnd());
						string attribute = ((XmlElement)childNode).GetAttribute("xml:space");
						if (!string.IsNullOrEmpty(attribute) && attribute == "preserve")
						{
							stringBuilder.Append(' ');
						}
						break;
					}
					case "cr":
					case "br":
						stringBuilder.Append(Environment.NewLine);
						break;
					case "tab":
						stringBuilder.Append("\t");
						break;
					case "p":
						stringBuilder.Append(ReadNode(childNode));
						stringBuilder.Append(Environment.NewLine);
						stringBuilder.Append(Environment.NewLine);
						break;
					default:
						stringBuilder.Append(ReadNode(childNode));
						break;
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
}
