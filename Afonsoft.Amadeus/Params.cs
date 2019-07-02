using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Afonsoft.Amadeus
{

    /// <summary>
    /// A convenient helper class for building data to pass into a request.
    /// 
    /// <pre>
    ///   amadeus.get("/foo/bar", Params.with("first_name", "John").and("last_name", "Smith"));
    /// </pre>
    /// </summary>
    public class Params : Dictionary<string, string>
    {
        protected internal string encoding = "UTF-8";

        protected internal Params()
        {
        }

        /// <summary>
        /// Initializes a new Param map with an initial key/value pair.
        /// 
        /// <pre>
        ///   amadeus.get("/foo/bar", Params.with("first_name", "John"));
        /// </pre>
        /// </summary>
        /// <param name="key"> the key for the parameter to send to the API </param>
        /// <param name="value"> the value for the given key </param>
        /// <returns> the Param object, allowing for convenient chaining </returns>
        public static Params with(string key, object value)
        {
            return (new Params()).and(key, value);
        }

        /// <summary>
        /// Adds another key/value pair to the Params map. Automatically
        /// converts all values to strings.
        /// 
        /// <pre>
        ///   amadeus.get("/foo/bar", Params.with("first_name", "John").and("last_name", "Smith"));
        /// </pre>
        /// </summary>
        /// <param name="key"> the key for the parameter to send to the API </param>
        /// <param name="value"> the value for the given key </param>
        /// <returns> the Param object, allowing for convenient chaining </returns>
        public virtual Params and(string key, object value)
        {
            this[key] = value.ToString();
            return this;
        }

        // Converts params into a HTTP query string.
        protected internal virtual string toQueryString()
        {
            StringBuilder query = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<string, string> entry in this)
            {
                if (!first)
                {
                    query.Append("&");
                }
                first = false;
                try
                {
                    query.Append(HttpUtility.UrlEncode(entry.Key));
                    query.Append("=");
                    query.Append(HttpUtility.UrlEncode(entry.Value));
                }
                catch (Exception)
                {
                    // no need to anything
                }
            }

            return query.ToString();
        }

        /// <summary>
        /// Converts params into a HTTP query string.
        /// </summary>
        public override string ToString()
        {
            return toQueryString();
        }
    }
}