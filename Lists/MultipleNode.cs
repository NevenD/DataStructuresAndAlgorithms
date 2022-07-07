namespace Lists
{
    public class MultipleNode<T>
    {
        public MultipleNode<T> Next { get; set; }
        public MultipleNode<T> Previous { get; set; }

        public T Value { get; set; }

        public MultipleNode(T value)
        {
            Value = value;
        }
    }
}
