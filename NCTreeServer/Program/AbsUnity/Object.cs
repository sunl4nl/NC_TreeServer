using System;
namespace AbsUnity
{
    public class Object
    {
        public string name { set; get; }
        public HideFlags hideFlags { set; get; }

        public static T FindObjectOfType<T>() where T : Object
        {
            return (T)((object)Object.FindObjectOfType(typeof(T)));
        }

        private static void CheckNullArgument(object arg, string message)
        {
            if (arg == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static Object FindObjectOfType(Type type)
        {
            Object[] array = Object.FindObjectsOfType(type);
            Object result;
            if (array.Length > 0)
            {
                result = array[0];
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static T[] FindObjectsOfType<T>() where T : Object
        {
            return ConvertObjects<T>(Object.FindObjectsOfType(typeof(T)));
        }

        public static Object[] FindObjectsOfType(Type type)
        {
            //TODO:
            return new Object[1];
        }

        internal static T[] ConvertObjects<T>(Object[] rawObjects) where T : Object
        {
            T[] result;
            if (rawObjects == null)
            {
                result = null;
            }
            else
            {
                T[] array = new T[rawObjects.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = (T)((object)rawObjects[i]);
                }
                result = array;
            }
            return result;
        }
    }
}
