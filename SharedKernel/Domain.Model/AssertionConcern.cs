using SharedKernel.Domain.Model.Event;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SharedKernel.Domain.Model
{
    public static class AssertionConcern
    {

        public static bool IsValid(params DomainNotification[] validations)
        {
            if (validations.Count(x => x != null) == 0)
                return true;

            foreach (var item in validations)
            {
                if (item == null) continue;
                DomainEvents.Notify<DomainNotification>(item);
            }

            return false;
        }

        public static DomainNotification AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
            {
                return new DomainNotification("AssertArgumentLength", message);
            }
            return null;
        }

        public static DomainNotification AssertArgumentMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
            {
                return new DomainNotification("AssertArgumentLength", message);
            }
            return null;
        }

        public static DomainNotification AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                return new DomainNotification("AssertArgumentNotEmpty", message);
            }
            return null;
        }

        public static DomainNotification AssertArgumentNotNull(object object1, string message)
        {

            if (object1 == null)
            {
                return new DomainNotification("AssertArgumentNotNull", message);
            }
            return null;
        }

        public static DomainNotification AssertArgumentTrue(bool boolValue, string message)
        {
            if (!boolValue)
            {
                return new DomainNotification("AssertArgumentTrue", message);

            }
            return null;
        }

    }
}


