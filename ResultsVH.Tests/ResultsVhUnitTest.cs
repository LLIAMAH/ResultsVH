using ResultsVH.Implementations;
using System.Net.Http.Json;
using System.Transactions;
using ResultsVH.Tests.Models;
using ResultsVH.Tests.RequestHandler;

namespace ResultsVH.Tests
{
    public class ResultsVhUnitTest
    {
        [Fact]
        public void Result_Generic_SuccessAndFailure()
        {
            var success = new Result<int, string>(42);
            Assert.True(success.IsSuccess);
            Assert.Equal(42, success.Data);
            Assert.Null(success.Message);

            var failure = new Result<int, string>("error");
            Assert.False(failure.IsSuccess);
            // ReSharper disable once PreferConcreteValueOverDefault
            Assert.Equal(default(int), failure.Data);
            Assert.Equal("error", failure.Message);
        }

        [Fact]
        public void Result_WithString_SuccessAndFailure()
        {
            var success = new Result<int>(10);
            Assert.True(success.IsSuccess);
            Assert.Equal(10, success.Data);
            Assert.Null(success.Message);

            var failure = new Result<int>("bad");
            Assert.False(failure.IsSuccess);
            // ReSharper disable once PreferConcreteValueOverDefault
            Assert.Equal(default(int), failure.Data);
            Assert.Equal("bad", failure.Message);
        }

        [Fact]
        public void ResultWithException_SuccessAndFailure()
        {
            var success = new ResultWithException<string>("payload");
            Assert.True(success.IsSuccess);
            Assert.Equal("payload", success.Data);
            Assert.Null(success.Message);

            var ex = new InvalidOperationException("boom");
            var failure = new ResultWithException<string>(ex);
            Assert.False(failure.IsSuccess);
            Assert.Null(failure.Data);
            Assert.Equal(ex, failure.Message);
        }

        [Fact]
        public void ResultWithErrorsArray_SuccessAndFailure()
        {
            var success = new ResultWithErrorsArray<string>("ok");
            Assert.True(success.IsSuccess);
            Assert.Equal("ok", success.Data);
            Assert.Null(success.Message);

            var errors = new[] { "e1", "e2" };
            var failure = new ResultWithErrorsArray<string>(errors);
            Assert.False(failure.IsSuccess);
            Assert.Null(failure.Data);
            Assert.Equal(errors, failure.Message);
        }

        [Fact]
        public void ResultBool_Variants()
        {
            var ok = new ResultBool(true);
            Assert.True(ok.IsSuccess);
            Assert.True(ok.Data);
            Assert.Null(ok.Message);

            var bad = new ResultBool("nope");
            Assert.False(bad.IsSuccess);
            // ReSharper disable once PreferConcreteValueOverDefault
            Assert.Equal(default(bool), bad.Data);
            Assert.Equal("nope", bad.Message);

            var okEx = new ResultBoolWithException(true);
            Assert.True(okEx.IsSuccess);
            Assert.True(okEx.Data);
            Assert.Null(okEx.Message);

            var ex = new Exception("err");
            var badEx = new ResultBoolWithException(ex);
            Assert.False(badEx.IsSuccess);
            Assert.False(badEx.Data);
            Assert.Equal(ex, badEx.Message);

            var okArr = new ResultBoolWithErrorsArray(true);
            Assert.True(okArr.IsSuccess);
            Assert.True(okArr.Data);
            Assert.Null(okArr.Message);

            var errs = new[] { "a", "b" };
            var badArr = new ResultBoolWithErrorsArray(errs);
            Assert.False(badArr.IsSuccess);
            Assert.False(badArr.Data);
            Assert.Equal(errs, badArr.Message);

            var okExArr = new ResultBoolWithExceptionsArray(true);
            Assert.True(okExArr.IsSuccess);
            Assert.True(okExArr.Data);
            Assert.Null(okExArr.Message);

            var exs = new[] { new Exception("x"), new Exception("y") };
            var badExArr = new ResultBoolWithExceptionsArray(exs);
            Assert.False(badExArr.IsSuccess);
            Assert.False(badExArr.Data);
            Assert.Equal(exs, badExArr.Message);
        }

