using System.Net;
using System.Runtime.Serialization;
using CreditCard.Proposals.BFF.CrossCutting.CQRS;

namespace CreditCard.Proposals.BFF.DTOs.Responses.Common;

[DataContract]
public class BaseResponse<T> where T : View
{
    protected BaseResponse() { }

    public BaseResponse(T? data)
    {
        Data = data;
        Message = "Operation completed successfully.";
        StatusCode = (int)HttpStatusCode.OK;
        Errors = new List<BaseResponseError>();
    }

    public BaseResponse(string message, int statusCode, T? data)
    {
        Message = message;
        StatusCode = statusCode;
        Data = data;
        Errors = new List<BaseResponseError>();
    }

    public BaseResponse(int statusCode, List<BaseResponseError> errors)
    {
        StatusCode = statusCode;
        Errors = errors;
        Message = errors.Any() ? "There were errors in the operation." : "Unknown error occurred.";
    }

    public BaseResponse(string message, HttpStatusCode statusCode)
    {
        Errors = new List<BaseResponseError>() { new BaseResponseError(statusCode == HttpStatusCode.InternalServerError ? EErroType.SERVER : EErroType.GENERIC, message) };
        Message = "There were errors in the operation.";
        StatusCode = (int)statusCode;
    }

    public BaseResponse(List<BaseResponseError> errors)
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        Errors = errors;
        Message = errors.Any() ? "There were errors in the operation." : "Unknown error occurred.";
    }

    [DataMember]
    public string Message { get; private set; }

    [DataMember]
    public int StatusCode { get; private set; }

    [DataMember]
    public T? Data { get; private set; }

    [DataMember]
    public List<BaseResponseError> Errors { get; private set; }
}

[DataContract]
public class BaseResponseError
{
    public BaseResponseError(EErroType type, string description)
    {
        Type = type;
        Description = description;
    }

    protected BaseResponseError() { }

    [DataMember]
    public EErroType Type { get; private set; }

    [DataMember]
    public string Description { get; private set; }
}

