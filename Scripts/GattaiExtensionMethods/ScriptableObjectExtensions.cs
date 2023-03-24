using UnityEngine;

namespace GattaiExtensionMethods
{
    /// <summary>
    /// This class contains useful extensions methods to the class ScriptableObject.
    /// </summary>
    public static class ScriptableObjectExtensions
    {
        /// <summary>
        /// Creates and returns a clone of any given scriptable object.
        /// </summary>
        public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
        {
            // Check if the ScriptableObject is null and return default
            if (scriptableObject == null)
            {
                Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object.");
                return (T)ScriptableObject.CreateInstance(typeof(T));
            }
 
            // Create a instance of the ScriptableObject
            var instance = Object.Instantiate(scriptableObject);
        
            // Removes the word "Clone" from the name
            instance.name = scriptableObject.name; 
            return instance;
        }
    }
}
