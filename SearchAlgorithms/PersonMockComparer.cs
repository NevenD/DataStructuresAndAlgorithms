using System.Collections.Generic;

namespace SearchAlgorithms
{
    public class PersonMockComparer : IEqualityComparer<PersonMock>
    {
        public PersonMockComparer()
        {
        }

        public bool Equals(PersonMock x, PersonMock y)
        {
            return x.Age == y.Age && x.Name == y.Name;
        }

        public int GetHashCode(PersonMock obj)
        {
            return obj.GetHashCode();
        }
    }
}