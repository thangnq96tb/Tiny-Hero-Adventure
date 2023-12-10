public class Singleton<T> where T : class, new()
{
    protected static T m_instance;
    private static readonly object lockObject = new object();

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (lockObject)
                {
                    if (m_instance == null)
                    {
                        m_instance = new T();
                    }
                }
            }

            return m_instance;
        }
    }
}
