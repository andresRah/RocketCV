namespace RocketCV.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RocketCV.Utils.Resources;
    using System.Net;

    /// <summary>
    /// BusinessBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessBase<T> where T : class, new()
    {
        /// <summary>
        /// The response business
        /// </summary>
        protected Response<T> ResponseBusiness;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessBase{T}"/> class.
        /// </summary>
        public BusinessBase()
        {
            ResponseBusiness = new Response<T>
            {
                ResponseCode = 0,
                TransactionComplete = false,
                Message = new List<string>(),
                Data = new List<T>()
            };
        }

        /// <summary>
        /// Responses the success.
        /// </summary>
        /// <returns></returns>
        public Response<T> ResponseSuccess()
        {
            ResponseBusiness.TransactionComplete = true;
            ResponseBusiness.ResponseCode = (int) HttpStatusCode.OK;
            ResponseBusiness.Message.Add(ResponseMessages.Success);
            return ResponseBusiness;
        }

        /// <summary>
        /// Responses the success.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Response<T> ResponseSuccess(HttpStatusCode code)
        {
            ResponseBusiness.TransactionComplete = true;
            ResponseBusiness.ResponseCode = (int)code;
            ResponseBusiness.Message.Add(ResponseMessages.ResourceManager.GetString(code.ToString())!);
            return ResponseBusiness;
        }

        /// <summary>
        /// Responses the fail.
        /// </summary>
        /// <returns></returns>
        public Response<T> ResponseFail()
        {
            ResponseBusiness.TransactionComplete = false;
            ResponseBusiness.ResponseCode = (int)HttpStatusCode.InternalServerError;
            ResponseBusiness.Message.Add(ResponseMessages.InternalError);
            return ResponseBusiness;
        }

        /// <summary>
        /// Responses the fail.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public Response<T> ResponseFail(HttpStatusCode code)
        {
            ResponseBusiness.TransactionComplete = false;
            ResponseBusiness.ResponseCode = (int)code;
            ResponseBusiness.Message.Add(ResponseMessages.ResourceManager.GetString(code.ToString())!);
            return ResponseBusiness;
        }

        /// <summary>
        /// Responses the fail.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="messages">The messages.</param>
        /// <returns></returns>
        public Response<T> ResponseFail(HttpStatusCode code, Collection<string> messages)
        {
            ResponseBusiness.TransactionComplete = false;
            ResponseBusiness.ResponseCode = (int)code;
            ResponseBusiness.Message = messages;
            return ResponseBusiness;
        }

        /// <summary>
        /// Responses the success.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Response<TEntity> ResponseSuccess<TEntity>(IList<TEntity> entity) where TEntity : class, new()
        {
            return new Response<TEntity>
            {
                ResponseCode = (int)HttpStatusCode.OK,
                TransactionComplete = true,
                Message = new List<string> { ResponseMessages.Success },
                Data = entity
            };
        }

        /// <summary>
        /// Responses the fail.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="responseCode">The response code.</param>
        /// <returns></returns>
        public static Response<TEntity> ResponseFail<TEntity>(HttpStatusCode responseCode) where TEntity : class, new()
        {
            return new Response<TEntity>
            {
                ResponseCode = (int)responseCode,
                TransactionComplete = false,
                Message = new List<string>
                {
                    ResponseMessages.ResourceManager.GetString(responseCode.ToString(CultureInfo.CurrentCulture))
                }
            };
        }
    }
}
