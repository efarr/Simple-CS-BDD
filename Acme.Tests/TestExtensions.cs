using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

// Pulled this file in from previous projects. Just provides a more fluent way to assert.
namespace GiftRAP.Tests
{
	public static class TestExtensions
	{
		public static void ShouldContain(this string actual, string expected)
		{
			Assert.IsTrue(actual.Contains(expected));
		}

		public static void ShouldContain<T>(this IEnumerable<T> list, Func<T, bool> query)
		{
			Assert.IsTrue(list.Any(query));
		}

		public static void ShouldNotContain<T>(this IEnumerable<T> list, Func<T, bool> query)
		{
			Assert.IsFalse(list.Any(query));
		}

		public static void ShouldContain<T>(this IEnumerable<T> list, T value)
		{
			Assert.Contains(value, new List<T>(list));
		}

		public static void ShouldNotContain<T>(this IEnumerable<T> list, T value)
		{
			Assert.False(list.Contains(value));
		}

		public static void ShouldContain<T>(this IList<T> list, T value)
		{
			Assert.Contains(value, new List<T>(list));
		}

		public static void ShouldEqual<T>(this T actual, T expected)
		{
			Assert.AreEqual(expected, actual);
		}

		public static void ShouldEqual<T>(this T actual, T expected, string message)
		{
			Assert.AreEqual(expected, actual, message);
		}

		public static void ShouldEqual(this Money actual, decimal expected)
		{
			Assert.AreEqual(expected, actual);
		}

        public static void ShouldEqualWithinMillis(this DateTime actual, DateTime expected, double delta)
        {
            double actualDelta = (expected - actual).TotalMilliseconds;
            Assert.IsTrue(Math.Abs(actualDelta) < delta);
        }

        public static void ShouldEqualWithinMillis(this DateTime actual, DateTime expected, double delta, string message)
        {
            double actualDelta = (expected - actual).TotalMilliseconds;
            Assert.IsTrue(Math.Abs(actualDelta) < delta, message);
        }

		public static void ShouldEqualIgnoringWhitespace(this string actual, string expected)
		{
			Assert.AreEqual(Regex.Replace(expected, @"\s", "").Replace("\t", ""), Regex.Replace(actual, @"\s", "").Replace("\t", ""));
		}

		public static void ShouldNotEqual<T>(this T actual, T expected)
		{
			Assert.AreNotEqual(expected, actual);
		}

		public static void ShouldBeGreaterOrEqual(this DateTime actual, DateTime expected)
		{
			Assert.GreaterOrEqual(actual, expected);
		}

		public static void ShouldBeGreaterOrEqual(this int actual, int expected)
		{
			Assert.GreaterOrEqual(actual, expected);
		}

		public static void ShouldBeGreaterOrEqual(this string actual, string expected)
		{
			Assert.GreaterOrEqual(actual, expected);
		}

        public static void ShouldBeLessThan(this int actual, int expected)
        {
            Assert.Less(actual, expected);
        }

		public static void ShouldNotBeNull<T>(this T actual)
		{
			Assert.IsNotNull(actual);
		}

		public static void ShouldNotBeNull<T>(this T actual, string message)
		{
			Assert.IsNotNull(actual, message);
		}

        public static void ShouldNotBeNullOrEmpty(this string data)
        {
            Assert.IsFalse(string.IsNullOrEmpty(data));
        }

        public static void ShouldNotBeNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            Assert.IsNotNull(collection);
            Assert.Greater(0, collection.Count());
        }

		public static void ShouldBeNull<T>(this T actual)
		{
			Assert.IsNull(actual);
		}

		public static void ShouldBeNull<T>(this T actual, string message)
		{
			Assert.IsNull(actual, message);
		}

        public static void ShouldBeNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            if (collection != null && collection.Count() > 0)
            {
                Assert.Fail();
            }
        }

		public static void ShouldBeTrue(this bool actual)
		{
			Assert.IsTrue(actual);
		}

		public static void ShouldBeTrue(this bool actual, string message)
		{
			Assert.IsTrue(actual, message);
		}

		public static void ShouldBeFalse(this bool actual)
		{
			Assert.IsFalse(actual);
		}

		public static void ShouldBeFalse(this bool actual, string message)
		{
			Assert.IsFalse(actual, message);
		}

		public static void ShouldBeInstanceOf(this object actual, Type expected)
		{
			Assert.IsInstanceOf(expected, actual);
		}

		public static void ShouldBeInstanceOf(this object actual, Type expected, string message)
		{
			Assert.IsInstanceOf(expected, actual, message);
		}

		public static void ShouldBeInstanceOf<T>(this object actual)
		{
			Assert.IsInstanceOf(typeof(T), actual);
		}
		
		public static void ShouldBeInstanceOf<T>(this object actual, string message)
		{
			Assert.IsInstanceOf(typeof(T), actual, message);
		}
	}
}
