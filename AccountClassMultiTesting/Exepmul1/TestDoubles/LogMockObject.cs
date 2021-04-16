using bank.Dependecies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace bank.TestDoubles
{
    public class LogMockObject : ILogger
    {
        List<String> performedLogActions = new List<string>();
        List<String> excpectedLogActions = new List<string>();

        int expectedNumberOfCalls = 0;

        public void Log(String message)
        {
            performedLogActions.Add("method " + MethodBase.GetCurrentMethod().Name + " was called with message : " + message);
        }

        public void AddExceptedLogMessage(String message)
        {
            excpectedLogActions.Add(message);
        }

        public bool Verify()
        {
            if (GetNumberOfCalls() != expectedNumberOfCalls)
                return false;

            //in this specific example is the same like the test above. 
            //Could be splitted for different of logs.
            if (performedLogActions.Count() != excpectedLogActions.Count())
                return false;

            for(int i = 0; i< performedLogActions.Count(); i++)
            {
                Console.WriteLine(performedLogActions[i]);
                Console.WriteLine(excpectedLogActions[i]);

                if (!performedLogActions[i].Equals(excpectedLogActions[i]))
                    return false;
            }
            return true;
        }

        public void ExceptedNumberOfCalls(int v)
        {
            throw new NotImplementedException();
        }

        public void AddExcpectedLogMessage(string v)
        {
            throw new NotImplementedException();
        }

        public List<String> GetActions()
        {
            return performedLogActions;
        }
        public int GetNumberOfCalls()
        {
            return performedLogActions.Count;
        }
        internal void ExpectedNumberOfCalls(int p)
        {
            expectedNumberOfCalls = p;
        }

    }
}
