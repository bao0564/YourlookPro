﻿using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace yourlook.Extension
{
	//public static class SessionExtensions
	//{
	//	public static void SetJson(this ISession session, string key, object value)
	//	{
	//		session.SetString(key, JsonConvert.SerializeObject(value));
	//	}

	//	public static T GetJson<T>(this ISession session, string key)
	//	{
	//		var value = session.GetString(key);
	//		return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
	//	}
	//}
	public static class SessionExtensions
	{
		public static void SetJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}

		public static T GetJson<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}
	}

}
