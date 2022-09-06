using System.Collections.Generic;
using System.Linq;
using SimpleJSON;
using UnityEngine;

namespace Json
{
public static class JsonConverter
{
    public struct JsonData
    {
        public Vector3 p;
        public Vector3 r;
        public Vector3 s;
    }

    public static List<JsonData> GetTransformsFromJson( string jsonFile )
    {
        if ( jsonFile.Length == 0 )
        {
            return null; // no objects
        }

        JSONObject jsonObject = (JSONObject)JSON.Parse( jsonFile );

        var objects = jsonObject["objects"].Children;
        var jsonData = objects.Select( obj => new JsonData
            {
                p = new Vector3( obj["px"], obj["py"], obj["pz"] ),
                r = new Vector3( obj["rx"], obj["ry"], obj["rz"] ),
                s = new Vector3( obj["sx"], obj["sy"], obj["sz"] ),
            } )
            .ToList();
        return jsonData;
    }
}
}