        [Fact]
        public void ResultList_Variants()
        {
            var list = new List<int> { 1, 2 };
            var ok = new ResultList<int>(list);
            Assert.True(ok.IsSuccess);
            Assert.Equal(list, ok.Data);
            Assert.Null(ok.Message);

            var bad = new ResultList<int>("no items");
            Assert.False(bad.IsSuccess);
            Assert.Null(bad.Data);
            Assert.Equal("no items", bad.Message);

            var okEx = new ResultListWithException<int>(list);
            Assert.True(okEx.IsSuccess);
            Assert.Equal(list, okEx.Data);
            Assert.Null(okEx.Message);

            var ex = new Exception("err");
            var badEx = new ResultListWithException<int>(ex);
            Assert.False(badEx.IsSuccess);
            Assert.Null(badEx.Data);
            Assert.Equal(ex, badEx.Message);

            var okErrArr = new ResultListWithErrorsArray<int>(list);
            Assert.True(okErrArr.IsSuccess);
            Assert.Equal(list, okErrArr.Data);
            Assert.Null(okErrArr.Message);

            var errs = new[] { "e" };
            var badErrArr = new ResultListWithErrorsArray<int>(errs);
            Assert.False(badErrArr.IsSuccess);
            Assert.Null(badErrArr.Data);
            Assert.Equal(errs, badErrArr.Message);

            var okExArr = new ResultListWithExceptionsArray<int>(list);
            Assert.True(okExArr.IsSuccess);
            Assert.Equal(list, okExArr.Data);
            Assert.Null(okExArr.Message);

            var exs = new[] { new Exception("x") };
            var badExArr = new ResultListWithExceptionsArray<int>(exs);
            Assert.False(badExArr.IsSuccess);
            Assert.Null(badExArr.Data);
            Assert.Equal(exs, badExArr.Message);
        }

        private string PrepareFakeData1()
        {
            return """
                   {
                     "isSuccess": true,
                     "data": [
                       {
                         "id": 1,
                         "name": "Scenario 1"
                       },
                       {
                         "id": 2,
                         "name": "Scenario 2"
                       }
                     ],
                     "message": null
                   }
                   """;
        }

        private string PrepareFakeDataBool1()
        {
            return """
                   {
                     "isSuccess": true,
                     "data": true,
                     "message": null
                   }
                   """;
        }

        private HttpClient PrepareFakeHandler(string json)
        {
            var handler = new FakeHttpMessageHandler(json);

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost")
            };

            return httpClient;
        }

        [Fact]
        public async Task GetFromJsonAsync_ShouldDeserialize_ResultList()
        {
            // Arrange
            var httpClient = PrepareFakeHandler(PrepareFakeData1());

            // Act
            var result = await httpClient.GetFromJsonAsync<ResultList<TestTypeModel>>("/api/data");

            // Assert
            Assert.NotNull(result);

            Assert.True(result.IsSuccess);
            Assert.Null(result.Message);

            Assert.NotNull(result.Data);
            Assert.Equal(2, result.Data.Count);

            Assert.Equal(1, result.Data[0].Id);
            Assert.Equal("Scenario 1", result.Data[0].Name);

            Assert.Equal(2, result.Data[1].Id);
            Assert.Equal("Scenario 2", result.Data[1].Name);
        }

        [Fact]
        public async Task GetFromJsonAsync_ShouldDeserialize_ResultBool()
        {
            // Arrange
            var httpClient = PrepareFakeHandler(PrepareFakeDataBool1());

            //Act
            var result = await httpClient.GetFromJsonAsync<ResultBool>("/api/data");

            // Assert
            Assert.NotNull(result);

            Assert.True(result.IsSuccess);
            Assert.Null(result.Message);

            Assert.True(result.Data);
        }
    }
}
