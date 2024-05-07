using AutoMapper.Internal.Mappers;
using Newtonsoft.Json;
using SymphoSphereApp.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Utilities
{
    public static class JsonSerialise
    {
        public static string SerializeUserData(this UserDataDto userDataDto)
        {
            return JsonConvert.SerializeObject(userDataDto); ;
        }

        public static UserDataDto DeserializeUserData()
        {
            string json = File.ReadAllText("E:\\Projects\\SymphoSphereApp\\SymphoSphereApp\\Configs\\Config.json");
            UserDataDto deserializedObj = JsonConvert.DeserializeObject<UserDataDto>(json);
            return deserializedObj;
        }

        public static void ResetJson(this UserDataDto userDataDto)
        {
            File.WriteAllText("E:\\Projects\\SymphoSphereApp\\SymphoSphereApp\\Configs\\Config.json", "");
        }

        public static void WriteToFile(this UserDataDto userDataDto)
        {
            
            File.WriteAllText("E:\\Projects\\SymphoSphereApp\\SymphoSphereApp\\Configs\\Config.json", userDataDto.SerializeUserData());
        }
    }
}
