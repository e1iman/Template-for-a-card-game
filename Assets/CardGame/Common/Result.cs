using System;

namespace CardGame.Common
{
    public readonly struct Result<T>
    {
        readonly T value;
        readonly string error;
        readonly bool isSuccess;

        Result(T value)
        {
            this.value = value;
            error = null;
            isSuccess = true;
        }

        Result(string error)
        {
            value = default;
            this.error = error;
            isSuccess = false;
        }

        public bool IsSuccess => isSuccess;
        public bool IsFailure => !isSuccess;
        public string Error => error ?? string.Empty;
        
        public T Value {
            get {
                if (!isSuccess) {
                    throw new InvalidOperationException($"Cannot access value of failed result. Error: {error}");
                }
                return value;
            }
        }

        public static Result<T> Success(T value) => new(value);
        public static Result<T> Failure(string error) => new(error);
    }

    public readonly struct Result
    {
        readonly string error;
        readonly bool isSuccess;

        Result(string error)
        {
            this.error = error;
            isSuccess = false;
        }

        Result(bool success)
        {
            error = null;
            isSuccess = success;
        }

        public bool IsSuccess => isSuccess;
        public bool IsFailure => !isSuccess;
        public string Error => error ?? string.Empty;

        public static Result Success() => new(true);
        public static Result Failure(string error) => new(error);

        public void Match(Action onSuccess, Action<string> onFailure)
        {
            if (isSuccess) {
                onSuccess();
            } else {
                onFailure(error);
            }
        }

        public TResult Match<TResult>(Func<TResult> onSuccess, Func<string, TResult> onFailure)
        {
            return isSuccess ? onSuccess() : onFailure(error);
        }

        public override string ToString()
        {
            return isSuccess ? "Success" : $"Failure({error})";
        }
    }

    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this T value) => Result<T>.Success(value);
        
        public static Result<T> ToResult<T>(this T value, Func<T, bool> predicate, string errorMessage)
        {
            return predicate(value) ? Result<T>.Success(value) : Result<T>.Failure(errorMessage);
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess) {
                action(result.Value);
            }
            return result;
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
        {
            if (result.IsFailure) {
                action(result.Error);
            }
            return result;
        }
    }
}