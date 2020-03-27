using Code7248.word_reader.Native;
using System;
using System.Runtime.InteropServices;

namespace Code7248.word_reader.Ole
{
	internal class OleStorage : IDisposable
	{
		private const int _DefaultFlags = 18;

		private IStorage _Storage;

		private string _Name;

		public string Name => _Name;

		public bool IsDisposed => _Storage == null;

		private OleStorage(IStorage storage, string name)
		{
			if (storage == null)
			{
				throw new ArgumentNullException("storage");
			}
			_Storage = storage;
			_Name = name;
		}

		~OleStorage()
		{
			Dispose(isDisposing: false);
		}

		private void Dispose(bool isDisposing)
		{
			if (_Storage != null)
			{
				if (isDisposing)
				{
					_Storage.Commit(0);
				}
				Marshal.ReleaseComObject(_Storage);
				_Storage = null;
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

		public static OleStorage CreateInstance(string path)
		{
			if (NativeMethods.StgOpenStorage(path, null, 18, IntPtr.Zero, 0, out IStorage ppstgOpen) != 0)
			{
				return null;
			}
			return new OleStorage(ppstgOpen, "Root");
		}

		public void Close()
		{
			Dispose();
		}

		public OleStream OpenStream(string name)
		{
			if (_Storage.OpenStream(name, IntPtr.Zero, 18, 0, out UCOMIStream ppstm) != 0)
			{
				return null;
			}
			return new OleStream(ppstm, name);
		}

		public byte[] ReadStream(string name)
		{
			OleStream oleStream = OpenStream(name);
			try
			{
				return oleStream.ReadToEnd();
			}
			finally
			{
				oleStream.Close();
			}
		}
	}
}
