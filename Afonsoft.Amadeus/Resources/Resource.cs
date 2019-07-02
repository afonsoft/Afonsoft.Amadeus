using Afonsoft.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Afonsoft.Amadeus.Resources
{
    /// <summary>
    /// A generic resource as returned by all namespaced APIs.
    /// </summary>
    public class Resource
    {
        protected internal Resource()
        {
        }

        /// <summary>
        /// The original response that this object is populated from.
        /// </summary>

        //Response response;
        public Response Response;
        /// <summary>
        /// The class used for deserialization.
        /// @hide as only used internally
        /// </summary>

        //Class deSerializationClass;
        public Type DeSerializationClass;

        /// <summary>
        /// Turns a response into a Gson deserialized array of resources,
        /// attaching the response to each resource.
        /// @hide as only used internally
        /// </summary>
        public static Resource[] FromArray(Response response, Type t)
        {
            try
            {
                JArray json = response.Data as JArray;
                Resource[] resources = json.ToObject(t) as Resource[];
                foreach (Resource resource in resources)
                {
                    resource.Response = response;
                    resource.DeSerializationClass = t;
                }
                return resources;
            }
            catch (Exception ex)
            {
                throw new ResponseException(response, ex);
            }
        }

        /// <summary>
        /// Turns a response into a Gson deserialized resource,
        /// attaching the response to the resource.
        /// @hide as only used internally
        /// </summary>
        public static Resource FromObject(Response response, Type t)
        {
            try
            {
                JObject json = response.Data as JObject;
                Resource resource = json.ToObject(t) as Resource;
                resource.Response = response;
                resource.DeSerializationClass = t;
                return resource;
            }
            catch (Exception ex)
            {
                throw new ResponseException(response, ex);
            }
        }
    }
}