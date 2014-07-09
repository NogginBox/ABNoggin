using System;
using System.Collections.Generic;
using System.Text;

namespace ABNoggin.Core
{
	internal class ExperimentQuery<T> where T : struct
	{
		private readonly string _experimentName;
		private readonly Guid _cacheKeyForExperiment;
		private readonly Dictionary<Guid, String> _cacheForExperiments;
		private readonly Dictionary<Guid, object> _cacheForUserAlternatives;

		public ExperimentQuery(String experimentName)
		{
			_experimentName = experimentName;
			
			// Todo: Can I use a string key and make it easier to understand
			_cacheKeyForExperiment = CreateGuidKeyFromString(experimentName);
			

			// Todo: Use a switchable and persistent implementation to store experiments
			_cacheForExperiments = new Dictionary<Guid, String>();
			_cacheForUserAlternatives = new Dictionary<Guid, object>();
		}

		public bool Exists()
		{
			return _cacheForExperiments.ContainsKey(_cacheKeyForExperiment);
		}

		public Nullable<T> GetAnswerIfExperimentEnded() 
		{
			// Todo: Check cache to see if this has ended
			return null;
		}

		private static Guid CreateGuidKeyFromString(String value)
		{
			byte[] stringbytes = Encoding.UTF8.GetBytes(value);
			byte[] hashedBytes = new System.Security.Cryptography
				.SHA1CryptoServiceProvider()
				.ComputeHash(stringbytes);
			Array.Resize(ref hashedBytes, 16);
			return new Guid(hashedBytes);
		}

		public void Create(string conversion)
		{
			_cacheForExperiments.Add(_cacheKeyForExperiment, conversion);
		}

		public Nullable<T> GetAlternativeForUser(Guid userIdentity)
		{
			var hashKey = CreateGuidKeyFromString(_experimentName + userIdentity);
			var answer = _cacheForUserAlternatives[hashKey];
			return (T)answer;
		}

		public void SaveChoice(T choice, Guid userIdentity)
		{
			var hashKey = CreateGuidKeyFromString(_experimentName + userIdentity);
			_cacheForUserAlternatives.Add(hashKey, choice);

			// Todo: Are we able to query for the number of people taking part
		}
	}
}
