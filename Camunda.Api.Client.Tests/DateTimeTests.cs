using System;
using Xunit;

namespace Camunda.Api.Client.Tests;

public class DateTimeTests
{
  [Theory]
  [InlineData("2010-01-01T01:01:01", "2010-01-01T01:01:01.000+0000")]
  [InlineData("2010-05-01T01:01:01", "2010-05-01T01:01:01.000+0100")]
  public void GetDateTime(string testDateTimeString, string expectedDatetimeString)
  {
    var actualIso8601DateString = DateTime.Parse(testDateTimeString).ToJavaISO8601();
    Assert.Equal(expectedDatetimeString, actualIso8601DateString);
  }
}