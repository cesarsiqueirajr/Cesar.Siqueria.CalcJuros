using System.Runtime.Serialization;

namespace CalcJuros.Services.Api.Controllers
{
    [DataContract]
    public struct ResultMessageResponse<TResult>
    {
        [DataMember(Name = "errors")]
        public string[] Errors { get; set; }

        [DataMember(Name = "data")]
        public TResult Data { get; }
        
        [DataMember(Name = "success")]
        public bool Success => !(Errors?.Length > 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        public ResultMessageResponse(TResult data, params string[] errors)
        {
            this.Data = data;
            this.Errors = errors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ResultMessageResponse<TResult>(TResult value)
            => new ResultMessageResponse<TResult>(value, null);
    }
}