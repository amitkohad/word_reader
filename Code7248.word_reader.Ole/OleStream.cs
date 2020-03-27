using System;
using System.Runtime.InteropServices;

namespace Code7248.word_reader.Ole
{
	internal class OleStream
	{
		private UCOMIStream _Stream;

		private string _Name;

		public string Name => _Name;

		public bool IsDisposed => _Stream == null;

		public OleStream(UCOMIStream stream, string name)
		{
			_Stream = stream;
			_Name = name;
		}

		protected void Dispose(bool isDisposing)
		{
			if (_Stream != null)
			{
				if (isDisposing)
				{
					_Stream.Commit(0);
				}
				Marshal.ReleaseComObject(_Stream);
				_Stream = null;
			}
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				GC.SuppressFinalize(this);
				Dispose(isDisposing: true);
			}
		}

		public byte[] ReadToEnd()
		{
			_Stream.Stat(out STATSTG pstatstg, 0);
			long cbSize = pstatstg.cbSize;
			byte[] array = new byte[cbSize];
			_Stream.Read(array, (int)cbSize, IntPtr.Zero);
			return array;
		}

		public void Write(byte[] data)
		{
			_Stream.Write(data, data.Length, IntPtr.Zero);
		}

		public void Close()
		{
			Dispose();
		}
	}
}
