using System.Text;
using System.IO;
using Afonsoft.Amadeus.Client;
using Afonsoft.Exceptions;
using Afonsoft.Amadeus.Resources;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System;

namespace Afonsoft.Amadeus
{

    /// <summary>
    /// The HTTP part of the Amadeus API client. See the Amadeus class for
    /// more details on initialization.
    /// </summary>
    public class HTTPClient
    {

        public HttpRequestMessage HttpRequestMessage;

        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            accessToken = new AccessToken(this);
        }

        // A cached copy of the Access Token. It will auto refresh for every bearerToken (if needed)
        protected internal AccessToken accessToken;

        /// <summary>
        /// The configuration for this API client.
        /// </summary>
        public Configuration Configuration { get; set; }

        protected internal HTTPClient(Configuration configuration)
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            this.Configuration = configuration;
        }

        /// <summary>
        /// A helper module for making generic GET requests calls. It is used by
        /// every namespaced API GET method.
        /// </summary>
        /// <seealso cref= Amadeus#get(String, Params) </seealso>
        public virtual Response Get(string path)
        {
            return Request(Constants.GET, path, null);
        }

        /// <summary>
        /// <para>
        ///   A helper module for making generic GET requests calls. It is used by
        ///   every namespaced API GET method.
        /// </para>
        /// 
        /// <pre>
        ///   amadeus.referenceData.urls.checkinLinks.get(Params.with("airline", "1X"));
        /// </pre>
        /// 
        /// <para>
        ///   It can be used to make any generic API call that is automatically
        ///   authenticated using your API credentials:
        /// </para>
        /// 
        /// <pre>
        ///    amadeus.get("/v2/reference-data/urls/checkin-links", Params.with("airline", "1X"));
        /// </pre>
        /// </summary>
        /// <param name="path"> The full path for the API call </param>
        /// <param name="params"> The optional GET params to pass to the API </param>
        /// <returns> a Response object containing the status code, body, and parsed data. </returns>
        public virtual Response Get(string path, Params @params)
        {
            return Request(Constants.GET, path, @params);
        }

        /// <summary>
        /// A helper module for making generic POST requests calls. It is used by
        /// every namespaced API POST method.
        /// </summary>
        /// <seealso cref= Amadeus#post(String, Params) </seealso>
        public virtual Response Post(string path)
        {
            return Request(Constants.POST, path, null);
        }

        /// <summary>
        /// <para>
        ///   A helper module for making generic POST requests calls. It is used by
        ///   every namespaced API POST method.
        /// </para>
        /// 
        /// <pre>
        ///   amadeus.foo.bar.post(Params.with("airline", "1X"));
        /// </pre>
        /// 
        /// <para>
        ///   It can be used to make any generic API call that is automatically
        ///   authenticated using your API credentials:
        /// </para>
        /// 
        /// <pre>
        ///    amadeus.post("/v1/foo/bar", Params.with("airline", "1X"));
        /// </pre>
        /// </summary>
        /// <param name="path"> The full path for the API call </param>
        /// <param name="params"> The optional POST params to pass to the API </param>
        /// <returns> a Response object containing the status code, body, and parsed data. </returns>
        public virtual Response Post(string path, Params @params)
        {
            return Request(Constants.POST, path, @params);
        }

        /// <summary>
        /// A generic method for making any authenticated or unauthenticated request,
        /// passing in the bearer token explicitly. Used primarily by the
        /// AccessToken to get the first AccessToken.
        /// 
        /// @hides as only used internally
        /// </summary>
        public virtual Response UnauthenticatedRequest(string verb, string path, Params @params, string bearerToken)
        {
            Request request = BuildRequest(verb, path, @params, bearerToken);
            log(request);
            return Execute(request);
        }

        /// <summary>
        /// Fetches the previous page for a given response. </summary>
        /// <param name="response"> a response object previously received for which includes an array of data </param>
        /// <returns> a new response of data </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Response Previous(Response response)
        {
            return page(Constants.PREVIOUS, response);
        }

        /// <summary>
        /// Fetches the previous page for a given response. </summary>
        /// <param name="resource"> one of the responses previously received from an API call </param>
        /// <returns> a new array of resources of the same type </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Resource[] Previous(Resource resource)
        {
            return page(Constants.PREVIOUS, resource);
        }

        /// <summary>
        /// Fetches the next page for a given response. </summary>
        /// <param name="response"> a response object previously received for which includes an array of data </param>
        /// <returns> a new response of data </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Response Next(Response response)
        {
            return page(Constants.NEXT, response);
        }

        /// <summary>
        /// Fetches the next page for a given response. </summary>
        /// <param name="resource"> one of the responses previously received from an API call </param>
        /// <returns> a new array of resources of the same type </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Resource[] Next(Resource resource)
        {
            return page(Constants.NEXT, resource);
        }

        /// <summary>
        /// Fetches the first page for a given response. </summary>
        /// <param name="response"> a response object previously received for which includes an array of data </param>
        /// <returns> a new response of data </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Response First(Response response)
        {
            return page(Constants.FIRST, response);
        }

        /// <summary>
        /// Fetches the first page for a given response. </summary>
        /// <param name="resource"> one of the responses previously received from an API call </param>
        /// <returns> a new array of resources of the same type </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Resource[] First(Resource resource)
        {
            return page(Constants.FIRST, resource);
        }

        /// <summary>
        /// Fetches the last page for a given response. </summary>
        /// <param name="response"> a response object previously received for which includes an array of data </param>
        /// <returns> a new response of data </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Response Last(Response response)
        {
            return page(Constants.LAST, response);
        }

        /// <summary>
        /// Fetches the last page for a given response. </summary>
        /// <param name="resource"> one of the responses previously received from an API call </param>
        /// <returns> a new array of resources of the same type </returns>
        /// <exception cref="ResponseException"> if the page could not be found </exception>
        public virtual Resource[] Last(Resource resource)
        {
            return page(Constants.LAST, resource);
        }

        // A generic method for making requests of any verb.
        protected internal virtual Response Request(string verb, string path, Params @params)
        {
            return UnauthenticatedRequest(verb, path, @params, accessToken.BearerToken);
        }

        // Builds a request
        protected internal virtual Request BuildRequest(string verb, string path, Params @params, string bearerToken)
        {
            return new Request(verb, path, @params, bearerToken, this);
        }

        // A simple log that only triggers if we are in debug mode
        private void log(object @object)
        {
            if (Configuration.LogLevel != LogLevel.None)
            {
                ILogger logger = Configuration.Logger;

                string log = string.Format("{0}:{1}", Configuration.LogLevel, @object.ToString());

                if (logger != null)
                    logger.Log(Configuration.LogLevel, log, @object);
            }
        }

        // Executes a request and return a Response
        private Response Execute(Request request)
        {
            Response response = new Response(Fetch(request));
            response.parse(this);
            log(response);
            response.detectError(this);
            return response;
        }


        // Tries to make an API call. Raises an error if it can't complete the call.
        private Request Fetch(Request request)
        {
            try
            {
                request.establishConnection();
                Write(request);
            }
            catch (IOException ex)
            {
                throw new NetworkException(new Response(request), ex);
            }
            return request;
        }

        // Writes the parameters to the request.

        //private void write(Request request) throws java.io.IOException
        private void Write(Request request)
        {
            if (request.Verb == Constants.POST && request.Params != null)
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "");
                httpRequest.Content = new StringContent(request.Params.toQueryString(),
                                        Encoding.UTF8,
                                        "application/x-www-form-urlencoded");

                this.HttpRequestMessage = httpRequest;

            }
            else
            {
                this.HttpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "");
            }
        }

        /// <summary>
        /// Fetches the response for another page.
        /// @hide as ony used internally
        /// </summary>

        //protected Response page(String pageName, Response response) throws com.amadeus.exceptions.ResponseException
        protected internal virtual Response page(string pageName, Response response)
        {
            try
            {
                string[] parts = response.Result["meta"]["links"][pageName].ToString().Split('=');

                string pageNumber = parts[parts.Length - 1];

                Request request = response.Request;
                Params @params = (Params)request.Params;
                @params["page[offset]"] = pageNumber;

                return Request(request.Verb, request.Path, @params);
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (Exception ex)
            {
                throw new NotFoundException(response, ex);
            }
        }

        /// <summary>
        /// Fetches the response for another page.
        /// @hide as ony used internally
        /// </summary>

        //protected com.amadeus.resources.Resource[] page(String pageName, com.amadeus.resources.Resource resource) throws com.amadeus.exceptions.ResponseException
        protected internal virtual Resource[] page(string pageName, Resource resource)
        {
            Response response = page(pageName, resource.Response);
            return Resource.FromArray(response, resource.DeSerializationClass);
        }
    }
}