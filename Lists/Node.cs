namespace Lists
{

    // recursive data structure
    // contains an reference to an object 
    // of its own type
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }

    }
}
