using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    /// <summary>
    /// Utilities to help with class reflection
    /// </summary>
    public static class ClassReflector
    {
        /// <returns>A list of all types deriving from type T</returns>
        public static List<Type> GetAllDerivedTypesOfType<T>()
        {
            return GetAllDerivedTypesOfType(typeof(T));
        }

        /// <returns>A list of all types deriving from type T that are publicly visible</returns>
        public static List<Type> GetAllPublicDerivedTypesOfType<T>()
        {
            return GetAllPublicDerivedTypesOfType(typeof(T));
        }

        /// <returns>A list of all types deriving from type T</returns>
        public static List<Type> GetAllDerivedTypesOfType(Type type)
        {
            return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetTypes()
                    where type.IsAssignableFrom(assemblyType) && assemblyType != type && !assemblyType.IsAbstract
                    select assemblyType).ToList();
        }

        /// <returns>A list of all types deriving from type T that are publicly visible</returns>
        public static List<Type> GetAllPublicDerivedTypesOfType(Type type)
        {
            return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetExportedTypes()
                    where type.IsAssignableFrom(assemblyType) && assemblyType != type && !assemblyType.IsAbstract
                    select assemblyType).ToList();
        }

        ///<typeparam name="T">Type to scan</typeparam>
        /// <returns>A FieldInfo array of all constants found in the provided type</returns>
        public static FieldInfo[] GetConstantsFrom<T>() => GetConstantsFrom(typeof(T));

        ///<param name="type">Type to scan</param>
        /// <returns>A FieldInfo array of all constants found in the provided type</returns>
        public static FieldInfo[] GetConstantsFrom(Type type)
        {
            List<FieldInfo> constants = new List<FieldInfo>();
            var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < fieldInfos.Length; i++) {
                var fieldInfo = fieldInfos[i];
                if (fieldInfo.IsLiteral && !fieldInfo.IsInitOnly)
                    constants.Add(fieldInfo);
            }
            return constants.ToArray();
        }

        /// <typeparam name="T">Type to be scanned</typeparam>
        /// <param name="constantType">Type of constants to return</param>
        /// <returns>A FieldInfo array of all constants of specified type found in the source type</returns>
        public static FieldInfo[] GetConstantsOfTypeFrom<T>(Type constantType) => GetConstantsOfTypeFrom(typeof(T), constantType);

        /// <param name="sourceType">Type to be scanned</param>
        /// <param name="constantType">Type of constants to return</param>
        /// <returns>A FieldInfo array of all constants of specified type found in the source type</returns>
        public static FieldInfo[] GetConstantsOfTypeFrom(Type sourceType, Type constantType)
        {
            List<FieldInfo> constants = new List<FieldInfo>();
            var fieldInfos = sourceType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            for (int i = 0; i < fieldInfos.Length; i++) {
                var fieldInfo = fieldInfos[i];
                if (fieldInfo.IsLiteral && !fieldInfo.IsInitOnly && fieldInfo.FieldType.Equals(constantType))
                    constants.Add(fieldInfo);
            }
            return constants.ToArray();
        }
    }
}
