using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NokLib
{
    public static class ClassReflector
    {
        public static List<Type> GetAllDerivedTypesOfType<T>()
        {
            return GetAllDerivedTypesOfType(typeof(T));
        }

        public static List<Type> GetAllPublicDerivedTypesOfType<T>()
        {
            return GetAllPublicDerivedTypesOfType(typeof(T));
        }

        public static List<Type> GetAllDerivedTypesOfType(Type type)
        {
            return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetTypes()
                    where type.IsAssignableFrom(assemblyType) && assemblyType != type && !assemblyType.IsAbstract
                    select assemblyType).ToList();
        }

        public static List<Type> GetAllPublicDerivedTypesOfType(Type type)
        {
            return (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    from assemblyType in domainAssembly.GetExportedTypes()
                    where type.IsAssignableFrom(assemblyType) && assemblyType != type && !assemblyType.IsAbstract
                    select assemblyType).ToList();
        }

        public static FieldInfo[] GetConstantsFrom<T>() => GetConstantsFrom(typeof(T));

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

        public static FieldInfo[] GetConstantsOfTypeFrom<T>(Type constantType) => GetConstantsOfTypeFrom(typeof(T), constantType);

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
