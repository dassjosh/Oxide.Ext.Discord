using System;
using System.Reflection;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Extensions
{
    internal static class MethodInfoExt
    {
        public static Action CreateDelegate(this MethodInfo methodInfo, object target)
        {
            try
            {
                return (Action)Delegate.CreateDelegate(typeof(Action), target, methodInfo);
            }
            catch (Exception ex)
            {
                HandleException(ex, methodInfo, target);
                return null;
            }
        }
        
        public static Action<T1> CreateDelegate<T1>(this MethodInfo methodInfo, object target)
        {
            try
            {
                return (Action<T1>)Delegate.CreateDelegate(typeof(Action<T1>), target, methodInfo);
            }
            catch (Exception ex)
            {
                HandleException(ex, methodInfo, target);
                return null;
            }
        }
        
        public static Action<T1, T2> CreateDelegate<T1, T2>(this MethodInfo methodInfo, object target)
        {
            try
            {
                return (Action<T1, T2>)Delegate.CreateDelegate(typeof(Action<T1, T2>), target, methodInfo);
            }
            catch (Exception ex)
            {
                HandleException(ex, methodInfo, target, typeof(T1), typeof(T2));
                return null;
            }
        }

        private static void HandleException(Exception ex, MethodInfo methodInfo, object target, params Type[] types)
        {
            string expected = BuildExpected(methodInfo, types);
            string actual = BuildActual(methodInfo);
            DiscordExtension.GlobalLogger.Exception("Failed to create delegate for Plugin: {0} Method: {1} Expected: {2} Actual: {3}", target.GetType().GetRealTypeName(), methodInfo.Name, expected, actual, ex);
        }

        private static string BuildExpected(MethodInfo methodInfo, params Type[] types)
        {
            ValueStringBuilder sb = new();
            sb.Append("void ");
            sb.Append(methodInfo.Name);
            sb.Append('(');
            for (int index = 0; index < types.Length; index++)
            {
                Type type = types[index];
                if (index != 0)
                {
                    sb.Append(", ");
                }
                
                sb.Append(type.Name);
                sb.Append(" t");
                sb.Append(index);
            }
            sb.Append(')');
            return sb.ToString();
        } 
        
        private static string BuildActual(MethodInfo info)
        {
            ValueStringBuilder sb = new();
            sb.Append(info.ReturnType.Name);
            sb.Append(' ');
            sb.Append(info.Name);
            sb.Append('(');

            ParameterInfo[] parameters = info.GetParameters();
            for (int index = 0; index < parameters.Length; index++)
            {
                ParameterInfo parameter = parameters[index];
                if (index != 0)
                {
                    sb.Append(", ");
                }

                sb.Append(parameter.ParameterType.Name);
                sb.Append(' ');
                sb.Append(parameter.Name);
            }

            sb.Append(')');

            return sb.ToString();
        }
    }
}