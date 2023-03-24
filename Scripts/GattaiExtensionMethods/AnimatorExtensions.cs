using System.Collections;
using UnityEngine;

namespace GattaiExtensionMethods
{
    /// <summary>
    /// This class contains extensions methods to the Animator class.
    /// </summary>
    public static class AnimatorExtensions
    {
        /// <summary>
        /// Transition a BlendTree Animation smoothly.
        /// </summary>
        /// <param name="animator">The animator who will be transitioning.</param>
        /// <param name="parameterName">The animation's parameter name.</param>
        /// <param name="targetValue">The transition's final value. Must be greater than 0f and less than 1f.</param>
        /// <param name="timeStep">The higher, the faster the transition.</param>
        /// <returns>IEnumerator Coroutine. Call it with StartCoroutine().</returns>
        /// <example>StartCoroutine(animatorReference.SmoothTransitionCoroutine(
        /// parameterName = "Example", targetValue = 1f, timeStep = 2f));</example>
        public static IEnumerator SmoothTransitionCoroutine(
            this Animator animator, string parameterName, float targetValue, float timeStep = 1f)
        {
            return SmoothTransition(animator, targetValue, timeStep, parameterName, 0);
        }

        /// <summary>
        /// Transition a BlendTree Animation smoothly.
        /// </summary>
        /// <param name="animator">The animator who will be transitioning.</param>
        /// <param name="parameterHash">The animation's parameter hash. Use Animator.StringToHash() to obtain it.</param>
        /// <param name="targetValue">The transition's final value. Must be greater than 0f and less than 1f.</param>
        /// <param name="timeStep">The higher, the faster the transition.</param>
        /// <returns>IEnumerator Coroutine. Call it with StartCoroutine().</returns>
        /// <example>StartCoroutine(animatorReference.SmoothTransitionCoroutine(
        /// parameterHash = Animator.StringToHash("Example"), targetValue = 1f, timeStep = 2f));</example>
        public static IEnumerator SmoothTransitionCoroutine(
            this Animator animator, int parameterHash, float targetValue, float timeStep = 1f)
        {
            return SmoothTransition(animator, targetValue, timeStep, "", parameterHash);
        }

        // Makes the smooth transition.
        private static IEnumerator SmoothTransition(Animator animator, float targetValue, float timeStep = 1f, 
            string parameterName = "", int parameterHash = 0)
        {
            // Validate targetValue
            if (targetValue < 0f && targetValue > 1f)
            {
                Debug.LogError($"{nameof(targetValue)} must be greater than 0f and less than 1f. " +
                               $"{targetValue} has passed.");
                yield break;
            }

            var currentValue = 0f;

            // Increment or decrement the currentValue based on targetValue
            if (targetValue == 0f)
            {
                currentValue = 1f;
                
                while (currentValue > 0f)
                {
                    if (parameterName != "")
                    {
                        animator.SetFloat(parameterName, currentValue);
                    }
                    else if (parameterHash != 0)
                    {
                        animator.SetFloat(parameterHash, currentValue);
                    }
                    else
                    {
                        Debug.LogError("Neither name or hash has been passed properly.");
                    }
                    
                    currentValue -= Time.deltaTime * timeStep;
                    yield return null;
                }
            }
            else
            {
                while (currentValue < 1f)
                {
                    if (parameterName != "")
                    {
                        animator.SetFloat(parameterName, currentValue);
                    }
                    else if (parameterHash != 0)
                    {
                        animator.SetFloat(parameterHash, currentValue);
                    }
                    else
                    {
                        Debug.LogError("Neither name or hash has been passed properly.");
                    }
                    
                    currentValue += Time.deltaTime * timeStep;
                    yield return null;
                }
            }
            
            // Make sure the end animator value is the targetValue
            if (parameterName != "")
            {
                animator.SetFloat(parameterName, targetValue);
            }
            else if (parameterHash != 0)
            {
                animator.SetFloat(parameterHash, targetValue);
            }
            else
            {
                Debug.LogError("Neither name or hash has been passed properly.");
            }
        }
    }
}