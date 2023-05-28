﻿using System;
using System.Reflection;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Type"/>
    /// </summary>
    internal static class TypeExt
    {
        /// <summary>
        /// Returns if the type is <see cref="Nullable"/>
        /// </summary>
        /// <param name="objectType">Type to check</param>
        /// <returns>True if type is <see cref="Nullable"/>; false otherwise</returns>
        public static bool IsNullable(this Type objectType) => objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>);
        
        /// <summary>
        /// Returns if the type is <see cref="Nullable"/>
        /// </summary>
        /// <param name="objectType">Type to check</param>
        /// <returns>True if type is <see cref="Nullable"/>; false otherwise</returns>
        public static Type GetNullableType(this Type objectType) => Nullable.GetUnderlyingType(objectType);

        /// <summary>
        /// Returns if a type is a value type
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsValueType(this Type source) => source.IsValueType;

        /// <summary>
        /// Returns the default value for <see cref="Type"/>
        /// </summary>
        /// <param name="type">Type to get default value for</param>
        /// <returns>default value for <see cref="Type"/></returns>
        public static object GetDefault(this Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;

        internal static T GetAttribute<T>(this Type type, bool inherit) where T : Attribute => type.GetCustomAttribute(typeof(T), inherit) as T;
        internal static bool HasAttribute<T>(this Type type, bool inherit) where T : Attribute => GetAttribute<T>(type, inherit) != null;
    }
}