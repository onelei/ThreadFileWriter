using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadFileWriter
{
    public enum EThreadFileType
    {
        TEST,
        LOG,
    }

    public struct EThreadFileTypeCompare : IEqualityComparer<EThreadFileType>
    {
        public bool Equals(EThreadFileType x, EThreadFileType y)
        {
            return (int)x == (int)y;
        }

        public int GetHashCode(EThreadFileType obj)
        {
            return (int)obj;
        }
    }

    public class ThreadFileWriterManager
    {
        private static ThreadFileWriterManager _Instance;
        public static ThreadFileWriterManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ThreadFileWriterManager();
                }
                return _Instance;
            }
        }

        private Dictionary<EThreadFileType, ThreadFileWriter> DictFileWriter = new Dictionary<EThreadFileType, ThreadFileWriter>(new EThreadFileTypeCompare());

        private void Init()
        {
            DictFileWriter.Clear();
            DictFileWriter.Add(EThreadFileType.TEST, new ThreadTestFileWriter());
            DictFileWriter.Add(EThreadFileType.LOG, new ThreadLogFileWriter());
        }

        public void OnAwake()
        {
            Init();
            Dictionary<EThreadFileType, ThreadFileWriter>.Enumerator enumerator = DictFileWriter.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.OnAwake();
            }
        }

        public void OnDestroy()
        {
            Dictionary<EThreadFileType, ThreadFileWriter>.Enumerator enumerator = DictFileWriter.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.OnDestroy();
            }
        }

        public void Log(EThreadFileType eThreadFileType, string str)
        {
            ThreadFileWriter threadFileWriter;
            if (DictFileWriter.TryGetValue(eThreadFileType, out threadFileWriter))
            {
                threadFileWriter.Log(str);
            }
        }
    }
}
