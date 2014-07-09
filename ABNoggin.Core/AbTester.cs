using System;
using System.Collections.Generic;


namespace ABNoggin.Core
{
    public class ABTester
    {
	    public T Test<T>(String experimentName, T[] alternatives, String conversion) where T: struct
	    {
		    var experimentQuery = new ExperimentQuery<T>(experimentName);

			var shortCircuitAnswer = experimentQuery.GetAnswerIfExperimentEnded();
		    if (shortCircuitAnswer != null)
		    {
			    return shortCircuitAnswer.Value;
		    }

		    if (!experimentQuery.Exists())
		    {
			    experimentQuery.Create(conversion);
		    }

		    var choice = experimentQuery.GetAlternativeForUser(UserIdentity);
		    if (choice == null)
		    {
			    choice = PickOne(alternatives);
			    experimentQuery.SaveChoice(choice.Value, UserIdentity);
		    }

		    return choice.Value;
	    }

	    

	    public bool Test(String experimentName, String conversion)
	    {
		    return Test(experimentName, new [] {true, false}, conversion);
	    }

		private static T PickOne<T>(IList<T> alternatives)
		{
			var random = new Random(DateTime.Now.Millisecond);
			var index = random.Next(alternatives.Count - 1);
			return alternatives[index];
		}

	    private Guid UserIdentity
	    {
			// Todo: How do we work out user identity
		    get { return Guid.Empty; }
	    }
    }
}